using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Simulator
{
    public abstract class Animal
    {
        protected string name;
        protected int age;
        protected int mood = 3;
        protected int health = 3;

        public Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int Age { get => age; set => age = value; }
        public string Name { get => name; set => name = value; }
        public int Mood 
        { 
            get => mood; 
            set
            {
                if (value > 5)
                {
                    mood = 5;
                }
                else
                {
                    mood = value;
                }
            }
        }
        public int Health 
        { 
            get => health; 
            set
            {
                if (value > 3)
                {
                    health = 3;
                }
                else
                {
                    health = value;
                }
            }
        }

        public virtual int GetMood()
        {
            return this.Mood;
        }
        public abstract void DigestFood();

        public abstract void Eat(List<Food> food);
    }
}
