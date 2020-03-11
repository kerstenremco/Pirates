using System;
namespace Pirates
{
    public class Gunner : Pirate, IBoard
    {
        public Gunner(string name)
        {
            this.name = name;
        }

        public int Enter()
        {
            Random r = new Random();
            return r.Next(1000);
        }
    }
}
