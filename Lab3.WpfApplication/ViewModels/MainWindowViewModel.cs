using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab2.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab3.WpfApplication.ViewModels
{
    public class MainWindowViewModel : ObservableObject, INotifyPropertyChanged
    {

        private DepartmentDbContext _db;

        public MainWindowViewModel()
        {
            _db = new DepartmentDbContext();
            SelectDepartmentComand = new RelayCommand(LoadEmployees);
            SearchCommand = new RelayCommand(FilterData);
        }

        private Department[] _departments;

        public Department[] Departments => _departments;

        public void Load()
        {
            _departments = _db.Departments.ToArray();
        }

        private List<Employee> _Employees=new List<Employee>();

        public List<Employee> Employees
        {
            get
            {
                return _Employees;
            }
            set
            {
                _Employees = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public void LoadEmployees()
        {
            if (SelectedDepartment == null)
            {
                return;
            }

            Employees = _db.Employees.Where(o => o.Department.Id == SelectedDepartment.Id).ToList();
        }
        public Department SelectedDepartment { get; set; }
        public ICommand SelectDepartmentComand { get; }

        public ICommand SearchCommand { get; }

        public void FilterData()
        {
            
        }
    }
}
