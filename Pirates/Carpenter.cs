using System;
namespace Pirates
{
    public class Carpenter : Pirate, IBoard
    {
        public Carpenter(string name)
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
