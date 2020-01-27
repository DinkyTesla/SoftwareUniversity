
namespace MortalEngines.Entities
{
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MortalEngines.Core;

    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double attackPoints;
        private double defensePoints;
        private double healthPoints;
        private IList<string> targets;
       

        protected BaseMachine(string name, double attackPoints, double defensePoints
            , double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }

        public double AttackPoints { get; set; }

        public double DefensePoints { get; set; }

        public double HealthPoints { get; set; }

        public IList<string> Targets { get; set; }

        public virtual void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            target.HealthPoints -= (this.AttackPoints - target.DefensePoints);

            if (target.HealthPoints <= 0)
            {
                target.HealthPoints = 0;
            }

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine($"- {this.Name}");
            report.AppendLine($" *Type: {GetType().Name}");
            report.AppendLine($" *Health: {this.HealthPoints:f2}");
            report.AppendLine($" *Attack: {this.AttackPoints:f2}");
            report.AppendLine($" *Defense: {this.DefensePoints:f2}");
            report.Append($" *Targets: ");

            if (Targets.Count == 0)
            {
                report.Append($"None");
            }
            else
            {
                report.Append(string.Join(" ,", Targets));
            }

            string result = report.ToString().TrimEnd();

            return result;
        }
    }
}
