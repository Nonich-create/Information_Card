using Information_Card.Client.Model;
using Information_Card.Client.Services;
using Information_Card.Client.ViewModel;
using System.Windows;


namespace Information_Card.Client.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public  MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel(new CallApiService<Employee>());
        }
    }
}
