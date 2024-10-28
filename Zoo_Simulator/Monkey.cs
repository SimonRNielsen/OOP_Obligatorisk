using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Simulator
{
    public class Monkey : Animal
    {
        private string type = "Monkey";

        public string Type { get => type; set => type = value; }

        public Monkey(string name) : base(name)
        {
            base.Name = name;
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
                    if (food[i] is Banana)
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
