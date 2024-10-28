using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
        static Random rng = new Random();

        Zookeeper()
        {
            this.Name = rng.Next(1, 30);
            this.Age = rng.Next(20, 60);
        }

        public int Name { get => name; private set => name = value; }
        public int Age { get => age; private set => age = value; }

        public void FeedTigers(ObservableCollection<Animal> animals, List<Food> food, TextBox text)
        {
            foreach (Tiger animal in animals)
            {
                animal.Eat(food);
                text.Text = $"{(ZookeeperName)this.Name} has feed the tigers";                
            }
        }

        public void FeedParrots(ObservableCollection<Animal> animals, List<Food> food, TextBox text)
        {
            foreach (Parrot animal in animals)
            {
                animal.Eat(food);
                text.Text = $"{(ZookeeperName)this.Name} has feed the tigers";
            }
        }

        public void FeedMonkeys(ObservableCollection<Animal> animals, List<Food> food, TextBox text)
        {
            foreach (Monkey animal in animals)
            {
                animal.Eat(food);
                text.Text = $"{(ZookeeperName)this.Name} has feed the tigers";
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
