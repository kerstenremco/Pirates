using System;
namespace Pirates
{
    public class Captain : Pirate
    {
        private string flag;
        public Captain(string name, string flag)
        {
            this.name = name;
            this.flag = flag;
        }

        public string GetFlag()
        {
            return this.flag;
        }
    }
}
