using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    class Tank : BaseMachine
    {
        private const double InitialHealthPoints = 100d;
        private bool defenseMode;
        private bool isEngaged = false;

        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.DefenseMode = true;
            this.IsEngaged = false;
        }

        public bool DefenseMode { get; set; }

        //public bool IsEngaged { get; set; }
        //{
        //    get => this.isEngaged;
        //    set
        //    {
        //        if (isEngaged == true)
        //        {
        //           throw new InvalidOperationException($"Machine {this.Name} is already occupied");
        //        }

        //        isEngaged = true;
        //    }
        //}

        public void ToggleDefenseMode()
        {
            if (DefenseMode == true)
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
                DefenseMode = false;
            }
            else if (DefenseMode == false)
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
                DefenseMode = true;
            }
        }

        public override string ToString()
        {
            if (DefenseMode == true)
            {
                return base.ToString() + Environment.NewLine + " *Defense: ON";
            }
            else
            {
                return base.ToString() + Environment.NewLine + " *Defense: OFF";
            }
        }
    }
}
