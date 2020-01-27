using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Ferrari
{
    class Ferrari
    {

        public string Model => "488-Spider";

        public string Driver { get; private set; }

        public string Gas()
        {
            return "Zadu6avam sA!";
        }

        public string PushBrakes()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
