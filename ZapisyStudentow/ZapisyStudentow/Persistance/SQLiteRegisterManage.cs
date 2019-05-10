using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZapisyStudentow.Models;
using ZapisyStudentow.ViewModels;

namespace ZapisyStudentow.Persistance
{
    class SQLiteRegisterManage : ISQLiteManage<Register>
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteRegisterManage(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Register>();
        }
        public async Task AddItem(int studentId, int subjectId)
        {
            await _connection.InsertAsync(new Register { StudentId = studentId, SubjectId = subjectId });
        }

        public async Task<bool> Compare(int studentId, int subjectId)
        {
            var register = await _connection.QueryAsync<Register>("SELECT * FROM Registers WHERE StudentId = ? AND SubjectId = ?", new string[2]{ studentId.ToString(), subjectId.ToString() });
            if(register.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<Register> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Register>> GetItemAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateItem(string name, int id)
        {
            throw new NotImplementedException();
        }
    }
}
