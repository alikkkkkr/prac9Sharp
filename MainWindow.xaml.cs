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

namespace prac9Sharp
{
    // alik.ryzhkova@mail.ru
    // N7xXnksr2S0puC7dufSH

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btn_vxod_Click(object sender, RoutedEventArgs e)
        {
            ImapHelper.Initialize((typePochta_cmbBox.SelectedItem as ComboBoxItem).Tag.ToString());
            if (ImapHelper.Login(pocha_txt.Text, password_txt.Password))
            {
                new Pochta().Show();
                Close();
            }
        }
    }
}
