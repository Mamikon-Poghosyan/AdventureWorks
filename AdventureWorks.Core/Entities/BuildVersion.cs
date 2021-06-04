using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorks.Core.Entities
{
    public partial class BuildVersion
    {
        public byte SystemInformationId { get; set; }
        public string DatabaseVersion { get; set; }
        public DateTime VersionDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
