using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZapisyStudentow.Models
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _index;
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        private string _fullInfo;
        public string FullInfo
        {
            get { return _name + ", indeks: " + _index; }
            set { _fullInfo = value; }
        }

        private string _subjects;
        public string Subjects
        {
            get { return _subjects; }
            set { _subjects = value; }
        }
    }
}
