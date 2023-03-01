using Microsoft.EntityFrameworkCore;
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
using ООО__Ткани_.Models;
using System.Threading;
using ООО__Ткани_.Windows;

namespace ООО__Ткани_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int i = 0;

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (i != 5)
            {
                if (!string.IsNullOrWhiteSpace(LoginTextBox.Text) && !string.IsNullOrWhiteSpace(PasswordTextBox.Password))
                {

                    User user = TradeNerContext.DbContext.Users.FirstOrDefault(w => w.UserLogin == LoginTextBox.Text && w.UserPassword == PasswordTextBox.Password);
                    if (user != null)
                    {
                        MessageBox.Show($"Вы успешно авторизовались как {user.UserRoleNavigation.RoleName}.",
                            "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);


                        Window nextWindow = new ShowListProducts(user);
                        Hide();
                        nextWindow.ShowDialog();
                        Close();
                        
                    }
                    else
                    {
                        i++;
                        MessageBox.Show("Пожалуйста проверьте данные.", "Предупреждение",
                          MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                }
                else
                {
                    i++;
                    MessageBox.Show("Пожалуйста заполните все поля.", "Предупреждение",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Вы превысили число попыток.\nПодождите 10 сек", "Предупреждение",
                        MessageBoxButton.OK, MessageBoxImage.Warning);

                Title = "Блокировка";

                Thread.Sleep(10 * 1000);
                i = 0;

                Title = "Авторизация";

            }
        }

        private void EnterLikeAGuest_Click(object sender, RoutedEventArgs e)
        {
            Window nextWindow = new ShowListProducts(null);
            Hide();
            nextWindow.ShowDialog();
            Close();
        }
    }
}
