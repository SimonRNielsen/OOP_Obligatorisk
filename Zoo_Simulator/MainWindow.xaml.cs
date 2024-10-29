using System;
using System.ComponentModel;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool newParrot = false;
        private bool newTiger = false;
        private bool newMonkey = false;

        private Zookeeper selectedZookeeper;

        public Zookeeper SelectedZookeeper
        {
            get => selectedZookeeper;
            set
            {
                selectedZookeeper = value;
                OnPropertyChanged(nameof(SelectedZookeeper));
            }
        }
        private DependencyPropertyChangedEventArgs nameof(Zookeeper selectedZookeeper)
        {
            throw new NotImplementedException();
        }

        private Tiger selectedTiger;

        public Tiger SelectedTiger
        {
            get => selectedTiger;
            set
            {
                selectedTiger = value;
                OnPropertyChanged(nameof(SelectedTiger));
            }
        }

        private DependencyPropertyChangedEventArgs nameof(Tiger selectedTiger)
        {
            throw new NotImplementedException();
        }

        private Parrot selectedParrot;

        public Parrot SelectedParrot
        {
            get => selectedParrot;
            set
            {
                selectedParrot = value;
                OnPropertyChanged(nameof(SelectedParrot));
            }
        }
        private DependencyPropertyChangedEventArgs nameof(Parrot selectedParrot)
        {
            throw new NotImplementedException();
        }

        private Monkey _selectedMonkey;
        public Monkey SelectedMonkey
        {
            get => _selectedMonkey;
            set
            {
                _selectedMonkey = value;
                OnPropertyChanged(nameof(SelectedMonkey));
            }
        }
        private DependencyPropertyChangedEventArgs nameof(Monkey selectedMonkey)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool NewMonkey { get => newMonkey; set => newMonkey = value; }
        public bool NewTiger { get => newTiger; set => newTiger = value; }
        public bool NewParrot { get => newParrot; set => newParrot = value; }
        public static ObservableCollection<Tiger> TigerCageList { get; set; }
        public static ObservableCollection<Parrot> AviaryList { get; set; }
        public static ObservableCollection<Monkey> MonkeyCageList { get; set; }
        public static ObservableCollection<Zookeeper> Zookeepers { get; set; }
        public static ObservableCollection<Zookeeper> HireableZookeepers { get; set; }
        public static List<Food> FoodStorage { get; set; }

        public class InstantiateLists : INotifyPropertyChanged
        {
            public ObservableCollection<Tiger> TigerCageList { get; set; }
            public ObservableCollection<Parrot> AviaryList { get; set; }
            public ObservableCollection<Monkey> MonkeyCageList { get; set; }
            public ObservableCollection<Zookeeper> Zookeepers { get; set; }
            public ObservableCollection<Zookeeper> HireableZookeepers { get; set; }
            public List<Food> FoodStorage { get; set; }
            public InstantiateLists()
            {
                TigerCageList = new ObservableCollection<Tiger>();
                AviaryList = new ObservableCollection<Parrot>();
                MonkeyCageList = new ObservableCollection<Monkey>();
                Zookeepers = new ObservableCollection<Zookeeper>();
                FoodStorage = new List<Food>();
                HireableZookeepers = new ObservableCollection<Zookeeper> { new Zookeeper(), new Zookeeper(), new Zookeeper() };

                #region Debug

                TigerCageList.Add(new Tiger("Misser"));
                TigerCageList.Add(new Tiger("Kisser"));
                TigerCageList.Add(new Tiger("Lisser"));
                AviaryList.Add(new Parrot("Pip"));
                AviaryList.Add(new Parrot("Hans"));
                MonkeyCageList.Add(new Monkey("Martin"));
                MonkeyCageList.Add(new Monkey("Claus"));
                Zookeepers.Add(new Zookeeper());
                Zookeepers.Add(new Zookeeper());
                for (int i = 0; i < 10; i++)
                {
                    FoodStorage.Add(new Meat());
                    FoodStorage.Add(new Birdseed());
                    FoodStorage.Add(new Banana());
                }

                #endregion
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new InstantiateLists();
        }

        private void UpdateInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            Zookeeper selectedZookeeper = Zookeepers[ZookeeperBox.SelectedIndex];
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
            if (NewParrot == true)
            {
                if (NewAnimalName.Text == "")
                {
                    TextOutput.Text = "Animal must have a name";
                }
                else
                {
                    AviaryList.Add(new Parrot(NewAnimalName.Text));
                    TextOutput.Text = $"A parrot named {NewAnimalName.Text} has been added to the aviary";
                    NewAnimalName.Text = "";
                    NewParrotCheckBox.IsChecked = false;
                    NewParrot = false;
                }
            }
            else if (NewTiger == true)
            {
                if (NewAnimalName.Text == "")
                {
                    TextOutput.Text = "Animal must have a name";
                }
                else
                {
                    TigerCageList.Add(new Tiger(NewAnimalName.Text));
                    TextOutput.Text = $"A tiger named {NewAnimalName.Text} has been added to the tiger cage";
                    NewAnimalName.Text = "";
                    NewTigerCheckBox.IsChecked = false;
                    NewTiger = false;
                }
            }
            else if (NewMonkey == true)
            {
                if (NewAnimalName.Text == "")
                {
                    TextOutput.Text = "Animal must have a name";
                }
                else
                {
                    MonkeyCageList.Add(new Monkey(NewAnimalName.Text));
                    TextOutput.Text = $"A monkey named {NewAnimalName.Text} has been added to the monkey cage";
                    NewAnimalName.Text = "";
                    NewMonkeyCheckBox.IsChecked = false;
                    NewMonkey = false;
                }
            }
            else
            {
                TextOutput.Text = "You must select an animal type to add";
            }
        }

        private void RemoveAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (AviaryCheckBox.IsChecked == true)
            {
                if (Aviary.SelectedIndex < 0)
                {
                    TextOutput.Text = "You must check which cage from which to remove an animal, and a specific animal therein";
                }
                else
                {
                    AviaryList.RemoveAt(Aviary.SelectedIndex);
                    AviaryCheckBox.IsChecked = false;
                }
            }
            else if (TigerCageCheckBox.IsChecked == true)
            {
                if (TigerCage.SelectedIndex < 0)
                {
                    TextOutput.Text = "You must check which cage from which to remove an animal, and a specific animal therein";
                }
                else
                {
                    TigerCageList.RemoveAt(TigerCage.SelectedIndex);
                    TigerCageCheckBox.IsChecked = false;
                }
            }
            else if (MonkeyCageCheckBox.IsChecked == true)
            {
                if (MonkeyCage.SelectedIndex < 0)
                {
                    TextOutput.Text = "You must check which cage from which to remove an animal, and a specific animal therein";
                }
                else
                {
                    MonkeyCageList.RemoveAt(MonkeyCage.SelectedIndex);
                    MonkeyCageCheckBox.IsChecked = false;
                }
            }
            else
            {
                TextOutput.Text = "You must check which cage from which to remove an animal, and a specific animal therein";
            }
        }

        private void NewParrotCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            NewTigerCheckBox.IsChecked = false;
            NewMonkeyCheckBox.IsChecked = false;
            NewParrot = true;
            NewMonkey = false;
            NewTiger = false;
        }

        private void NewParrotCheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            NewParrot = false;
        }

        private void NewTigerCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            NewParrotCheckBox.IsChecked = false;
            NewMonkeyCheckBox.IsChecked = false;
            NewParrot = false;
            NewMonkey = false;
            NewTiger = true;
        }

        private void NewTigerCheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            NewTiger = false;
        }

        private void NewMonkeyCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            NewTigerCheckBox.IsChecked = false;
            NewParrotCheckBox.IsChecked = false;
            NewMonkey = true;
            NewTiger = false;
            NewParrot = false;
        }

        private void NewMonkeyCheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            NewMonkey = false;
        }

        private void FeedAnimalsButton_Click(object sender, RoutedEventArgs e)
        {
            if (Zookeepers[ZookeeperBox.SelectedIndex] == null)
            {
                TextOutput.Text = "You must select a zookeeper to perform this action";
            }
            else
            {
                if (AviaryCheckBox.IsChecked == true || MonkeyCageCheckBox.IsChecked == true || TigerCageCheckBox.IsChecked == true)
                {
                    TextOutput.Text = "";
                    if (AviaryCheckBox.IsChecked == true)
                    {
                        Zookeepers[ZookeeperBox.SelectedIndex].FeedParrots(AviaryList, FoodStorage, TextOutput);
                        AviaryCheckBox.IsChecked = false;
                    }
                    if (MonkeyCageCheckBox.IsChecked == true)
                    {
                        Zookeepers[ZookeeperBox.SelectedIndex].FeedMonkeys(MonkeyCageList, FoodStorage, TextOutput);
                        MonkeyCageCheckBox.IsChecked = false;
                    }
                    if (TigerCageCheckBox.IsChecked == true)
                    {
                        Zookeepers[ZookeeperBox.SelectedIndex].FeedTigers(TigerCageList, FoodStorage, TextOutput);
                        TigerCageCheckBox.IsChecked = false;
                    }
                }
                else
                {
                    TextOutput.Text = "You must select which animal holding to feed";
                }
            }
        }

        private void CheckAnimalsButton_Click(object sender, RoutedEventArgs e)
        {
            if (Zookeepers[ZookeeperBox.SelectedIndex] == null)
            {
                TextOutput.Text = "You must select a zookeeper to perform this action";
            }
            else
            {
                AnimalConditionBox.Text = Zookeepers[ZookeeperBox.SelectedIndex].CheckAnimals(TigerCageList, MonkeyCageList, AviaryList);
            }
        }

        private void FireButton_Click(object sender, RoutedEventArgs e)
        {
            int index = ZookeeperBox.SelectedIndex;
            if (Zookeepers[ZookeeperBox.SelectedIndex] == null)
            {
                TextOutput.Text = "No zookeeper to be fired selected";
            }
            else
            {
                TextOutput.Text = $"{(ZookeeperName)Zookeepers[ZookeeperBox.SelectedIndex].Name} has been fired";
                Zookeepers.RemoveAt(ZookeeperBox.SelectedIndex);
            }
        }

        private void HireButton_Click(object sender, RoutedEventArgs e)
        {
            if (HireableZookeepers[ZookeeperBox.SelectedIndex] == null)
            {
                TextOutput.Text = "No zookeeper to be hired selected";
            }
            else
            {
                TextOutput.Text = $"{(ZookeeperName)HireableZookeepers[NewZookeepersBox.SelectedIndex].Name} has been hired";
                Zookeepers.Add(HireableZookeepers[NewZookeepersBox.SelectedIndex]);
                HireableZookeepers.RemoveAt(NewZookeepersBox.SelectedIndex);
                HireableZookeepers.Add(new Zookeeper());
            }
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


