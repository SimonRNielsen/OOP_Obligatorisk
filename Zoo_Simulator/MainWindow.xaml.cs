using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Zoo_Simulator;


namespace Zoo_Simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Tiger> TigerCageList { get; set; }
        public ObservableCollection<Parrot> AviaryList { get; set; }
        public ObservableCollection<Monkey> MonkeyCageList { get; set; }
        public ObservableCollection<Zookeeper> Zookeepers { get; set; }
        public List<Food> FoodStorage { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            TigerCageList = new ObservableCollection<Tiger>();
            AviaryList = new ObservableCollection<Parrot>();
            MonkeyCageList = new ObservableCollection<Monkey>();
            Zookeepers = new ObservableCollection<Zookeeper>();
            FoodStorage = new List<Food>();
        }

        private void UpdateInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            Zookeepers[0] = new Zookeeper();
            Zookeeper selectedZookeeper = Zookeepers[0];
            if (selectedZookeeper == null)
            {
                TextOutput.Text = "No zookeeper selected for the job";
            }
            else
            {
                selectedZookeeper.FoodInventory(FoodStorage, out int bananaCount, out int birdSeedCount, out int meatCount);
                TextOutput.Text = $"{(ZookeeperName)selectedZookeeper.Name} has checked the food inventory";
                BananaCount.Text = $"{bananaCount} Bananas";
                BirdSeedCount.Text = $"{birdSeedCount} Birdseeds";
                MeatCount.Text = $"{meatCount} Meatpackets";
            }
        }

        private void AddAnimalButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewParrotCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void NewTigerCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void NewMonkeyCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void FeedAnimalsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckAnimalsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HireFireButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}

public enum Mood : int
{
    starving = 1,
    hungry = 2,
    satisfied = 3,
    happy = 4,
    ekstatic = 5
}

public enum Health : int
{
    miserable = 1,
    okay = 2,
    healthy = 3
}


