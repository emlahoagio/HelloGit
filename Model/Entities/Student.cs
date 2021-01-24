using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Entities
{
    [Table("tblStudent")]
    public class Student
    {
        [Key]
        [Column("Id")]
        public int StudentId { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
    }
}
