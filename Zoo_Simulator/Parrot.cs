using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Simulator
{
    public class Parrot : Animal
    {
        private string type = "Parrot";

        public string Type { get => type; set => type = value; }

        public Parrot(string name, int age) : base(name, age)
        {
            base.Name = name;
            base.Age = age;
        }

        public override int GetMood()
        {
            return base.GetMood();
        }

        public override void DigestFood()
        {
            this.Mood--;
        }

        public override void Eat(List<Food> food)
        {
            if (this.Mood < 5)
            {
                int lastIndex = -1;
                for (int i = food.Count - 1; i >= 0; i--)
                {
                    if (food[i] is BirdSeed)
                    {
                        lastIndex = i;
                        break;
                    }
                }
                if (lastIndex >= 0)
                {
                    this.Mood++;
                    food.RemoveAt(lastIndex);
                }
                else
                {
                    //Text output der siger der ikke er mere af den rigtige type mad på lager
                }
            }
            else
            {
                //Tekst der indikerer at dyret er mæt
            }
        }
    }
}
