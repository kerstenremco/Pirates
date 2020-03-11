using System;
namespace Pirates
{
    public class Quartermaster : Pirate, IBoard
    {
        public Quartermaster(string name)
        {
            this.name = name;
            share = 2;
        }

        public bool Veto()
        {
            Random r = new Random();
            return (r.Next(100) < 12);
        }

        public int Enter()
        {
            Random r = new Random();
            return r.Next(2000);
        }
    }
}
