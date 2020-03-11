using System;
using System.Collections.Generic;

namespace Pirates
{
    public class Ship
    {
        private Loot loot;
        private List<Pirate> pirates;

        public Ship(List<Pirate> p)
        {
            pirates = new List<Pirate>(p);
        }

        public (int value, List<string> loots) Enter(string name)
        {
            int value = 0;
            List<string> loots = new List<string>();
            foreach(Pirate p in pirates)
            {
                if(p is IBoard)
                {
                    int val = ((IBoard)p).Enter();
                    value += val;
                    loots.Add(p.GetName());
                    loots.Add(Convert.ToString(val));
                }
            }
            if (loot == null) loot = new Loot(name, value);
            else loot.Add(name, value);
            return (value, loots);
        }

        public bool Vote()
        {
            int yes = 0;
            int no = 0;
            foreach(Pirate p in pirates)
            {
                if (p is Quartermaster && ((Quartermaster)p).Veto()) return false;
                if (p.Vote()) yes++;
                else no++;
            }
            return yes > no;
        }

        public List<string> GetPirates()
        {
            List<string> pirates = new List<string>();
            foreach(Pirate p in this.pirates)
            {
                pirates.Add(p.GetName());
            }
            return pirates;
        }

        public string[] GetCaptain()
        {
            string[] result = new string[2];
            foreach(Pirate p in pirates)
            {
                if(p is Captain)
                {
                    result[0] = p.GetName();
                    result[1] = ((Captain)p).GetFlag();
                } 
            }
            return result;
        }

        public Loot GetLoot()
        {
            return loot;
        }
    }
}
