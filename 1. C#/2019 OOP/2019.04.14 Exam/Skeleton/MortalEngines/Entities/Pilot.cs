using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {
        private string name;
        private List<string> machines;
        private List<IMachine> testMachines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<string>();
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

            this.machines.Add(machine.Name);
            this.testMachines.Add(machine);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine($"{this.Name} - {machines.Count} machines");

            foreach (var machine in testMachines)
            {
                report.AppendLine($"- {machine.Name}");
                report.AppendLine($" *Type: {this.GetType().Name}");
                report.AppendLine($" *Health: {machine.HealthPoints}");
                report.AppendLine($" *Attack: {machine.AttackPoints}");
                report.AppendLine($" *Defense: {machine.DefensePoints}");
                report.AppendLine($" *Targets: {machine.Targets}");
            }
            return report.ToString().TrimEnd();
        }
    }
}
