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
    public partial class MainWindow : Window
    {
        private bool newParrot = false;
        private bool newTiger = false;
        private bool newMonkey = false;
        private bool zookeepersSelected = false;
        private bool newZookeepersSelected = false;
        private bool aviarySelected = false;
        private bool tigerCageSelected = false;
        private bool monkeyCageSelected = false;
        private int indexInput;

        public ObservableCollection<Tiger> TigerCageList;

        public ObservableCollection<Parrot> AviaryList;

        public ObservableCollection<Monkey> MonkeyCageList;

        public ObservableCollection<Zookeeper> Zookeepers;

        public ObservableCollection<Zookeeper> HireableZookeepers;

        public List<Food> FoodStorage;


        public bool NewMonkey { get => newMonkey; set => newMonkey = value; }
        public bool NewTiger { get => newTiger; set => newTiger = value; }
        public bool NewParrot { get => newParrot; set => newParrot = value; }
        public bool ZookeepersSelected { get => zookeepersSelected; set => zookeepersSelected = value; }
        public bool NewZookeepersSelected { get => newZookeepersSelected; set => newZookeepersSelected = value; }
        public bool AviarySelected { get => aviarySelected; set => aviarySelected = value; }
        public bool TigerCageSelected { get => tigerCageSelected; set => tigerCageSelected = value; }
        public bool MonkeyCageSelected { get => monkeyCageSelected; set => monkeyCageSelected = value; }
        public int IndexInput
        {
            get => indexInput;
            set
            {
                if (value <= 0)
                {
                    indexInput = 0;
                }
                else
                {
                    indexInput = value - 1;
                }
            }
        }

        public class InstantiateLists : INotifyPropertyChanged
        {
            private ObservableCollection<Tiger> tigerCageList;
            private ObservableCollection<Parrot> aviaryList;
            private ObservableCollection<Monkey> monkeyCageList;
            private ObservableCollection<Zookeeper> zookeepers;
            private ObservableCollection<Zookeeper> hireableZookeepers;
            private List<Food> foodStorage;

            public ObservableCollection<Tiger> TigerCageList
            {
                get => tigerCageList;
                set
                {
                    tigerCageList = value;
                    OnPropertyChanged(nameof(TigerCageList));
                }
            }

            public ObservableCollection<Parrot> AviaryList
            {
                get => aviaryList;
                set
                {
                    aviaryList = value;
                    OnPropertyChanged(nameof(AviaryList));
                }
            }

            public ObservableCollection<Monkey> MonkeyCageList
            {
                get => monkeyCageList;
                set
                {
                    monkeyCageList = value;
                    OnPropertyChanged(nameof(MonkeyCageList));
                }
            }

            public ObservableCollection<Zookeeper> Zookeepers
            {
                get => zookeepers;
                set
                {
                    zookeepers = value;
                    OnPropertyChanged(nameof(Zookeepers));
                }
            }

            public ObservableCollection<Zookeeper> HireableZookeepers
            {
                get => hireableZookeepers;
                set
                {
                    hireableZookeepers = value;
                    OnPropertyChanged(nameof(HireableZookeepers));
                }
            }

            public List<Food> FoodStorage
            {
                get => foodStorage;
                set
                {
                    foodStorage = value;
                    OnPropertyChanged(nameof(FoodStorage));
                }
            }

            public InstantiateLists()
            {
                TigerCageList = new ObservableCollection<Tiger>();
                AviaryList = new ObservableCollection<Parrot>();
                MonkeyCageList = new ObservableCollection<Monkey>();
                Zookeepers = new ObservableCollection<Zookeeper>();
                HireableZookeepers = new ObservableCollection<Zookeeper> { new Zookeeper(), new Zookeeper() };
                FoodStorage = new List<Food>();

                InitializeSampleData();
            }

            private void InitializeSampleData()
            {
                //TigerCageList.Add(new Tiger("Misser"));
                //TigerCageList.Add(new Tiger("Kisser"));
                //TigerCageList.Add(new Tiger("Lisser"));
                //AviaryList.Add(new Parrot("Pip"));
                //AviaryList.Add(new Parrot("Hans"));
                //MonkeyCageList.Add(new Monkey("Martin"));
                //MonkeyCageList.Add(new Monkey("Claus"));
                //Zookeepers.Add(new Zookeeper());
                //Zookeepers.Add(new Zookeeper());

                for (int i = 0; i < 10; i++)
                {
                    FoodStorage.Add(new Meat());
                    FoodStorage.Add(new Birdseed());
                    FoodStorage.Add(new Banana());
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new InstantiateLists();

        }

        private void UpdateInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (ZookeepersSelected)
            {
                if (int.TryParse(IndexSelecter.Text, out int result))
                {
                    IndexInput = result;
                    var lists = DataContext as InstantiateLists;
                    if (IndexInput <= lists.Zookeepers.Count())
                    {
                        lists.Zookeepers[IndexInput].FoodInventory(lists.FoodStorage, out int bananaCount, out int birdSeedCount, out int meatCount);
                        TextOutput.Text = $"{(ZookeeperName)lists.Zookeepers[IndexInput].Name} has checked the food inventory";
                        BananaCount.Text = $"{bananaCount} Bananas";
                        BirdSeedCount.Text = $"{birdSeedCount} Birdseeds";
                        MeatCount.Text = $"{meatCount} Meatpackets";
                        IndexSelecter.Text = "";
                        ZookeepersSelected = false;
                        SelectZookeepersCheckBox.IsChecked = false;
                    }
                    else
                    {
                        TextOutput.Text = "Invalid zookeeper selected (too high number)";
                    }
                }
                else
                {
                    TextOutput.Text = "Invalid zookeeper selected (wasn't an acceptalbe number input)";
                }
            }
            else
            {
                TextOutput.Text = "Zookeepers not selected";
            }
        }

        private void AddAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            var lists = DataContext as InstantiateLists;
            if (NewParrot == true)
            {
                if (NewAnimalName.Text == "")
                {
                    TextOutput.Text = "Animal must have a name";
                }
                else
                {
                    lists.AviaryList.Add(new Parrot(NewAnimalName.Text));
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
                    lists.TigerCageList.Add(new Tiger(NewAnimalName.Text));
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
                    lists.MonkeyCageList.Add(new Monkey(NewAnimalName.Text));
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
            var lists = DataContext as InstantiateLists;
            if (int.TryParse(IndexSelecter.Text, out int result))
            {
                IndexInput = result;
                if (AviaryCheckBox.IsChecked == true)
                {
                    if (lists.AviaryList.Count() < IndexInput)
                    {
                        TextOutput.Text = "You must check which cage from which to remove an animal, and a valid specific animal therein";
                    }
                    else
                    {
                        lists.AviaryList.RemoveAt(Aviary.SelectedIndex);
                        AviaryCheckBox.IsChecked = false;
                        AviarySelected = false;
                    }
                }
                else if (TigerCageCheckBox.IsChecked == true)
                {
                    if (lists.TigerCageList.Count() < IndexInput)
                    {
                        TextOutput.Text = "You must check which cage from which to remove an animal, and a valid specific animal therein";
                    }
                    else
                    {
                        lists.TigerCageList.RemoveAt(TigerCage.SelectedIndex);
                        TigerCageCheckBox.IsChecked = false;
                        TigerCageSelected = false;
                    }
                }
                else if (MonkeyCageCheckBox.IsChecked == true)
                {
                    if (lists.MonkeyCageList.Count() < IndexInput)
                    {
                        TextOutput.Text = "You must check which cage from which to remove an animal, and a valid specific animal therein";
                    }
                    else
                    {
                        lists.MonkeyCageList.RemoveAt(MonkeyCage.SelectedIndex);
                        MonkeyCageCheckBox.IsChecked = false;
                        MonkeyCageSelected = false;
                    }
                }
                else
                {
                    TextOutput.Text = "You must check which cage from which to remove an animal, and a specific animal therein";
                }
            }
            else
            {
                TextOutput.Text = "You need to input a number";
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
            var lists = DataContext as InstantiateLists;
            if (int.TryParse(IndexSelecter.Text, out int result) && ZookeepersSelected == true)
            {
                IndexInput = result;
                if (lists.Zookeepers[IndexInput] == null || IndexInput > lists.Zookeepers.Count())
                {
                    TextOutput.Text = "You must select a valid zookeeper to perform this action";
                }
                else
                {
                    if (AviarySelected == true || MonkeyCageSelected == true || TigerCageSelected == true)
                    {
                        TextOutput.Text = "";
                        if (AviarySelected == true)
                        {
                            lists.Zookeepers[IndexInput].FeedParrots(lists.AviaryList, lists.FoodStorage, TextOutput);
                            AviaryCheckBox.IsChecked = false;
                            AviarySelected = false;
                        }
                        if (MonkeyCageSelected == true)
                        {
                            lists.Zookeepers[IndexInput].FeedMonkeys(lists.MonkeyCageList, lists.FoodStorage, TextOutput);
                            MonkeyCageCheckBox.IsChecked = false;
                            MonkeyCageSelected = false;
                        }
                        if (TigerCageSelected == true)
                        {
                            lists.Zookeepers[IndexInput].FeedTigers(lists.TigerCageList, lists.FoodStorage, TextOutput);
                            TigerCageCheckBox.IsChecked = false;
                            TigerCageSelected = false;
                        }
                        IndexSelecter.Text = "";
                        ZookeepersSelected = false;
                        SelectZookeepersCheckBox.IsChecked = false;
                    }
                    else
                    {
                        TextOutput.Text = "You must select which animal holding to feed";
                    }
                }
            }
        }

        private void CheckAnimalsButton_Click(object sender, RoutedEventArgs e)
        {
            var lists = DataContext as InstantiateLists;
            if (int.TryParse(IndexSelecter.Text, out int result) && ZookeepersSelected == true)
            {
                IndexInput = result;
                if (lists.Zookeepers[IndexInput] == null || IndexInput > lists.Zookeepers.Count())
                {
                    TextOutput.Text = "You must select a zookeeper to perform this action";
                }
                else
                {
                    string outputstring = lists.Zookeepers[IndexInput].CheckAnimals(lists.TigerCageList, lists.MonkeyCageList, lists.AviaryList);
                    AnimalConditionBox.Text = $"{outputstring}";
                    IndexSelecter.Text = "";
                    ZookeepersSelected = false;
                    SelectZookeepersCheckBox.IsChecked = false;
                }
            }
            else
            {
                TextOutput.Text = "Invalid numberselection of zookeeper";
            }
        }

        private void FireButton_Click(object sender, RoutedEventArgs e)
        {
            var lists = DataContext as InstantiateLists;
            if (int.TryParse(IndexSelecter.Text, out int result) && ZookeepersSelected == true)
            {
                IndexInput = result;
                if (lists.Zookeepers[IndexInput] == null)
                {
                    TextOutput.Text = "No zookeeper to be fired selected";
                }
                else
                {
                    TextOutput.Text = $"{(ZookeeperName)lists.Zookeepers[IndexInput].Name} has been fired";
                    lists.Zookeepers.RemoveAt(IndexInput);
                    IndexSelecter.Text = "";
                    ZookeepersSelected = false;
                    SelectZookeepersCheckBox.IsChecked = false;
                }
            }
        }

        private void HireButton_Click(object sender, RoutedEventArgs e)
        {
            var lists = DataContext as InstantiateLists;
            if (int.TryParse(IndexSelecter.Text, out int result) && NewZookeepersSelected == true)
            {
                IndexInput = result;
                if (IndexInput > lists.HireableZookeepers.Count())
                {
                    TextOutput.Text = "No zookeeper to be hired selected";
                }
                else
                {
                    TextOutput.Text = $"{(ZookeeperName)lists.HireableZookeepers[IndexInput].Name} has been hired";
                    lists.Zookeepers.Add(lists.HireableZookeepers[IndexInput]);
                    lists.HireableZookeepers.RemoveAt(IndexInput);
                    lists.HireableZookeepers.Add(new Zookeeper());
                    NewZookeepersSelected = false;
                    HireZookeeperCheckBox.IsChecked = false;
                    IndexSelecter.Text = "";
                }
            }
            else
            {
                TextOutput.Text = "No zookeeper to be hired selected";
            }
        }

        private void SelectZookeepersCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ZookeepersSelected = true;
        }

        private void SelectZookeepersCheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            ZookeepersSelected = false;
        }

        private void HireZookeeperCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            NewZookeepersSelected = true;
        }

        private void HireZookeeperCheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            NewZookeepersSelected = false;
        }

        private void AviaryCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AviarySelected = true;
        }

        private void AviaryCheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            AviarySelected = false;
        }

        private void TigerCageCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            TigerCageSelected = true;
        }

        private void TigerCageCheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            TigerCageSelected = false;
        }

        private void MonkeyCageCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MonkeyCageSelected = true;
        }

        private void MonkeyCageCheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            MonkeyCageSelected = false;
        }

        private void NextDayButton_Click(object sender, RoutedEventArgs e)
        {
            var lists = DataContext as InstantiateLists;
            foreach (Parrot animal in lists.AviaryList)
            {
                animal.DigestFood();
            }
            foreach (Monkey animal in lists.MonkeyCageList)
            {
                animal.DigestFood();
            }
            foreach (Tiger animal in lists.TigerCageList)
            {
                animal.DigestFood();
            }
            TextOutput.Text = "A day has passed, and the animals have gotten more hungry";
        }

        private void OrderFoodButton_Click(object sender, RoutedEventArgs e)
        {
            var lists = DataContext as InstantiateLists;
            if (int.TryParse(IndexSelecter.Text, out int result))
            {
                for (int i = 0; i < result; i++)
                {
                    lists.FoodStorage.Add(new Meat());
                    lists.FoodStorage.Add(new Birdseed());
                    lists.FoodStorage.Add(new Banana());
                }
                TextOutput.Text = $"{result} pieces of each foodtype added to storage";
            }
            else
            {
                TextOutput.Text = "You need to input a number of products to order";
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


