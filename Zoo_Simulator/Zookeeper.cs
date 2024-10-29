using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Zoo_Simulator
{

    public enum ZookeeperName : int
    {
        Alice = 1,
        Benjamin = 2,
        Clara = 3,
        David = 4,
        Ella = 5,
        Felix = 6,
        Grace = 7,
        Henry = 8,
        Isla = 9,
        Jack = 10,
        Kira = 11,
        Liam = 12,
        Maya = 13,
        Noah = 14,
        Olivia = 15,
        Paul = 16,
        Quinn = 17,
        Ruby = 18,
        Samuel = 19,
        Tessa = 20,
        Uma = 21,
        Victor = 22,
        Willow = 23,
        Xavier = 24,
        Yara = 25,
        Zach = 26,
        Ada = 27,
        Benji = 28,
        Cora = 29,
        Dante = 30
    }

    public class Zookeeper
    {
        private int name;
        private int age;
        private string displayName;
        static Random rng = new Random();

        public Zookeeper()
        {
            this.Name = rng.Next(1, 30);
            this.Age = rng.Next(20, 60);
        }

        public int Name { get => name; private set => name = value; }
        public int Age { get => age; private set => age = value; }
        public string DisplayName => ((ZookeeperName)this.Name + " " + this.Age).ToString();

        public void FeedTigers(ObservableCollection<Tiger> animals, List<Food> food, TextBlock text)
        {
            foreach (Tiger animal in animals)
            {
                animal.Eat(food);
                text.Text += $"\n{(ZookeeperName)this.Name} has fed the tigers";                
            }
        }

        public void FeedParrots(ObservableCollection<Parrot> animals, List<Food> food, TextBlock text)
        {
            foreach (Parrot animal in animals)
            {
                animal.Eat(food);
                text.Text += $"\n{(ZookeeperName)this.Name} has fed the parrots";
            }
        }

        public void FeedMonkeys(ObservableCollection<Monkey> animals, List<Food> food, TextBlock text)
        {
            foreach (Monkey animal in animals)
            {
                animal.Eat(food);
                text.Text += $"\n{(ZookeeperName)this.Name} has fed the monkeys";
            }
        }

        public void FoodInventory(List<Food> foodStorage, out int bananaCount, out int birdSeedCount, out int meatCount)
        {
            bananaCount = 0;
            birdSeedCount = 0;
            meatCount = 0;
            foreach (Food consumable in foodStorage)
            {
                if (consumable is Banana)
                {
                    bananaCount++;
                }
                else if (consumable is Meat)
                {
                    meatCount++;
                }
                else
                {
                    birdSeedCount++;
                }
            }
        }

        public string CheckAnimals(ObservableCollection<Tiger> tigerCage, ObservableCollection<Monkey> monkeyCage, ObservableCollection<Parrot> aviary)
        {
            string list;
            list = $"{(ZookeeperName)this.Name} has checked the animals and discerned the following:";
            foreach (Tiger tiger in tigerCage)
            {
                list += $"\n{tiger.Name} the {tiger.Type} is {(Mood)tiger.GetMood()} and looks {(Health)tiger.Health}";
            }
            foreach (Monkey monkey in monkeyCage)
            {
                list += $"\n{monkey.Name} the {monkey.Type} is {(Mood)monkey.GetMood()} and looks {(Health)monkey.Health}";
            }
            foreach (Parrot parrot in aviary)
            {
                list += $"\n{parrot.Name} the {parrot.Type} is {(Mood)parrot.GetMood()} and looks {(Health)parrot.Health}";
            }
            return list;
        }

        public List<string> CheckAnimals(Zookeeper zookeeper, ObservableCollection<Tiger> tigerCage, ObservableCollection<Monkey> monkeyCage, ObservableCollection<Parrot> aviary, TextBlock text)
        {
            List<string> list = new List<string>();
            if (zookeeper == null)
            {
                text.Text = "No zookeeper selected";
            }
            else
            {
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
            }
            return list;
        }

        public void StockInventory(int buyBananas, int buyBirdseed, int buyMeat, List<Food> foodStorage, TextBlock output, Zookeeper zookeeper)
        {
            for (int i = 0; i < buyBananas; i++)
            {
                foodStorage.Add(new Banana());
            }
            for (int i = 0; i < buyBirdseed; i++)
            {
                foodStorage.Add(new Birdseed());
            }
            for (int i = 0; i < buyMeat; i++)
            {
                foodStorage.Add(new Meat());
            }
            output.Text = $"{(ZookeeperName)zookeeper.Name} has stocked the food storage with {buyBananas} bananas, {buyBirdseed} birdseed and {buyMeat} meatpackets";
        }
    }
}
