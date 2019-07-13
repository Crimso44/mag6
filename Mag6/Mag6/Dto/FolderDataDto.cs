using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mag6.Dto
{
    public class FolderDataDto
    {
        public FolderDataDto()
        {
            Bitrates = new Dictionary<int, int>();
            Dvds = new List<string>();
        }

        public void AddBitrate(int btr)
        {
            if (Bitrates.ContainsKey(btr))
                Bitrates[btr]++;
            else
                Bitrates[btr] = 1;
        }

        public string GetBitrateString()
        {
            var br = "";
            if (Bitrates.Any())
            {
                if (Bitrates.Count == 1)
                    br = Bitrates.Keys.ToList().First().ToString();
                else
                {
                    var keys = Bitrates.Keys.ToList();
                    keys.Sort();
                    if (Bitrates.Count == 2)
                    {
                        if (Bitrates[keys[0]] == 1 && Bitrates[keys[1]] != 1)
                            br = keys[1].ToString() + "-";
                        else if (Bitrates[keys[0]] != 1 && Bitrates[keys[1]] == 1)
                            br = keys[0].ToString() + "+";
                        else
                            br = keys[0].ToString() + "-" + keys[1].ToString();
                    }
                    else
                    {
                        br = keys[0].ToString() + "-" + keys.Last().ToString();
                    }
                }
            }
            return br;
        }

        public int? Duration { get; set; }
        public long? Size { get; set; }
        public Dictionary<int, int> Bitrates { get; set; }
        public List<string> Dvds { get; set; }
    }
}
