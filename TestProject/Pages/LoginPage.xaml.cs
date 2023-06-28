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
using TestProject.Classes;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnAuto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pass = TxbPass.Text;
                string log = TxbLog.Text;
                if (pass != "" || log!="")
                {
                    var data = ConnectClass.connectDB.Users.FirstOrDefault(x => x.Login == TxbLog.Text);
                    bool verifPass = BCrypt.Net.BCrypt.Verify(pass, data.Password);
                    if(verifPass == true || data != null)
                    {
                        switch (data.StatusId)
                        {
                            case 1:
                                NavigationClass.navigate.Navigate(new MenuPage(data.RoleId));
                                MessageBox.Show("Вход успешен!");
                                break;
                            case 2:
                                MessageBox.Show("Ваш аккаунт заблокирован в системе!\nОбратитесь к зам.директора!");
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ваши данные введены неверно!");
                    }
                }
                else
                {
                    MessageBox.Show("Вы не ввели данные в поля!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка сервера" + ex);
            }
        }
    }
}
