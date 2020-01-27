
namespace MortalEngines.Entities
{
    using MortalEngines.Entities.Contracts;
    using System;

    public class Fighter : BaseMachine, IFighter
    {
        private const double FighterInitialHealthPoints = 200;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, FighterInitialHealthPoints)
        {
            this.AggressiveMode = false;
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == true)
            {
                this.AttackPoints -= 50;
                this.DefensePoints += 25;

                this.AggressiveMode = false;
            }
            else
            {
                this.AttackPoints += 50;
                this.DefensePoints -= 25;

                this.AggressiveMode = true;
            }
        }

        public override string ToString()
        {
            if (this.AggressiveMode == true)
            {
                return base.ToString() + Environment.NewLine + (" *Aggressive: ON");
            }

            return base.ToString() + Environment.NewLine + (" *Aggressive: OFF");
        }
    }
}
