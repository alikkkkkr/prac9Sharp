using ImapX;
using ImapX.Collections;
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
using System.Windows.Shapes;

namespace prac9Sharp
{
    // alik.ryzhkova@mail.ru
    // N7xXnksr2S0puC7dufSH

    /// <summary>
    /// Логика взаимодействия для Pochta.xaml
    /// </summary>
    public partial class Pochta : Window
    {
        private CommonFolderCollection folders = ImapHelper.GetFolders();
        private List<string> nameFolders = new List<string>();
        private List<string> nameMessage = new List<string>();
        MessageCollection messages;
        
        public Pochta()
        {
            InitializeComponent();

            FoldersOut();
        }

        private void FoldersOut()
        {
            foreach (var folder in folders)
            {
                //выгрузка папок в лист на окно
                //listFolders.ItemsSource = folder.Name;
                nameFolders.Add(folder.Name);
            }
            listFolders.ItemsSource = nameFolders;
        }

        private void MessageOut()
        {
            nameMessage.Clear();
            listMessage.ItemsSource = "";
            messages = ImapHelper.GetMessagesForFolder(listFolders.SelectedItem.ToString());
            foreach (var message in messages)
            {
                nameMessage.Add(message.From.Address.ToString());
            }
            listMessage.ItemsSource = nameMessage;
        }

        private void writenewmessage_Click(object sender, RoutedEventArgs e)
        {
            new WriteMessage().Show();
        }

        private void listFolders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageCollection messages = ImapHelper.GetMessagesForFolder(folder);
            //foreach (var message in messages){}

            MessageOut();
        }
        private void listMessage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
