
namespace MortalEngines.Entities
{
    using System;

    public class Fighter : BaseMachine
    {
        private const double InitialHealthPoints = 200d;
        private bool aggressiveMode;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.AggressiveMode = true;
            this.IsEngaged = false;
        }

        //public bool IsEngaged { get; set; }

        public bool AggressiveMode { get; set; }

        public void ToggleAggressiveMode()
        {
            if (AggressiveMode == true)
            {
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
                AggressiveMode = false;
            }
            else if (AggressiveMode == false)
            {
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
                AggressiveMode = true;
            }
        }

        public override string ToString()
        {
            if (AggressiveMode == true)
            {
                return base.ToString() + Environment.NewLine + " *Aggressive: ON";
            }
            else
            {
                return base.ToString() + Environment.NewLine + " *Aggressive: OFF";
            }
        }
    }
}
