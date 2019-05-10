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
    public partial class SubjectListPage : ContentPage
    {
        public SubjectListPage(SubjectListViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;

            viewModel._subjectManage = new SQLiteSubjectManage(DependencyService.Get<ISQLiteDb>());
            viewModel._registerManage = new SQLiteRegisterManage(DependencyService.Get<ISQLiteDb>());
        }

        protected override void OnAppearing()
        {
            _viewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }

        private SubjectListViewModel _viewModel
        {
            get { return BindingContext as SubjectListViewModel; }
            set { _viewModel = value; }
        }

        private void SubjectSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _viewModel.SelectSubjectCommand.Execute(e.SelectedItem);
        }
    }
}