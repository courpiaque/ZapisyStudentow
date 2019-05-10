using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZapisyStudentow.Persistance;
using ZapisyStudentow.ViewModels;

namespace ZapisyStudentow.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentListPage : ContentPage
    {
        public StudentListPage()
        {
            var pageService = new PageService();
            var studentManage = new SQLiteStudentManage(DependencyService.Get<ISQLiteDb>());

            ViewModel = new StudentListPageViewModel(pageService, studentManage);

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            ViewModel.UnLoadDataCommand.Execute(null);
            base.OnDisappearing();
        }

        private void StudentSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectStudentCommand.Execute(e.SelectedItem);
        }

        private StudentListPageViewModel ViewModel
        {
            get { return BindingContext as StudentListPageViewModel; }
            set { BindingContext = value; }
        }
    }
}