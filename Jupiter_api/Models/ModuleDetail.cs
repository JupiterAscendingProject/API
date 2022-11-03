using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jupiter_api.Models
{
    [Table("Module_Details")]
    public partial class ModuleDetail
    {
        [Key]
        [Column("Module_No")]
        public int ModuleNo { get; set; }
        [Column("Module_Name")]
        [StringLength(50)]
        [Unicode(false)]
        public string ModuleName { get; set; } = null!;
    }
}
