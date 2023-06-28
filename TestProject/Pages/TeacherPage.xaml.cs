using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
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
using TestProject.Models;
using TestProject.Pages.PostWindow;

namespace TestProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        public TeacherPage()
        {
            InitializeComponent();
            DataGridTeacher.ItemsSource = ConnectClass.connectDB.SubjectTeachers.Include(x => x.Teacher).Include(x=>x.Subject).Include(x=>x.Teacher.User).Include(x=>x.Teacher.User.Role).ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.navigate.GoBack();
        }

        private void BtnPostTeacher_Click(object sender, RoutedEventArgs e)
        {
            TeacherWindow teacher = new TeacherWindow();
            teacher.ShowDialog();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGridTeacher.SelectedItem != null)
                {
                    var subjectTeacher = (SubjectTeacher)DataGridTeacher.SelectedItem;
                    ConnectClass.connectDB.SubjectTeachers.Remove(subjectTeacher);
                    ConnectClass.connectDB.SaveChanges();
                    DataGridTeacher.ItemsSource = ConnectClass.connectDB.SubjectTeachers.Include(x => x.Teacher).Include(x => x.Subject).Include(x => x.Teacher.User).Include(x => x.Teacher.User.Role).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}");
            }
        }

        private void BtnBrindTeacherCSV_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var csvContent = new StringBuilder();

                var teacherGroups = (List<SubjectTeacher>)DataGridTeacher.ItemsSource;

                csvContent.AppendLine("Наименование предмета, Имя сотрудника, Фамилия сотрудника, Отчество сотрудника, Должность");

                foreach (var teacherGroup in teacherGroups)
                {
                    csvContent.AppendLine($"{teacherGroup.Subject.NameSubject}, {teacherGroup.Teacher.Name}, {teacherGroup.Teacher.Surname}, {teacherGroup.Teacher.Patronomic}, {teacherGroup.Teacher.User.Role.NameRole}");
                }

                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "Учителя.csv";
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";

                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, csvContent.ToString());
                    MessageBox.Show("Данные успешно сохранены в файл.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void BtnBrindTeacherXLS_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                var studentGroups = (List<SubjectTeacher>)DataGridTeacher.ItemsSource;

                ExcelPackage excel = new ExcelPackage();
                var worksheet = excel.Workbook.Worksheets.Add("Сотрудники");

                worksheet.Cells[1, 1].Value = "Имя сотрудника";
                worksheet.Cells[1, 2].Value = "Фамилия сотрудника";
                worksheet.Cells[1, 3].Value = "Отчество сотрудника";
                worksheet.Cells[1, 4].Value = "Код сотрудника";
                worksheet.Cells[1, 5].Value = "Наименование предмета";
                worksheet.Cells[1, 6].Value = "Наименование должности";
                for (int i = 0; i < studentGroups.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = studentGroups[i].Teacher.Name;
                    worksheet.Cells[i + 2, 2].Value = studentGroups[i].Teacher.Surname;
                    worksheet.Cells[i + 2, 3].Value = studentGroups[i].Teacher.Patronomic;
                    worksheet.Cells[i + 2, 4].Value = studentGroups[i].Teacher.CodeTeacher;
                    worksheet.Cells[i + 2, 5].Value = studentGroups[i].Subject.NameSubject;
                    worksheet.Cells[i + 2, 6].Value = studentGroups[i].Teacher.User.Role.NameRole;
                }

                worksheet.Cells["A1:D1"].Style.Font.Bold = true;
                worksheet.Cells["A1:D1"].AutoFitColumns();

                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "Сотрудники.xlsx";
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";

                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllBytes(saveFileDialog.FileName, excel.GetAsByteArray());
                    MessageBox.Show("Данные успешно сохранены в файл.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGridTeacher.ItemsSource = ConnectClass.connectDB.SubjectTeachers.Include(x => x.Teacher).Include(x => x.Subject).Include(x => x.Teacher.User).Include(x => x.Teacher.User.Role).ToList();
                MessageBox.Show("Обновлено");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchKeyword = TxbSearch.Text.ToLower();

            var filteredTeacherGroups = ConnectClass.connectDB.SubjectTeachers
                .Include(x => x.Teacher)
                .Include(x => x.Subject)
                .Include(x => x.Teacher.User)
                .Include(x => x.Teacher.User.Role)
                .Where(teacherGroup =>
                    teacherGroup.Subject.NameSubject.ToLower().Contains(searchKeyword) ||
                    teacherGroup.Teacher.Name.ToLower().Contains(searchKeyword) ||
                    teacherGroup.Teacher.Surname.ToLower().Contains(searchKeyword) ||
                    teacherGroup.Teacher.Patronomic.ToLower().Contains(searchKeyword) ||
                    teacherGroup.Teacher.User.Role.NameRole.ToLower().Contains(searchKeyword))
                .ToList();

            DataGridTeacher.ItemsSource = filteredTeacherGroups;
        }
    }
}
