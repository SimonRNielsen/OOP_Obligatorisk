using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Zoo_Simulator
{
    public class Tiger : Animal
    {
        private string type = "Tiger";

        public string Type { get => type; set => type = value; }

        public Tiger(string name) : base(name)
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
            if (this.Mood == 0)
            {
                this.Mood = 1;
                this.Health--;
            }
            if (this.Health == 0)
            {
                //Død?
            }
            else if (this.Health > 0 && this.Mood > 1) 
            {
                this.Health++;
            }
        }

        public override void Eat(List<Food> food)
        {
            if (this.Mood < 5)
            {
                int lastIndex = -1;
                for (int i = food.Count - 1; i >= 0; i--)
                {
                    if (food[i] is Meat)
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
                    //Tekst output der siger der ikke er mere af den rigtige type mad på lager
                }
            }
            else
            {
                //Tekst der indikerer at dyret er mæt
            }
        }
    }
}
