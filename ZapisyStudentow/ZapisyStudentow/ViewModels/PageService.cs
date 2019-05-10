using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ZapisyStudentow.ViewModels
{
    class PageService : IPageService
    {
        public async Task<bool> DisplayAlertAsync(string title, string massage, string ok, string cancel)
        {
            return await App.Current.MainPage.DisplayAlert(title, massage, ok, cancel);
        }

        public async Task PushModalAsync(Page page)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(page);
        }
    }
}
