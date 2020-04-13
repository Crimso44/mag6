using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mag6.Dto
{
    public class AlbumDto
    {
        public AlbumDto(Album a)
        {
            Assign(a);
        }

        public void Assign(Album a)
        {
            Id = a.Id;
            ParentId = a.ParentId;
            Path = a.Path;
            Name = a.Name;
            Duration = Util.FormatDuration(a.Duration);
            Size = Util.FormatSize(a.Size);
            Bitrate = a.Bitrate;
            IsHidden = a.IsHidden ?? false;
            ChildIds = new List<int>();
            Dvds = a.DVDs.Select(x => x.Name).OrderBy(x => x).ToList();
        }

        public void Assign(FolderDataDto a)
        {
            Duration = Util.FormatDuration(a.Duration);
            Size = Util.FormatSize(a.Size);
            Bitrate = a.GetBitrateString();
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public List<int> ChildIds { get; set; }
        public List<string> Dvds { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Size { get; set; }
        public string Bitrate { get; set; }
        public bool IsHidden { get; set; }
    }
}
