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
        [Key]
        [Column("Session_id")]
        public int SessionId { get; set; }
        [Column("Session_date", TypeName = "datetime")]
        public DateTime? SessionDate { get; set; }
        public int? Module { get; set; }
        [Column("Trainer_id")]
        public int? TrainerId { get; set; }
        [Column("Training_mode")]
        [StringLength(20)]
        [Unicode(false)]
        public string? TrainingMode { get; set; }
        [Column("Session_location")]
        [StringLength(50)]
        [Unicode(false)]
        public string? SessionLocation { get; set; }
        public int? Track { get; set; }
        [Column("Session_start_time", TypeName = "datetime")]
        public DateTime? SessionStartTime { get; set; }
        [Column("Session_end_time", TypeName = "datetime")]
        public DateTime? SessionEndTime { get; set; }
    }
}
