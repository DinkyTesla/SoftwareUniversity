
namespace MortalEngines.Entities
{
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Pilot : IPilot
    {
        private string name;
        private List<IMachine> machinesToPilot;

        public Pilot(string name)
        {
            this.Name = name;
            this.machinesToPilot = new List<IMachine>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }

            this.machinesToPilot.Add(machine);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine($"{this.Name} - {this.machinesToPilot.Count} machines");

            foreach (var machine in this.machinesToPilot)
            {
                report.AppendLine($"- {machine.Name}");
                report.AppendLine($" *Type: {GetType().Name}");
                report.AppendLine($" *Health: {machine.HealthPoints}");
                report.AppendLine($" *Attack: {machine.AttackPoints}");
                report.AppendLine($" *Defense: {machine.DefensePoints}");
                report.AppendLine($" *Targets: {machine.Targets}");
            }

            string result = report.ToString().TrimEnd();

            return result;
        }
    }
}
