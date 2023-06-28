using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestProject.Classes;
using TestProject.Models;

namespace TestProject.Pages.PostWindow
{
    /// <summary>
    /// Логика взаимодействия для TeacherWindow.xaml
    /// </summary>
    public partial class TeacherWindow : Window
    {
        public TeacherWindow()
        {
            InitializeComponent();
            CmbRole.ItemsSource = ConnectClass.connectDB.Roles.Select(x=>x.NameRole).ToList();
            CmbSub.ItemsSource = ConnectClass.connectDB.Subjects.Select(x=>x.NameSubject).ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!Regex.IsMatch(TxbName.Text, @"^[А-Яа-я]+$"))
                {
                    MessageBox.Show("Имя должно содержать только русские буквы!");
                    return;
                }

                if (!Regex.IsMatch(TxbSur.Text, @"^[А-Яа-я]+$"))
                {
                    MessageBox.Show("Фамилия должна содержать только русские буквы!");
                    return;
                }

                if (!Regex.IsMatch(TxbPatr.Text, @"^[А-Яа-я]+$"))
                {
                    MessageBox.Show("Отчество должно содержать только русские буквы!");
                    return;
                }
                if (TxbLog.Text != "" && TxbPass.Text != "")
                {
                    Random rnd = new Random();
                    string hashPass = BCrypt.Net.BCrypt.HashPassword(TxbPass.Text);
                    User newUser = new User()
                    {
                        Login = TxbLog.Text,
                        Password = hashPass,
                        StatusId = 1,
                        IdentificateCode = rnd.Next(100, 1000),
                        RoleId = CmbRole.SelectedIndex + 1
                    };
                    Teacher newTeacher = new Teacher()
                    {
                        Name = TxbName.Text,
                        Surname = TxbSur.Text,
                        Patronomic = TxbPatr.Text,
                        CodeTeacher = rnd.Next(100, 1000),
                        User = newUser
                    };
                    SubjectTeacher newSubTeacher = new SubjectTeacher()
                    {
                        Teacher = newTeacher,
                        SubjectId = CmbSub.SelectedIndex + 1
                    };
                    ConnectClass.connectDB.SubjectTeachers.Add(newSubTeacher);
                    ConnectClass.connectDB.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены!");
                }
                else
                {
                    MessageBox.Show("Пустые поля!");
                }   
                  
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка "+ ex.Message);
            }
        }
    }
}
