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
using TestProject.Classes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        private int _role;
        public MenuPage(int role)
        {
            InitializeComponent();
            _role = role;
            visinilityButtonRole(_role);
        }
        private void visinilityButtonRole(int role) 
        {
            switch(_role)
            {
                case 1:
                    BtnGradeStudent.Visibility = Visibility.Visible;
                    BtnGroup.Visibility = Visibility.Visible;
                    BtnLessons.Visibility = Visibility.Visible;
                    BtnTeacher.Visibility = Visibility.Visible;
                    BtnStudent.Visibility = Visibility.Visible;
                    break;
                case 2:
                    BtnGradeStudent.Visibility = Visibility.Visible;
                    BtnGroup.Visibility = Visibility.Visible;
                    BtnLessons.Visibility = Visibility.Visible;
                    BtnTeacher.Visibility = Visibility.Collapsed;
                    BtnStudent.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void BtnStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationClass.navigate.Navigate(new StudentPage());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }

        private void BtnTeacher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationClass.navigate.Navigate(new TeacherPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }

        private void BtnLessons_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationClass.navigate.Navigate(new GroupPage());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }

        private void BtnGradeStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationClass.navigate.Navigate(new GradeStudentPage());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationClass.navigate.Navigate(new LoginPage());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
