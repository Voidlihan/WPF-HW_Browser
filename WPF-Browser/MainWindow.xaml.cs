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

namespace WPF_Browser
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
        private void TabControlLoad(object sender, RoutedEventArgs e)
        {
            tabControl = (sender as TabControl);
        }
        TabItem Tabitem;

        private void Search(object sender, RoutedEventArgs e)
        {
            try
            {
                WebBrowser browser = new WebBrowser();
                browser.Navigate(search.Text);

                Tabitem = new TabItem
                {
                    Height = 30,
                    Width = 90,
                    Header = "UrlTab",
                    Content = (browser as WebBrowser)
                };

                Tabitem.MouseDoubleClick += TabMouseDoubleClick;

                tabControl.Items.Add(Tabitem);

                Tabitem.IsSelected = true;

                search.Text = "";
            }
            catch
            {
                MessageBox.Show("Введен неверный URL адрес");
            }
        }

        private void TabMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tabControl.Items.Remove(tabControl.SelectedItem);
        }
    }
}
