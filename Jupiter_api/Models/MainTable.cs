using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jupiter_api.Models
{
    [Table("Main_Table")]
    public partial class MainTable
    {
        [Column("session_date", TypeName = "date")]
        public DateTime SessionDate { get; set; }
        public int? Module { get; set; }
        [Column("Trainer_id")]
        public int? TrainerId { get; set; }
        [Column("session_start_time")]
        [StringLength(50)]
        [Unicode(false)]
        public string? SessionStartTime { get; set; }
        [Column("Training_mode")]
        [StringLength(15)]
        [Unicode(false)]
        public string? TrainingMode { get; set; }
        [Column("session_location")]
        [StringLength(50)]
        [Unicode(false)]
        public string? SessionLocation { get; set; }
        [Key]
        [Column("session_id")]
        public int SessionId { get; set; }
        [Column("session_end_time")]
        [StringLength(50)]
        [Unicode(false)]
        public string? SessionEndTime { get; set; }
        public int? Track { get; set; }
    }
}
