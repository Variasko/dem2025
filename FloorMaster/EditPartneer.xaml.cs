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
using System.Windows.Shapes;

namespace FloorMaster
{
    /// <summary>
    /// Логика взаимодействия для EditPartneer.xaml
    /// </summary>
    public partial class EditPartneer : Window
    {
        public EditPartneer(string partneerId)
        {
            InitializeComponent();
            MessageBox.Show(partneerId);
        }

        private void AddLogoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
