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
    /// Логика взаимодействия для StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public StudentWindow()
        {
            InitializeComponent();
            CmbGroupStudent.ItemsSource = ConnectClass.connectDB.Groups.Select(x=>x.NameGroup).ToList();
            CmbDirection.ItemsSource = ConnectClass.connectDB.DirectionOfStudents.Select(x=>x.NameDirection).ToList();
            CmbStatusStudent.ItemsSource = ConnectClass.connectDB.StatusStudents.Select(x=>x.Status).ToList();
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
                Random newRandom = new Random();
                Student dataStudent = new Student()
                {
                    Name = TxbName.Text,
                    Surname = TxbSur.Text,
                    Patronomic = TxbPatr.Text,
                    CodeStudent = newRandom.Next(100,1000),
                    DirectionOfStudentId = CmbDirection.SelectedIndex + 1,
                    StatusStudentId = CmbStatusStudent.SelectedIndex + 1,
                };
                StudentGroup newStudent = new StudentGroup()
                {
                    GroupId = CmbGroupStudent.SelectedIndex + 1,
                    Student = dataStudent,
                };
                ConnectClass.connectDB.StudentGroups.Add(newStudent);
                ConnectClass.connectDB.SaveChanges();
                MessageBox.Show("Данные сохранены!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
