using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jupiter_api.Models
{
    [Table("Track_Details")]
    public partial class TrackDetail
    {
        [Key]
        [Column("Track_No")]
        public int TrackNo { get; set; }
        [Column("Track_Name")]
        [StringLength(50)]
        [Unicode(false)]
        public string TrackName { get; set; } = null!;
    }
}
