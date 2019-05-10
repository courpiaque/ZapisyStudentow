using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZapisyStudentow.Models;
using ZapisyStudentow.Persistance;
using ZapisyStudentow.Views;

namespace ZapisyStudentow.ViewModels
{
    public class StudentListPageViewModel : BaseViewModel
    {
        private readonly IPageService _pageService;
        private readonly ISQLiteManage<Student> _studentManage;
        private Student _selectedStudent;
        private bool _isLoaded = false;

        public ObservableCollection<Student> Students { get; private set; } = new ObservableCollection<Student>();
        

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set { SetValue(ref _selectedStudent, value); }
        }

        public ICommand SelectStudentCommand { get; private set; }
        public ICommand LoadDataCommand { get; private set; }
        public ICommand UnLoadDataCommand { get; private set; }

        public StudentListPageViewModel(IPageService pageService, ISQLiteManage<Student> studentManage)
        {
            _pageService = pageService;
            _studentManage = studentManage;         

            SelectStudentCommand = new Command<Student>(async vm => await SelectItem(vm));
            LoadDataCommand = new Command(async () => await LoadData());
            UnLoadDataCommand = new Command(UnLoadData);
        }

        private async Task LoadData()
        {
            if (_isLoaded)
                return;

            _isLoaded = true;

            var students = await _studentManage.GetItemAsync();

            foreach (var s in students)
                Students.Add(s);
                
        }

        private void UnLoadData()
        {
            Students.Clear();
            _isLoaded = false;

        }

        private async Task SelectItem(Student student)
        {
            if (student == null)
                return;

            SelectedStudent = null;

            var viewModel = new SubjectListViewModel(student, _pageService, _studentManage);

            await _pageService.PushModalAsync(new SubjectListPage(viewModel));
        }
    }
}
