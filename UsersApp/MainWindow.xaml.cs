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

namespace UsersApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		
		 ApplicationContext db;
		
		
		public MainWindow()
		{
			InitializeComponent();

			db = new ApplicationContext();
		}

		private void Button_Reg_Click(object sender, RoutedEventArgs e)
		{
			string login = loginBox.Text.Trim();
			string pass = passwordBox.Password.Trim();
			string pass_2 = passwordBox_2.Password.Trim();
			string email = emailBox.Text.Trim().ToLower();

			// проверка на корректность

			 if(login.Length < 5)
			{
				loginBox.ToolTip = "Поле заполнено некорректно";
				loginBox.Background = Brushes.LightCoral;
			}
			 else if(pass.Length < 5)
			{
				passwordBox.ToolTip = "Поле заполнено некорректно";
				passwordBox.Background = Brushes.LightCoral;
			}
			else if (pass_2 != pass)
			{
				passwordBox_2.ToolTip = "Поле заполнено некорректно";
				passwordBox_2.Background = Brushes.LightCoral;
			}
			else if(email.Length < 5 || !email.Contains('@') || !email.Contains('.'))
			{
				emailBox.ToolTip = "Поле заполнено некорректно";
				emailBox.Background = Brushes.LightCoral;
			}
            else
            {
				loginBox.ToolTip = "";
				loginBox.Background = Brushes.Transparent;
				passwordBox.ToolTip = "";
				passwordBox.Background = Brushes.Transparent;
				passwordBox_2.ToolTip = "";
				passwordBox_2.Background = Brushes.Transparent;
				emailBox.ToolTip = "";
				emailBox.Background = Brushes.Transparent;

				MessageBox.Show("OK");
				User user = new User(login, pass, email);

				db.Users.Add(user);
				db.SaveChanges();
			}
        }

    }
}
