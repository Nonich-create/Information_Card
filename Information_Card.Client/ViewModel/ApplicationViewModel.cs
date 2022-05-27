using Information_Card.Client.Model;
using Information_Card.Client.Services;
using Information_Card.Client.Services.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Information_Card.Client.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Employee selectedEmployee;
        private readonly ICallApiService<Employee> _callApiService;
        public IAsyncCommand LoadData { get; private set; }
        public IAsyncCommand SaveCommand { get; private set; }
        public IAsyncCommand UpdateCommand { get; private set; }
        public IAsyncCommand DeleteCommand { get; private set; }

        private ObservableCollection<Employee> _jobs;
        public ObservableCollection<Employee> Employees
        {
            get { return _jobs; }
            private set
            {
                _jobs = value;
                OnPropertyChanged();
            }
        }

        public ApplicationViewModel(ICallApiService<Employee> callApiService)
        {
            _callApiService = callApiService;

            LoadData = new AsyncCommand(async () =>
            {
                Employees = await _callApiService.GetAllAsync("/api/EmployeeAPI");
  
            }); 

            SaveCommand = new AsyncCommand(async () =>
            {
                if (selectedEmployee.isValid() == true)
                {
                    await _callApiService.PostAsync("/api/EmployeeAPI", selectedEmployee);
                    Employees = await _callApiService.GetAllAsync("/api/EmployeeAPI");
                }
                else
                {
                    MessageBox.Show("Есть пустые поля");
                }
            });

            UpdateCommand = new AsyncCommand(async () =>
            {
                if (selectedEmployee.isValid() == true)
                {
                    await _callApiService.PutAsync("/api/EmployeeAPI", selectedEmployee);
                    Employees = await _callApiService.GetAllAsync("/api/EmployeeAPI");
                }
                else
                {
                    MessageBox.Show("Есть пустые поля");
                }
            });

            DeleteCommand = new AsyncCommand(async () =>
            {
                    await _callApiService.DeleteAsync("/api/EmployeeAPI", selectedEmployee);
                    Employees = await _callApiService.GetAllAsync("/api/EmployeeAPI");
            });
             

        }
        private AsyncCommand _addCommand;
        public AsyncCommand AddCommand
        {
            get
            {
                return _addCommand ??
                       (_addCommand = new AsyncCommand(async () =>
                       {
                           if (Employees == null)
                           {
                               Employees = new ObservableCollection<Employee>();
                           }
                           Employee employee = new Employee();
                           Employees.Insert(0, employee);
                           SelectedEmployee = employee;

                       }));
            }
        }

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
