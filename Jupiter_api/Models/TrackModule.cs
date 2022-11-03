using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jupiter_api.Models
{
    [Keyless]
    [Table("Track_Module")]
    public partial class TrackModule
    {
        [Column("Track_No")]
        public int TrackNo { get; set; }
        [Column("Module_No")]
        public int ModuleNo { get; set; }

        [ForeignKey("ModuleNo")]
        public virtual ModuleDetail ModuleNoNavigation { get; set; } = null!;
        [ForeignKey("TrackNo")]
        public virtual TrackDetail TrackNoNavigation { get; set; } = null!;
    }
}
