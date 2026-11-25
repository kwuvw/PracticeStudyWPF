using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.SqlClient;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using static Shop.Data.Database;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Shop.Data;

namespace Shop
{

    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void SignInLoginButton(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();

            try
            {
                if (Database.LoginExists(login))
                    NavigationService.Navigate(new Page2());
                else
                {
                    MessageBox.Show("Такого логина нет, попробуйте еще раз");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
