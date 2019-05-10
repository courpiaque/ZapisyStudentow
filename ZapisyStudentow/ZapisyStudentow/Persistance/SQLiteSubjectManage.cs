using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZapisyStudentow.Models;
using ZapisyStudentow.ViewModels;

namespace ZapisyStudentow.Persistance
{
    public class SQLiteSubjectManage : ISQLiteManage<Subject>
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteSubjectManage(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Subject>();
        }

        public Task AddItem(int studentId, int subjectId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Compare(int studentId, int subjectId)
        {
            throw new NotImplementedException();
        }

        public async Task<Subject> GetItem(int id)
        {
            return await _connection.FindAsync<Subject>(id);
        }

        public async Task<IEnumerable<Subject>> GetItemAsync()
        {
            var check = await _connection.Table<Subject>().CountAsync();

            if (check == 0)
            {
                await _connection.InsertAsync(new Subject { Id = 1, Name = "Programowanie" });
                await _connection.InsertAsync(new Subject { Id = 2, Name = "Bazy danych" });
                await _connection.InsertAsync(new Subject { Id = 3, Name = "Rachunek prawdopodobieństwa" });
            }

            return await _connection.Table<Subject>().ToListAsync();
        }

        public Task UpdateItem(string name, int id)
        {
            throw new NotImplementedException();
        }
    }
}
