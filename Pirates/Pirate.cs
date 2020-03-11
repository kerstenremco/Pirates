using System;
namespace Pirates
{
    public class Pirate
    {
        protected string name;
        protected double share;

        public bool Vote()
        {
            Random r = new Random();
            return (r.Next(100) < 50);
        }

        public double GetShare()
        {
            return this.share;
        }

        public string GetName()
        {
            return name;
        }

    }
}
