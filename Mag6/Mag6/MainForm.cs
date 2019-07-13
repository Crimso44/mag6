using ATL;
using Mag6.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mag6
{
    public partial class MainForm : Form
    {

        private Mag6Entities _ctx;
        private bool _stop;
        private string _filter = "";
        private List<AlbumDto> _treeList = new List<AlbumDto>();
        private List<string> _loadErrors = new List<string>();
        private List<AlbumDto> _searchResults = new List<AlbumDto>();
        private int _searchIndex = 0;
        private string _searchedSong = null;
        private Mutex _mutexObj = new Mutex();
        private int _loadersCount = 0;
        private List<string> _imagesLoaded = new List<string>();
        private List<string> _imagesToLoad = new List<string>();
        private List<KeyImageDto> _imagesAlmostLoaded = new List<KeyImageDto>();

        public MainForm()
        {
            InitializeComponent();

            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            txtMusicPath.Text = config.AppSettings.Settings["MusicPath"]?.Value;
            tVolume.Text = config.AppSettings.Settings["UploadVolume"]?.Value;
            tDestination.Text = config.AppSettings.Settings["UploadDestination"]?.Value;
            tSource.Text = config.AppSettings.Settings["AddSource"]?.Value;
            tDvdName.Text = config.AppSettings.Settings["AddDvdName"]?.Value;

            _ctx = new Mag6Entities();

            ConfigTreeView();
            LoadRoot();

            FillDvds();
        }


        private void ConfigTreeView()
        {
            tlwAlbums.CanExpandGetter = delegate (object x)
            {
                var alb = x as AlbumDto;
                return alb.ChildIds.Any();
            };

            tlwAlbums.ChildrenGetter = delegate (object x)
            {
                var alb = x as AlbumDto;
                var chlds = _treeList.Where(y => alb.ChildIds.Contains(y.Id)).ToList();
                return new ArrayList(chlds);
            };

            olvName.ImageGetter = delegate (object row) {
                var data = (AlbumDto)row;
                var key = data.Id.ToString();
                try
                {
                    if (!tlwAlbums.SmallImageList.Images.ContainsKey(key) && !_imagesLoaded.Contains(key))
                    {
                        _imagesLoaded.Add(key);

                        var path = GetDirName(txtMusicPath.Text);
                        path = path.Substring(0, path.Length - 6) + data.Path + "\\" + data.Name;

                        _mutexObj.WaitOne();
                        if (_loadersCount >= 3)
                        {
                            _imagesToLoad.Add(path + ";" + key);
                        }
                        else
                        {
                            _loadersCount++;
                            var loader = new ImageLoader(path, key, LoadCallback, FinishCallback);
                            var t = new Thread(new ThreadStart(loader.ThreadProc));
                            t.Start();
                        }
                        _mutexObj.ReleaseMutex();

                        /*var path = GetDirName(txtMusicPath.Text);
                        path = path.Substring(0, path.Length - 6) + data.Path + "\\" + data.Name;
                        var dir = new DirectoryInfo(path);
                        if (dir.Exists)
                        {
                            var files = dir.GetFiles("*.jpg");
                            if (!files.Any()) return null;
                            var file = files.Where(x => x.Name.ToLower() == "folder.jpg").FirstOrDefault();
                            if (file == null)
                                file = files.Where(x => x.Name.ToLower() == "cover.jpg").FirstOrDefault();
                            if (file == null)
                                file = files[0];

                            try
                            {
                                using (Stream BitmapStream = File.Open(file.FullName, FileMode.Open))
                                {
                                    Image img = Image.FromStream(BitmapStream);
                                    tlwAlbums.SmallImageList.Images.Add(key, img);
                                    imagesBig.Images.Add(key, img);
                                }
                            } catch (Exception e) {
                                // 
                            }
                        }*/
                    }
                } catch (Exception e)
                {
                    // ?
                }
                return key;
            };
        }

        private void LoadCallback(string key, Image img)
        {
            _mutexObj.WaitOne();
            _imagesAlmostLoaded.Add(new KeyImageDto { Key = key, Image = img });
            _mutexObj.ReleaseMutex();
        }

        public void OnIdle(object sender, EventArgs e)
        {
            _mutexObj.WaitOne();
            while (_imagesAlmostLoaded.Any())
            {
                var im = _imagesAlmostLoaded[0];
                tlwAlbums.SmallImageList.Images.Add(im.Key, im.Image);
                imagesBig.Images.Add(im.Key, im.Image);
                _imagesAlmostLoaded.RemoveAt(0);
            }
            _mutexObj.ReleaseMutex();
        }

        private void FinishCallback()
        {
            _mutexObj.WaitOne();
            if (_imagesToLoad.Any())
            {
                var path_key = _imagesToLoad[0].Split(';');
                _imagesToLoad.RemoveAt(0);
                var loader = new ImageLoader(path_key[0], path_key[1], LoadCallback, FinishCallback);
                var t = new Thread(new ThreadStart(loader.ThreadProc));
                t.Start();
            }
            else
            {
                _loadersCount--;
            }
            _mutexObj.ReleaseMutex();
        }

        private void LoadRoot()
        {
            _treeList.Clear();

            // загрузка корневой ноды дерева
            var root = _ctx.Albums.FirstOrDefault(x => !x.ParentId.HasValue);
            if (root != null)
            {
                var alb = new AlbumDto(root);
                _treeList.Add(alb);
                tlwAlbums.Roots = new List<AlbumDto>() { alb };

                LoadChildrenTree(alb);

                // ... и дочерних, для плюсиков в дереве
                foreach (var ch in alb.ChildIds)
                {
                    var chAlb = _treeList.Where(x => x.Id == ch).First();
                    LoadChildrenTree(chAlb);
                }

                tlwAlbums.Expand(alb);
            }
        }

        private void LoadChildrenTree(AlbumDto rootAlb)
        {
            if (!rootAlb.ChildIds.Any())
            {
                var childQry = _ctx.Albums.Where(x => x.ParentId == rootAlb.Id);
                if (!string.IsNullOrEmpty(_filter))
                    childQry = childQry.Where(x => x.DVDs.Select(y => y.Name).ToList().Contains(_filter));
                var children = childQry.OrderBy(x => x.Name).ToList();
                foreach (var ch in children)
                {
                    var alb = new AlbumDto(ch);
                    var oldAlb = _treeList.Where(x => x.Id == ch.Id).FirstOrDefault();
                    if (oldAlb != null) _treeList.Remove(oldAlb);
                    _treeList.Add(alb);
                    rootAlb.ChildIds.Add(alb.Id);
                }
                tlwAlbums.RefreshObject(rootAlb);
            }
        }

        private void txtMusicPath_TextChanged(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings["MusicPath"].Value = txtMusicPath.Text;
            config.Save(ConfigurationSaveMode.Minimal);
        }

        private FolderDataDto LoadDirectory(DirectoryInfo d, string path, Album parentAlbum)
        {
            var res = new FolderDataDto();

            if (_stop) return res;

            label1.Text = path;
            Application.DoEvents();

            // помечаем для удаления все песни (пока)
            var songs = parentAlbum.Songs.ToList();
            var songsToDel = songs.Select(x => x.Id).ToList();
            var dvds = parentAlbum.DVDs.ToList();
            var dvdsToDel = dvds.Select(x => x.Id).ToList();

            try
            {
                var files = d.GetFiles();
                foreach (var file in files)
                {
                    if (file.Name == "magdata")
                    {
                        var magFile = File.ReadAllLines(file.FullName);
                        var magdata = new List<string>(magFile);

                        foreach(var line in magdata)
                        {
                            if (line == "hidden")
                                parentAlbum.IsHidden = true;
                            else if (!string.IsNullOrEmpty(line))
                            {
                                var dvd = dvds.FirstOrDefault(x => x.Name == line);
                                if (dvd == null)
                                {
                                    dvd = new DVD()
                                    {
                                        AlbumId = parentAlbum.Id,
                                        Name = line
                                    };
                                    _ctx.DVDs.Add(dvd);
                                } else
                                    dvdsToDel.Remove(dvd.Id);
                                res.Dvds.Add(line);
                            }
                        }
                    }
                    else
                    {
                        var sng = songs.FirstOrDefault(x => x.FileName == file.Name);
                        if (sng == null)
                        {
                            sng = new Song()
                            {
                                AlbumId = parentAlbum.Id,
                                FileName = file.Name
                            };
                            _ctx.Songs.Add(sng);
                            parentAlbum.Songs.Add(sng);
                        }
                        else
                            songsToDel.Remove(sng.Id);

                        if (sng.Size != file.Length || sng.Created.ToString("dd.MM.yyyy hh:mm") != file.CreationTime.ToString("dd.MM.yyyy hh:mm"))
                        {
                            sng.Size = file.Length;
                            sng.Created = file.CreationTime;

                            if (file.Extension.ToLower() == ".mp3")
                            {
                                try
                                {
                                    var mp3 = new Track(file.FullName);
                                    sng.Name = Util.toUtf8(mp3.Title);
                                    sng.Bitrate = mp3.Bitrate;
                                    sng.Duration = mp3.Duration;
                                    sng.IsVbr = mp3.IsVBR;
                                }
                                catch (Exception e) {
                                    //MessageBox.Show(e.Message);
                                }
                            }
                        }
                    }
                }
            }
            catch { }

            // удаляем не найденные песни
            if (songsToDel.Any())
            {
                var songToDelete = songs.Where(x => songsToDel.Contains(x.Id)).ToList();
                _ctx.Songs.RemoveRange(songToDelete);
            }
            if (dvdsToDel.Any())
            {
                var dvdToDelete = dvds.Where(x => dvdsToDel.Contains(x.Id)).ToList();
                _ctx.DVDs.RemoveRange(dvdToDelete);
            }
            _ctx.SaveChanges();


            // обрабатываем вложенные папки
            var albsToDel = _ctx.Albums.Where(x => x.ParentId == parentAlbum.Id).Select(x => x.Id).ToList();

            try
            {
                var innerDvds = new List<string>();
                var folders = d.GetDirectories();
                foreach (var folder in folders)
                {
                    var dir = _ctx.Albums.Include("Songs").Include("DVDs")
                        .FirstOrDefault(x => x.Path == path && x.Name == folder.Name);
                    if (dir == null)
                    {
                        dir = new Album()
                        {
                            Path = path,
                            Name = folder.Name,
                            ParentId = parentAlbum.Id
                        };
                        _ctx.Albums.Add(dir);
                    }
                    else
                    {
                        dir.ParentId = parentAlbum.Id;
                        albsToDel.Remove(dir.Id);
                    }
                    _ctx.SaveChanges();

                    var dat = LoadDirectory(folder,
                        (string.IsNullOrEmpty(path) ? "" : path + "\\") + folder.Name, dir);
                    res.Size = (res.Size ?? 0) + (dat.Size ?? 0);
                    res.Duration = (res.Duration ?? 0) + (dat.Duration ?? 0);
                    foreach(var key in dat.Bitrates.Keys)
                    {
                        if (res.Bitrates.ContainsKey(key))
                            res.Bitrates[key] += dat.Bitrates[key];
                        else
                            res.Bitrates[key] = dat.Bitrates[key];
                    }
                    foreach(var dvd in dat.Dvds)
                    {
                        if (!innerDvds.Contains(dvd))
                            innerDvds.Add(dvd);
                    }
                }

                if (innerDvds.Any())
                {
                    foreach (var dvd in res.Dvds)
                    {
                        if (!innerDvds.Contains(dvd))
                            _loadErrors.Add($"- {dvd}: {parentAlbum.Path}\\{parentAlbum.Name}");
                    }
                    foreach (var dvd in innerDvds)
                    {
                        if (!res.Dvds.Contains(dvd))
                            _loadErrors.Add($"+ {dvd}: {parentAlbum.Path}\\{parentAlbum.Name}");
                    }
                }
            }
            catch { }


            if (!_stop)
            {
                var albumsToDel = _ctx.Albums.Where(x => albsToDel.Contains(x.Id)).ToList();
                foreach (var alb in albumsToDel)
                {
                    // ищем для удаления только во вложенных папках
                    var albumsQuery = _ctx.Albums.Where(x => x.Path.StartsWith(alb.Path + "\\" + alb.Name));

                    var toDeleteSongs = _ctx.Songs
                        .Where(y => albumsQuery.Select(x => x.Id).ToList().Contains(y.AlbumId)
                    ).ToList();
                    _ctx.Songs.RemoveRange(toDeleteSongs);

                    var toDeleteDvds = _ctx.DVDs
                        .Where(y => albumsQuery.Select(x => x.Id).ToList().Contains(y.AlbumId)
                    ).ToList();
                    _ctx.DVDs.RemoveRange(toDeleteDvds);

                    var toDelete = albumsQuery.ToList();
                    _ctx.Albums.RemoveRange(toDelete);

                    if (alb.Songs.Any()) _ctx.Songs.RemoveRange(alb.Songs);
                    if (alb.DVDs.Any()) _ctx.DVDs.RemoveRange(alb.DVDs);
                    _ctx.Albums.Remove(alb);

                    _ctx.SaveChanges();
                }
            }
            _ctx.SaveChanges();

            RecalcDurations(parentAlbum, res);

            label1.Text = "";
            Application.DoEvents();

            return res;
        }

        private string GetPathToAlbum(Album album)
        {
            // стартовая папка - приходится отрезать "Music", чтобы не задублировалось
            var dir = GetDirName(txtMusicPath.Text);
            if (album.Path != "")
            {
                if (album.Path == "Music")
                    dir += album.Name;
                else
                    dir += album.Path.Substring(6) + "\\" + album.Name;
            }
            return dir;
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            _loadErrors.Clear();
            var selected = tlwAlbums.SelectedObject as AlbumDto;
            Album start = null;
            if (selected != null)
            {
                start = _ctx.Albums.Where(x => x.Id == selected.Id).FirstOrDefault();
            }
            var txt = "Refresh music" + 
                (start == null || start.Path == "" ? "" : 
                    " from " + (start.Path + "\\" + start.Name).Substring(6)) + "?";
            var confirmResult = MessageBox.Show(txt, "Confirm", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                _stop = false;
                bRefresh.Enabled = false;
                bStop.Enabled = true;

                DirectoryInfo d;
                if (start == null)
                {
                    // если все ветки
                    start = _ctx.Albums.Include("Songs").Include("DVDs")
                        .FirstOrDefault(x => x.Path == "" && x.Name == "Music");
                    if (start == null)
                    {
                        start = new Album()
                        {
                            Path = "",
                            Name = "Music",
                        };
                        _ctx.Albums.Add(start);
                        _ctx.SaveChanges();
                    }
                    d = new DirectoryInfo(txtMusicPath.Text);
                } else
                {
                    // если выбрана ветка
                    _ctx.Entry(start).Collection("Songs").Load();

                    var dir = GetPathToAlbum(start);
                    d = new DirectoryInfo(dir);
                }

                var dat = LoadDirectory(d, 
                    (string.IsNullOrEmpty(start.Path) ? "" : start.Path + "\\") + start.Name, start);

                if (selected != null)
                {
                    selected.ChildIds.Clear();
                    selected.Assign(dat);
                    LoadChildrenTree(selected);
                    foreach (var chId in selected.ChildIds)
                    {
                        var chAlb = _treeList.Where(x => x.Id == chId).First();
                        LoadChildrenTree(chAlb);
                    }
                    tlwAlbums.RefreshObject(selected);

                    // изменения наверх до корня
                    while (selected.ParentId.HasValue)
                    {
                        selected = _treeList.Where(x => x.Id == selected.ParentId.Value).First();
                        RecalcDurations(selected);
                        tlwAlbums.RefreshObject(selected);
                    }
                }

                FillDvds();

                var msg = "OK!";
                foreach (var err in _loadErrors)
                    msg += "\n" + err;
                MessageBox.Show(msg);
            }
            bRefresh.Enabled = true;
            bStop.Enabled = false;
        }

        private void RecalcDurations(AlbumDto sel)
        {
            var res = new FolderDataDto();
            var chAlbs = _ctx.Albums.Where(x => x.ParentId == sel.Id).ToList();
            foreach (var chAlb in chAlbs)
            {
                res.Size = (res.Size ?? 0) + (chAlb.Size ?? 0);
                res.Duration = (res.Duration ?? 0) + (chAlb.Duration ?? 0);
                if (!string.IsNullOrEmpty(chAlb.Bitrate))
                {
                    if (chAlb.Bitrate.EndsWith("+") || chAlb.Bitrate.EndsWith("-"))
                    {
                        var bit = int.Parse(chAlb.Bitrate.Substring(0, chAlb.Bitrate.Length - 1));
                        res.AddBitrate(bit);
                        res.AddBitrate(bit);
                    } else if (chAlb.Bitrate.Contains("-"))
                    {
                        var bitLst = chAlb.Bitrate.Split('-');
                        foreach(var bitStr in bitLst)
                        {
                            var bit = int.Parse(bitStr);
                            res.AddBitrate(bit);
                            res.AddBitrate(bit);
                        }
                    } else
                    {
                        var bit = int.Parse(chAlb.Bitrate);
                        res.AddBitrate(bit);
                        res.AddBitrate(bit);
                    }
                }
            }
            var alb = _ctx.Albums.Where(x => x.Id == sel.Id).First();
            RecalcDurations(alb, res);
        }

        private void RecalcDurations(Album parentAlbum, FolderDataDto res)
        {
            // рассчитываем размеры, битрейты и продолжительности
            foreach (var sng in parentAlbum.Songs)
            {
                res.Duration = (res.Duration ?? 0) + (sng.Duration ?? 0);
                res.Size = (res.Size ?? 0) + sng.Size;
                if (sng.Bitrate.HasValue)
                    res.AddBitrate(sng.Bitrate.Value);
            }

            var br = res.GetBitrateString();
            if (parentAlbum.Bitrate != br || parentAlbum.Size != res.Size || parentAlbum.Duration != res.Duration)
            {
                parentAlbum.Bitrate = br;
                parentAlbum.Size = res.Size;
                parentAlbum.Duration = res.Duration;
                _ctx.SaveChanges();

                var treeItem = _treeList.Where(x => x.Id == parentAlbum.Id).FirstOrDefault();
                if (treeItem != null)
                {
                    treeItem.Assign(res);
                    tlwAlbums.RefreshObject(treeItem);
                }
            }
        }

        private void FillDvds()
        {
            dsDvds.Tables[0].Clear();
            var row = dsDvds.Tables[0].NewRow();
            row["Name"] = "Все";
            dsDvds.Tables[0].Rows.Add(row);
            var dvds = _ctx.DVDs.Select(x => x.Name).Distinct().OrderBy(x => x).ToList();
            foreach(var dvd in dvds)
            {
                row = dsDvds.Tables[0].NewRow();
                row["Name"] = dvd;
                dsDvds.Tables[0].Rows.Add(row);
            }
            dwDvds.DataSource = null;
            dwDvds.DataSource = dsDvds;
            dwDvds.DataMember = "Dvds";
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            _stop = true;
        }

        private void dwSongs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dwSongs.Columns[e.ColumnIndex].Name.Equals("Duration"))
            {
                if (e.Value != null && !DBNull.Value.Equals(e.Value))
                {
                    var val = (int)e.Value;
                    e.Value = Util.FormatDuration(val);
                    e.FormattingApplied = true;
                }
            }
        }

        private void dwSongs_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dwSongs.Rows[e.RowIndex];
            if (!((string)row.Cells["FileName"].Value).ToLower().EndsWith(".mp3"))
            {
                row.DefaultCellStyle.ForeColor = Color.Gray;
            }

            if (!string.IsNullOrEmpty(_searchedSong) && ((string)row.Cells["FileName"].Value).ToLower().Contains(_searchedSong))
            {
                row.DefaultCellStyle.BackColor = Color.LightSkyBlue;
            }
        }

        private void dwDvds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var newFlt = "";
            if (e.RowIndex > 0) 
                newFlt = (string)dwDvds.Rows[e.RowIndex].Cells[0].Value;

            if (_filter != newFlt)
            {
                _filter = newFlt;
                LoadRoot();
            }
        }

        private void bUpload_Click(object sender, EventArgs e)
        {
            if (pUploadPanel.Visible)
                pUploadPanel.Hide();
            else
            {
                pUploadPanel.Show();
                if (pAddMusic.Visible)
                    pAddMusic.Hide();
            }
        }

        private void tDestination_TextChanged(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings["UploadDestination"].Value = tDestination.Text;
            config.Save(ConfigurationSaveMode.Minimal);
        }

        private void tVolume_TextChanged(object sender, EventArgs e)
        {
            bDoUpload.Enabled = false;
            int vol;
            if (int.TryParse(tVolume.Text, out vol)) {
                bDoUpload.Enabled = true;

                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings["UploadVolume"].Value = tVolume.Text;
                config.Save(ConfigurationSaveMode.Minimal);
            }
        }

        private void tDestination_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bDoUpload_Click(null, null);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

            private void tVolume_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bDoUpload_Click(null, null);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void bDoUpload_Click(object sender, EventArgs e)
        {
            try
            {
                var rnd = new CryptoRandom();
                var cnt = 0;
                var fullSize = long.Parse(tVolume.Text) * 1024 * 1024;
                var dest = GetDirName(tDestination.Text);

                Directory.CreateDirectory(dest);
                var d = new DirectoryInfo(tDestination.Text);
                Util.EmptyFolder(d);

                long size = 0;
                var albs = _ctx.Albums.Where(x => !(x.IsHidden ?? false) && !(x.IsUploaded ?? false))
                    .Select(x => new { x.Id, x.Name, x.Path }).ToList()
                    .OrderBy(x => x.Name.Reverse().ToString()).ThenBy(x => x.Path.Reverse().ToString())
                    .Select(x => x.Id).ToList();
                while (size < fullSize)
                {
                    if (!albs.Any())
                    {
                        var all = _ctx.Albums.ToList();
                        all.ForEach(a => a.IsUploaded = false);
                        _ctx.SaveChanges();

                        albs = _ctx.Albums.Where(x => !(x.IsHidden ?? false))
                            .Select(x => x.Id).ToList();
                    }

                    var next = albs[rnd.Next(albs.Count)];
                    var uplAlbum = _ctx.Albums.Where(x => x.Id == next).First();

                    try
                    {
                        var dirList = uplAlbum.Path.Split('\\').ToList();
                        // Music и стиль пропускаем
                        if (dirList.Count > 2)
                        {
                            var df = new DirectoryInfo(GetPathToAlbum(uplAlbum));
                            var files = df.GetFiles();
                            if (files.Any(x => x.Extension.ToLower() == ".mp3"))
                            {
                                cnt++;

                                dirList.RemoveRange(0, 2);
                                dirList.Insert(0, cnt.ToString("000"));
                                dirList.Add(uplAlbum.Name);
                                var newDirName = string.Join(" ", dirList);
                                var dn = new DirectoryInfo(dest + newDirName);
                                dn.Create();

                                foreach (var file in files)
                                {
                                    if (file.Name != "magdata")
                                    {
                                        size += file.Length;
                                        file.CopyTo(dest + newDirName + "\\" + file.Name);
                                    }
                                }
                            }
                        }
                    }
                    catch { }

                    uplAlbum.IsUploaded = true;
                    _ctx.SaveChanges();
                    albs.Remove(next);
                }

                MessageBox.Show("Upload OK");
            }
            catch (Exception ex) {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void tlwAlbums_Expanded(object sender, BrightIdeasSoftware.TreeBranchExpandedEventArgs e)
        {
            var alb = e.Model as AlbumDto;
            foreach(var chId in alb.ChildIds)
            {
                var chAlb = _treeList.Where(x => x.Id == chId).First();
                LoadChildrenTree(chAlb);
            }
        }

        private void tlwAlbums_SelectionChanged(object sender, EventArgs e)
        {
            var data = tlwAlbums.SelectedObject as AlbumDto;
            dsSongs.Tables[0].Clear();
            pbAlbum.Hide();
            if (data != null)
            {
                var songs = _ctx.Songs.Where(x => x.AlbumId == data.Id).OrderBy(x => x.FileName).ToList();
                foreach (var song in songs)
                {
                    var row = dsSongs.Tables[0].NewRow();
                    dsSongs.Tables[0].Rows.Add(row);
                    row["FileName"] = song.FileName;
                    row["Size"] = song.Size;
                    if (!string.IsNullOrEmpty(song.Name)) row["Name"] = song.Name;
                    if (song.Bitrate.HasValue) row["Bitrate"] = song.Bitrate;
                    if (song.Duration.HasValue) row["Duration"] = song.Duration;
                    if (song.IsVbr.HasValue) row["VBR"] = song.IsVbr;
                }
                dwSongs.DataSource = null;
                dwSongs.DataSource = dsSongs;
                dwSongs.DataMember = "Songs";


                if (!data.ParentId.HasValue) FillDvds();

                foreach (DataGridViewRow r in dwDvds.Rows)
                {
                    r.Selected = data.Dvds.Contains((string)r.Cells[0].Value);
                }

                var key = data.Id.ToString();
                if (imagesBig.Images.ContainsKey(key))
                {
                    pbAlbum.Image = imagesBig.Images[key];
                    pbAlbum.Show();
                }
            }
        }

        private void tlwAlbums_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            var data = e.Model as AlbumDto;
            if (data.IsHidden)
            {
                e.Item.ForeColor = Color.Gray;
            }
            if (data.Dvds.Count == 1)
            {
                e.Item.Font = new Font(tlwAlbums.Font, FontStyle.Bold);
            }
        }

        private void bAddMusic_Click(object sender, EventArgs e)
        {
            if (pAddMusic.Visible)
                pAddMusic.Hide();
            else
            {
                pAddMusic.Show();
                if (pUploadPanel.Visible)
                    pUploadPanel.Hide();
            }
        }

        private void tSource_TextChanged(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings["AddSource"].Value = tSource.Text;
            config.Save(ConfigurationSaveMode.Minimal);
        }

        private void tDvdName_TextChanged(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings["AddDvdName"].Value = tDvdName.Text;
            config.Save(ConfigurationSaveMode.Minimal);
        }

        private void tSource_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bDoAddMusic_Click(null, null);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void tDvdName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bDoAddMusic_Click(null, null);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void bDoAddMusic_Click(object sender, EventArgs e)
        {
            var dirFrom = new DirectoryInfo(tSource.Text);
            var dirTo = new DirectoryInfo(txtMusicPath.Text);

            AddFolder(dirFrom, dirTo);

            MessageBox.Show("OK!");
        }

        private string GetDirName(string s)
        {
            return s + (s.EndsWith("\\") ? "" : "\\");
        }

        private void AddFolder (DirectoryInfo dirFrom, DirectoryInfo dirTo)
        {
            var files = dirFrom.GetFiles();
            foreach(var file in files)
            {
                var toFileName = GetDirName(dirTo.FullName) + file.Name;
                if (!File.Exists(toFileName))
                    File.Copy(file.FullName, toFileName);
            }

            var magdataFileName = GetDirName(dirTo.FullName) + "magdata";
            if (File.Exists(magdataFileName))
            {
                var magFile = File.ReadAllLines(magdataFileName).ToList();
                if (!magFile.Contains(tDvdName.Text))
                {
                    magFile.Add(tDvdName.Text);
                    File.WriteAllLines(magdataFileName, magFile.ToArray());
                }
            } else
            {
                File.WriteAllText(magdataFileName, tDvdName.Text);
            }

            var dirs = dirFrom.GetDirectories();
            foreach(var dir in dirs)
            {
                var innerDirTo = new DirectoryInfo(GetDirName(dirTo.FullName) + dir.Name);
                Directory.CreateDirectory(innerDirTo.FullName);
                AddFolder(dir, innerDirTo);
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            _searchResults.Clear();
            _searchIndex = 0;
            if (string.IsNullOrEmpty(tSearch.Text)) {
                tSearch.Focus();
                return;
            }
            var qry = _ctx.Albums.AsQueryable();
            if (cbSearchSongs.Checked)
                qry = qry
                    .Where(x =>
                        x.Name.Contains(tSearch.Text) ||
                        x.Songs.Any(y => y.Name.Contains(tSearch.Text) || y.FileName.Contains(tSearch.Text)));
            else
                qry = qry.Where(x => x.Name.Contains(tSearch.Text));
            if (!string.IsNullOrEmpty(_filter))
                qry = qry.Where(x => x.DVDs.Select(y => y.Name).ToList().Contains(_filter));
            _searchResults = qry.OrderBy(x => x.Path + "\\" + x.Name).ToList()
                .Select(x => new AlbumDto(x)).ToList();
            if (!_searchResults.Any())
            {
                MessageBox.Show("Ничего не найдено.");
                return;
            }
            DisplayNode(_searchResults[_searchIndex], cbSearchSongs.Checked ? tSearch.Text : null);
        }

        private void DisplayNode(AlbumDto node, string songSearched)
        {
            tlwAlbums.Focus();
            var parents = new List<int>();
            var n = node;
            while (n.ParentId.HasValue)
            {
                parents.Add(n.ParentId.Value);
                var alb = _ctx.Albums.Where(x => x.Id == n.ParentId).First();
                n = new AlbumDto(alb);
            }
            AlbumDto obj = null;
            for(var i=parents.Count-1;i>=0;i--)
            {
                obj = _treeList.Where(x => x.Id == parents[i]).First();
                tlwAlbums.Expand(obj);
            }

            _searchedSong = string.IsNullOrEmpty(songSearched) ? "" : songSearched.ToLower();

            obj = _treeList.Where(x => x.Id == node.Id).First();
            tlwAlbums.SelectedObject = obj;
            tlwAlbums.FocusedObject = obj;
            tlwAlbums.EnsureModelVisible(obj);
        }

        private void tSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bSearch_Click(null, null);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && e.Control)
            {
                tSearch.Focus();
                tSearch.SelectionStart = 0;
                tSearch.SelectionLength = tSearch.Text.Length;

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.L && e.Control)
            {
                bSearchNext_Click(null, null);

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void bSearchNext_Click(object sender, EventArgs e)
        {
            if (!_searchResults.Any())
            {
                bSearch_Click(sender, e);
            } else
            {
                _searchIndex++;
                if (_searchIndex >= _searchResults.Count)
                {
                    MessageBox.Show("Больше не найдено.");
                    return;
                }
                DisplayNode(_searchResults[_searchIndex], _searchedSong);
            }
        }

        private void tlwAlbums_CellRightClick(object sender, BrightIdeasSoftware.CellRightClickEventArgs e)
        {
            if (e.Model == null)
                e.MenuStrip = null;
            else
            {
                e.MenuStrip = mAlbums;
                miHidden.Checked = ((AlbumDto)e.Model).IsHidden;
                miHidden.Tag = e.Model;
                miToFolder.Tag = e.Model;
            }
        }

        private void miToFolder_Click(object sender, EventArgs e)
        {
            var data = ((ToolStripMenuItem)sender).Tag as AlbumDto;
            var path = GetDirName(txtMusicPath.Text);
            path = path.Substring(0, path.Length - 6) + data.Path + "\\" + data.Name;
            System.Diagnostics.Process.Start(path);
        }

        private void miHidden_Click(object sender, EventArgs e)
        {
            var data = ((ToolStripMenuItem)sender).Tag as AlbumDto;
            var path = GetDirName(txtMusicPath.Text);
            path = path.Substring(0, path.Length - 6) + data.Path + "\\" + data.Name + "\\magdata";
            var magFile = File.ReadAllLines(path);
            var magdata = new List<string>(magFile);

            if (data.IsHidden)
            {
                magdata.Remove("hidden");
            } else
            {
                if (!magdata.Contains("hidden"))
                    magdata.Add("hidden");
            }

            File.WriteAllLines(path, magdata.ToArray());

            data.IsHidden = !data.IsHidden;
            var alb = _ctx.Albums.Where(x => x.Id == data.Id).First();
            alb.IsHidden = data.IsHidden;
            _ctx.SaveChanges();

            tlwAlbums.RefreshObject(data);
        }
    }
}
