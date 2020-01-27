
namespace MortalEngines.Entities
{
    using System;
    using MortalEngines.Entities.Contracts;

    public class Tank : BaseMachine, ITank
    {
        private const double TankInitialHealthPoints = 100;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, TankInitialHealthPoints)
        {
            this.DefenseMode = false;
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;

                this.DefenseMode = false;
            }
            else
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;

                this.DefenseMode = true;
            }
        }

        public override string ToString()
        {
            if (this.DefenseMode == true)
            {
                return base.ToString() + Environment.NewLine + (" *Defense: ON");
            }

            return base.ToString() + Environment.NewLine + (" *Defense: OFF");
        }
    }
}
