using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZapisyStudentow.Models
{
    [Table("Registers")]
    public class Register
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
    }
}
