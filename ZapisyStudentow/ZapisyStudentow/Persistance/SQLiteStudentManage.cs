using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZapisyStudentow.Models;
using ZapisyStudentow.ViewModels;
using SQLite;

namespace ZapisyStudentow.Persistance
{
    class SQLiteStudentManage : ISQLiteManage <Student>
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteStudentManage(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Student>();
        }
        public async Task AddItem(int id, int idx)
        {

        }

        public Task<bool> Compare(int studentId, int subjectId)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> GetItem(int id)
        {
            return await _connection.FindAsync<Student>(id);
        }

        public async Task<IEnumerable<Student>> GetItemAsync()
        {
            var check = await _connection.Table<Student>().CountAsync();

            if (check == 0)
            {
                await _connection.InsertAsync(new Student { Id=1, Name = "Jan Kowalski", Index = 736723 });
                await _connection.InsertAsync(new Student { Id=2, Name = "Adam Nowak", Index = 236534 });
                await _connection.InsertAsync(new Student { Id=3, Name = "Ania Krzemińska", Index = 958234 });
            }

            return await _connection.Table<Student>().ToListAsync();
        }

        public async Task UpdateItem(string name, int id)
        {
            var student = await GetItem(id);
            await _connection.InsertOrReplaceAsync(new Student { Id = student.Id, Name = student.Name, Index = student.Index, Subjects = student.Subjects + name + ", " });
        }
    }
}
