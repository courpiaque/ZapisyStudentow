﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ZapisyStudentow.Persistance
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
