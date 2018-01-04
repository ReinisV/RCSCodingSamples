using System;
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

namespace BuyList
{
    using System.Collections.ObjectModel;
    using System.IO;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> BuyItemsList = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            
            this.BuyItemsList.Add("āboli 300g");
            this.BuyItemsList.Add("bumbieri");

            // pasakam BuyItemsListControl, ka jāizmanto mūsu saraksts,
            // kā rādāmo lietu avots (jaskatās no saraksta, ko rādīt)
            this.BuyItemsListControl.ItemsSource = this.BuyItemsList;
        }

        private void AddListItemButton_OnClick(object sender, RoutedEventArgs e)
        {
            // izvelkam vērtību no teksta lauka
            string enteredItemToBuy = this.BuyListItemName.Text;

            // nodzēšam vērtību teksta laukā
            this.BuyListItemName.Text = "";

            // ierakstam iegūto vērtību teksta blokā
            this.BuyItemsList.Add(enteredItemToBuy);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllLines(@"C:\mans_fails.txt", this.BuyItemsList);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var todosFromFile = File.ReadAllLines(@"C:\mans_fails.txt");

            foreach (string currentTodo in todosFromFile)
            {
                this.BuyItemsList.Add(currentTodo);
            }

            MessageBox.Show("all items have been loaded");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var selectedItems = this.BuyItemsListControl.SelectedItems;

            for (int i = 0; i < selectedItems.Count; i++)
            {
                var selectedItem = selectedItems[i] as string;
                this.BuyItemsList.Remove(selectedItem);
            }
        }
    }
}
