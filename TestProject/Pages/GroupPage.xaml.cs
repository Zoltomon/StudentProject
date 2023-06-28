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
using TestProject.Classes;
using TestProject.Pages.PostWindow;

namespace TestProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для GroupPage.xaml
    /// </summary>
    public partial class GroupPage : Page
    {
        public GroupPage()
        {
            InitializeComponent();
            DataGridGroup.ItemsSource = ConnectClass.connectDB.Groups.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.navigate.GoBack();
        }

        private void BtnPostGroup_Click(object sender, RoutedEventArgs e)
        {
            GroupWindow groupWindow = new GroupWindow();
            groupWindow.ShowDialog();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGridGroup.ItemsSource = ConnectClass.connectDB.Groups.ToList();
                MessageBox.Show("Обновлено");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
