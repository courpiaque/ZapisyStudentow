using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZapisyStudentow.Models;

namespace ZapisyStudentow.ViewModels
{
    public interface ISQLiteManage <T>
    {
        Task<IEnumerable<T>> GetItemAsync();
        Task<T> GetItem(int id);
        Task AddItem(int studentId, int subjectId);
        Task UpdateItem(string name, int id);
        Task<bool> Compare(int studentId, int subjectId);
    }
}
