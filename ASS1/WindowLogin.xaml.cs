using ASS1;
using BusinessObject.Entity;
using DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace SaleWPFApp
{
    /// <summary>
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        public WindowLogin()
        {
            InitializeComponent();
        }
        MemberDAO login = new MemberDAO();


        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            using(DatabaseContext context = new DatabaseContext())
            {
                //if (txtEmail.Text.Length == 0 && !Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9]@[a-zA-Z0-9]"))
                //{
                //    MessageBox.Show("Enter an Email");
                //    txtEmail.Focus();
                //}
                //if (txtPassword.Password.Length == 0)
                //{
                //    MessageBox.Show("Enter an Password");
                //    txtPassword.Focus();
                //}
                var user = context.Members.FirstOrDefault(x => x.Email == txtEmail.Text && x.Password == txtPassword.Password);
                if(user == null)
                {
                    MessageBox.Show("User not found");
                    txtEmail.Focus();
                    txtPassword.Focus();
                }
                else
                {
                    MainWindow main = new MainWindow();
                    main.Show();
                }
            }
        }

        private void btnClose_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
