using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mag6
{
    public static class Util
    {
        public static string toUtf8(string unknown)
        {
            if (unknown == null) return null;
            return new string(unknown.ToCharArray().
                Select(x => ((x + 848) >= 'А' && (x + 848) <= 'ё') ? (char)(x + 848) : x).
                ToArray());
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T element in source)
            {
                action(element);
            }
        }

        public static void EmptyFolder(DirectoryInfo directoryInfo, bool isTop = true)
        {
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                File.SetAttributes(file.FullName, FileAttributes.Normal);
                file.Delete();
            }

            foreach (DirectoryInfo subfolder in directoryInfo.GetDirectories())
            {
                EmptyFolder(subfolder, false);
            }

            if (!isTop)
                directoryInfo.Delete();
        }

        public static string FormatDuration(int? val)
        {
            if (!val.HasValue) return "";
            var txt = (val % 60).ToString();
            if (val > 59)
            {
                if (txt.Length < 2) txt = "0" + txt;
                var mins = val / 60;
                txt = (mins % 60).ToString() + ":" + txt;
                if (mins > 59)
                {
                    if (txt.Length < 5) txt = "0" + txt;
                    var hrs = mins / 60;
                    txt = (hrs % 24).ToString() + ":" + txt;
                    if (hrs > 23)
                    {
                        if (txt.Length < 8) txt = "0" + txt;
                        var days = hrs / 24;
                        txt = days.ToString() + ":" + txt;
                    }
                }
            }
            return txt;
        }

        public static string FormatSize(long? size)
        {
            if (!size.HasValue) return "";
            if (size == 0) return "";
            if (size > 1024 * 1024 * 1024) return (size.Value / 1024.0 / 1024.0 / 1024.0).ToString("0.##") + "G";
            if (size > 1024 * 1024) return (size.Value / 1024.0 / 1024.0).ToString("0.##") + "M";
            if (size > 1024) return (size.Value / 1024.0).ToString("0.##") + "K";
            return size.Value.ToString("0.##");
        }
    }
}
