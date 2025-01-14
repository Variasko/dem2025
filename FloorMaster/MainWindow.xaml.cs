using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FloorMaster
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MasterFloorEntities _context = new MasterFloorEntities().GetContext();

        private List<Staff> _staffs;

        public MainWindow()
        {
            InitializeComponent();
            _staffs = _context.Staff.ToList();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginEnter.Text;
            string password = PasswordEnter.Password;

            Authorization(login, password);
        }

        private void Authorization(string login, string password)
        {
            var manager = _staffs.Find(s=> s.login == login && s.password == password);

            if (manager != null && manager.roleId == 1)
            {
                new ManagerMainWindow().Show();
                Close();
            }
            else
            {
                MessageBox.Show("У вас нет доступа к приложению!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
