using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZapisyStudentow.Models
{
    public class Subject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Students { get; set; }
    }
}
