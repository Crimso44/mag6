//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mag6
{
    using System;
    using System.Collections.Generic;
    
    public partial class Song
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public long Size { get; set; }
        public Nullable<int> Bitrate { get; set; }
        public Nullable<int> Duration { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<bool> IsVbr { get; set; }
    
        public virtual Album Album { get; set; }
    }
}
