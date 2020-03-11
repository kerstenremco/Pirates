using System;
using System.Collections.Generic;
using System.Linq;

namespace Pirates
{
    public class Loot
    {
        private string name;
        private int value;
        private Loot lessValue;
        private Loot moreValue;

        public Loot(string n, int v)
        {
            name = n;
            value = v;
        }

        public void Add(string name, int value)
        {
            if(value > this.value)
            {
                // moet aan rechter kant
                if (this.moreValue == null) this.moreValue = new Loot(name, value);
                else this.moreValue.Add(name, value);
            } else
            {
                // moet aan linker kant
                if (this.lessValue == null) this.lessValue = new Loot(name, value);
                else this.lessValue.Add(name, value);
            }
        }

        public string Max()
        {
            if (this.moreValue == null) return this.name;
            else return this.moreValue.Max();
        }

        public double LootPerShare(double shares)
        {
            double vps = value / shares;

            if (lessValue != null) vps += lessValue.LootPerShare(shares);
            if (moreValue != null) vps += moreValue.LootPerShare(shares);

            return vps;


        }

        public List<string> GetLoots()
        {
            List<string> loots = new List<string>();
            loots.Add(name);
            loots.Add(Convert.ToString(value));

            if (lessValue != null)
                loots = loots.Concat(lessValue.GetLoots()).ToList();
            if (moreValue != null)
                loots = loots.Concat(moreValue.GetLoots()).ToList();

            return loots;

        }
    }
}
