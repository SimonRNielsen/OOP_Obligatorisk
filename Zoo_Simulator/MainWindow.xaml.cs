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
        
        public ObservableCollection<Tiger> TigerCage { get; set; }
        public ObservableCollection<Parrot> Aviary { get; set; }
        public ObservableCollection<Monkey> MonkeyCage { get; set; }
        public ObservableCollection<Zookeeper> Zookeepers { get; set; }
        public List<Food> FoodStorage { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            TigerCage = new ObservableCollection<Tiger>();
            Aviary = new ObservableCollection<Parrot>();
            MonkeyCage = new ObservableCollection<Monkey>();
            Zookeepers = new ObservableCollection<Zookeeper>();
            FoodStorage = new List<Food>();
        }

        private void UpdateInventoryButton_Click(object sender, RoutedEventArgs e)
        {
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
                MeatCount.Text = $"{meatCount} Meat";
            }
        }

        public List<string> CheckAnimals(Zookeeper zookeeper, ObservableCollection<Tiger> tigerCage, ObservableCollection<Monkey> monkeyCage, ObservableCollection<Parrot> aviary)
        {
            List<string> list = new List<string>();
            list.Add($"{(ZookeeperName)zookeeper.Name} has checked the animals and discerned the following");
            foreach (Tiger tiger in tigerCage)
            {
                list.Add($"{tiger.Name} the {tiger.Type} is {(Mood)tiger.GetMood()} and looks {(Health)tiger.Health}");
            }
            foreach (Monkey monkey in monkeyCage)
            {
                list.Add($"{monkey.Name} the {monkey.Type} is {(Mood)monkey.GetMood()} and looks {(Health)monkey.Health}");
            }
            foreach (Parrot parrot in aviary)
            {
                list.Add($"{parrot.Name} the {parrot.Type} is {(Mood)parrot.GetMood()} and looks {(Health)parrot.Health}");
            }
            return list;
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


