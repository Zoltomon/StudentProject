using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.Windows.Data;
using System.IO;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestProject.Classes;
using TestProject.Models;
using System.IO;
using NPOI.SS.UserModel;
using Path = System.IO.Path;

namespace TestProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для GradeStudentPage.xaml
    /// </summary>
    public partial class GradeStudentPage : Page
    {
        public GradeStudentPage()
        {
            InitializeComponent();
            try
            {
                DataGridGrade.ItemsSource = ConnectClass.connectDB.GradeStudents.Include(x=>x.Student).Include(x=>x.Subject).ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.navigate.GoBack();
        }

        private void BtnGradeXLS_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                var studentGroups = (List<GradeStudent>)DataGridGrade.ItemsSource;

                ExcelPackage excel = new ExcelPackage();
                var worksheet = excel.Workbook.Worksheets.Add("Оценки");

                worksheet.Cells[1, 1].Value = "Имя студента";
                worksheet.Cells[1, 2].Value = "Фамилия студента";
                worksheet.Cells[1, 3].Value = "Отчество студента";
                worksheet.Cells[1, 4].Value = "Код студента";
                worksheet.Cells[1, 5].Value = "Наименование предмета";
                worksheet.Cells[1, 6].Value = "Оценка";
                for (int i = 0; i < studentGroups.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = studentGroups[i].Student.Name;
                    worksheet.Cells[i + 2, 2].Value = studentGroups[i].Student.Surname;
                    worksheet.Cells[i + 2, 3].Value = studentGroups[i].Student.Patronomic;
                    worksheet.Cells[i + 2, 4].Value = studentGroups[i].Student.CodeStudent;
                    worksheet.Cells[i + 2, 5].Value = studentGroups[i].Subject.NameSubject;
                    worksheet.Cells[i + 2, 6].Value = studentGroups[i].ScaleGrade;
                }

                worksheet.Cells["A1:D1"].Style.Font.Bold = true;
                worksheet.Cells["A1:D1"].AutoFitColumns();

                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "Оценки.xlsx";
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

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGridGrade.ItemsSource = ConnectClass.connectDB.GradeStudents.Include(x => x.Student).Include(x => x.Subject).ToList();
                MessageBox.Show("Обновлено");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnGrade_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var openFileWindow = new OpenFileDialog();
                openFileWindow.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";

                if(openFileWindow.ShowDialog() == true)
                {
                    string filePath = openFileWindow.FileName;
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        HSSFWorkbook workbook = new HSSFWorkbook(fileStream);
                        ISheet sheet = workbook.GetSheetAt(0);

                        for (int rowNum = 1; rowNum <= sheet.LastRowNum; rowNum++)
                        {
                            IRow row = sheet.GetRow(rowNum);

                            string name = row.GetCell(0)?.ToString();
                            string surname = row.GetCell(1)?.ToString();
                            string patronomic = row.GetCell(2)?.ToString();
                            int codeStudent = (int)row.GetCell(3).NumericCellValue;
                            string nameSubject = row.GetCell(4)?.ToString();
                            double? scaleGrade = row.GetCell(5)?.NumericCellValue;
                            string nameDirectionStudent = row.GetCell(6)?.ToString();
                            string codeDirectionStudent = row.GetCell(7)?.ToString();
                            string statusStudent = row.GetCell(8)?.ToString();
                            string subjectStudent = row.GetCell(9)?.ToString();

                            GradeStudent gradeStudent = new GradeStudent
                            {
                                Student = new Student
                                {
                                    Name = name,
                                    Surname = surname,
                                    Patronomic = patronomic,
                                    CodeStudent = codeStudent
                                },
                                Subject = new Subject
                                {
                                    NameSubject = nameSubject
                                },
                                ScaleGrade = scaleGrade
                            };

                        }
                        MessageBox.Show("Файл импортирован");
                        DataGridGrade.ItemsSource = ConnectClass.connectDB.GradeStudents.Include(x => x.Student).Include(x => x.Subject).ToList();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
