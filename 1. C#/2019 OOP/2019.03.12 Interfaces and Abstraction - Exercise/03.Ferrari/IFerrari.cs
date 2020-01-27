using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Ferrari
{
    interface IFerrari
    {
        string Model { get; }

        string Driver { get; }

        string PushBrakes();

        string Gas();
    }
}
