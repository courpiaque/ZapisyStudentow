using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ZapisyStudentow.ViewModels
{
    public interface IPageService
    {
        Task<bool> DisplayAlertAsync(string title, string massage, string ok, string cancel);
        Task PushModalAsync(Page page);
    }
}
