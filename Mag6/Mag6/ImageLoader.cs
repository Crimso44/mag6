using Mag6.Dto;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.ImageList;

namespace Mag6
{
    public class ImageLoader
    {
        public delegate void LoadCallback(string key, Image img);
        public delegate void FinishCallback();

        private string _path;
        private string _key;
        private LoadCallback _callback;
        private FinishCallback _finishCallback;


        public ImageLoader(string path, string key, LoadCallback callback, FinishCallback finishCallback)
        {
            _path = path;
            _key = key;
            _callback = callback;
            _finishCallback = finishCallback;
        }

        public void ThreadProc() {
            try
            {
                var dir = new DirectoryInfo(_path);
                if (dir.Exists)
                {
                    var files = dir.GetFiles("*.jpg").OrderBy(x => x.Name).ToList();
                    if (!files.Any()) return;
                    var file = files.Where(x => x.Name.ToLower() == "folder.jpg").FirstOrDefault();
                    if (file == null)
                        file = files.Where(x => x.Name.ToLower() == "cover.jpg").FirstOrDefault();
                    if (file == null)
                    {
                        file = files.Where(x => x.Name.ToLower().Contains("front")).FirstOrDefault();
                    }
                    if (file == null)
                        file = files[0];

                    try
                    {
                        using (Stream BitmapStream = File.Open(file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            Image img = Image.FromStream(BitmapStream);
                            _callback(_key, img);
                        }
                    }
                    catch (Exception e)
                    {
                        // 
                    }
                }
            } finally
            {
                _finishCallback();
            }
        }

        private string GetDirName(string s)
        {
            return s + (s.EndsWith("\\") ? "" : "\\");
        }
    }
}
