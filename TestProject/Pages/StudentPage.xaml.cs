using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
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
    /// Логика взаимодействия для StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        public StudentPage()
        {
            InitializeComponent();
            try
            {
                DataGridStudent.ItemsSource = ConnectClass.connectDB.StudentGroups.Include(x => x.Group).Include(x => x.Student).ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка сервера" + ex.Message);
            }
        }

        private void BtnBrindStudentCSV_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var csvContent = new StringBuilder();

                var studentGroups = (List<StudentGroup>)DataGridStudent.ItemsSource;

                csvContent.AppendLine("Имя студента, фамилие студента, отчество студента, наименование группы,");

                foreach (var studentGroup in studentGroups)
                {
                    csvContent.AppendLine($"{studentGroup.Student.Name}, {studentGroup.Student.Surname}, {studentGroup.Student.Patronomic}, {studentGroup.Group.NameGroup}");
                }

                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "Студенты.csv";
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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationClass.navigate.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
            }
        }

        private void BtnBrindStudentXLS_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                var studentGroups = (List<StudentGroup>)DataGridStudent.ItemsSource;

                ExcelPackage excel = new ExcelPackage();
                var worksheet = excel.Workbook.Worksheets.Add("Студенты");

                worksheet.Cells[1, 1].Value = "Имя студента";
                worksheet.Cells[1, 2].Value = "Фамилия студента";
                worksheet.Cells[1, 3].Value = "Отчество студента";
                worksheet.Cells[1, 4].Value = "Код студента";
                worksheet.Cells[1, 5].Value = "Наименование группы";

                for (int i = 0; i < studentGroups.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = studentGroups[i].Student.Name;
                    worksheet.Cells[i + 2, 2].Value = studentGroups[i].Student.Surname;
                    worksheet.Cells[i + 2, 3].Value = studentGroups[i].Student.Patronomic;
                    worksheet.Cells[i + 2, 4].Value = studentGroups[i].Student.CodeStudent;
                    worksheet.Cells[i + 2, 5].Value = studentGroups[i].Group.NameGroup;
                }

                worksheet.Cells["A1:D1"].Style.Font.Bold = true;
                worksheet.Cells["A1:D1"].AutoFitColumns();

                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "Студенты.xlsx";
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

        private void BtnNameFilter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPostStudent_Click(object sender, RoutedEventArgs e)
        {
            StudentWindow newWindow = new StudentWindow();
            newWindow.ShowDialog();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGridStudent.SelectedItem != null)
                {
                    var studentGroup = (StudentGroup)DataGridStudent.SelectedItem;
                    ConnectClass.connectDB.StudentGroups.Remove(studentGroup);
                    ConnectClass.connectDB.SaveChanges();
                    DataGridStudent.ItemsSource = ConnectClass.connectDB.StudentGroups.Include(x => x.Group).Include(x => x.Student).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}");
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGridStudent.ItemsSource = ConnectClass.connectDB.StudentGroups.Include(x=>x.Group).Include(x=>x.Student).ToList();
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

            var filteredStudentGroups = ConnectClass.connectDB.StudentGroups
                .Include(x => x.Group)
                .Include(x => x.Student)
                .Where(studentGroup =>
                    studentGroup.Student.Name.ToLower().Contains(searchKeyword) ||
                    studentGroup.Student.Surname.ToLower().Contains(searchKeyword) ||
                    studentGroup.Student.Patronomic.ToLower().Contains(searchKeyword) ||
                    studentGroup.Group.NameGroup.ToLower().Contains(searchKeyword))
                .ToList();

            DataGridStudent.ItemsSource = filteredStudentGroups;
        }
    }
}
