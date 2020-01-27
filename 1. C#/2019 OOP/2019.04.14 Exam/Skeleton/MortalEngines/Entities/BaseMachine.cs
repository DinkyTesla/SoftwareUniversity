
namespace MortalEngines.Entities
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using MortalEngines.Entities.Contracts;

    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double attackPoints;
        private double defensePoints;
        private double healthPoints;
        private List<string> targets;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.Pilot = pilot;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.Targets = targets;
        }

        public string Name
        {
            get => this.name;
            private set
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

        //no wrong data check?
        public double HealthPoints { get; set; }
        //Here coult be => this.attackPoints
        public double AttackPoints { get; protected set; }
        //same
        public double DefensePoints { get; protected set; }
        //same
        public IList<string> Targets { get; set; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            double targetHealth = target.HealthPoints;
            targetHealth -= this.attackPoints;

            if (targetHealth <= 0)
            {
                target.HealthPoints = 0;
            }
            else
            {
                target.HealthPoints = targetHealth;
            }

            this.Targets.Add(target.Name);
        }

        public bool IsEngaged { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"- {this.Name}");
            result.AppendLine($" *Type: {this.GetType().Name}");
            result.AppendLine($" *Health: {this.HealthPoints}");
            result.AppendLine($" *Attack: {this.AttackPoints}");
            result.AppendLine($" *Defense: {this.DefensePoints}");
            if (this.targets == null)
            {
                result.AppendLine($" *Targets: None");
            }
            else
            {
                result.AppendLine(" *Targets: ");
                foreach (var target in targets)
                {
                    result.Append($"{target} ");
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}

//Name – string (If the name is null or whitespace throw an ArgumentNullException with message "Machine name cannot be null or empty.")
//Pilot – the machine pilot(if the pilot is null throw NullReferenceException with message "Pilot cannot be null.")
//AttackPoints – double
//DefensePoints - double
//HealthPoints - double
//Targets – collection of strings
