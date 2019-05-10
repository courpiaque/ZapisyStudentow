using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZapisyStudentow.Models;
using ZapisyStudentow.Persistance;

namespace ZapisyStudentow.ViewModels
{
    public class SubjectListViewModel : BaseViewModel
    {
        private readonly IPageService _pageService;
        public ISQLiteManage<Subject> _subjectManage { get; set; }
        public ISQLiteManage<Register> _registerManage { get; set; }
        private ISQLiteManage<Student> _studentManage;

        private bool _isLoaded = false;
        private Subject _selectedSubject;
        private Student _student;

        public ObservableCollection<Subject> Subjects { get; private set; } = new ObservableCollection<Subject>();

        public Subject SelectedSubject
        {
            get { return _selectedSubject; }
            set { SetValue(ref _selectedSubject, value); }
        }

        public ICommand SelectSubjectCommand { get; private set; }
        public ICommand LoadDataCommand { get; private set; }

        public SubjectListViewModel(Student student, IPageService pageService, ISQLiteManage<Student> studentManage)
        {
            _pageService = pageService;
            _student = student;
            _studentManage = studentManage;

            SelectSubjectCommand = new Command<Subject>(async vm => await SelectItem(vm));
            LoadDataCommand = new Command(async () => await LoadData());
        }

        private async Task LoadData()
        {
            if (_isLoaded)
                return;

            _isLoaded = true;

            var students = await _subjectManage.GetItemAsync();

            foreach (var s in students)
                Subjects.Add(s);
        }

        private async Task SelectItem(Subject subject)
        {
            if (subject == null)
                return;

            SelectedSubject = null;

            if (await _registerManage.Compare(_student.Id, subject.Id))
            { 
                var display = await _pageService.DisplayAlertAsync("Potwierdź działanie",
                "Czy napewno chcesz zapisać studenta " + _student.Name + " na wybrany przedmiot?", "Tak", "Nie");

                if (display)
                {
                    await _registerManage.AddItem(_student.Id, subject.Id);
                    await _studentManage.UpdateItem(subject.Name, _student.Id);
                }
            }
            else await _pageService.DisplayAlertAsync("Komunikat", "Wybrany student jest już zapisany na ten przedmiot", null, "OK");
        }
    }
}
