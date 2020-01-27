namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots;
        protected List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            foreach (var pilotToCheck in pilots)
            {
                if (pilotToCheck.Name == name)
                {
                    return $"Pilot {name} is hired already";
                }
            }

            Pilot pilot = new Pilot(name);
            this.pilots.Add(pilot);

            return $"Pilot {name} hired";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            foreach (var machineToCheck in machines)
            {
                if (machineToCheck.Name == name)
                {
                    return $"Machine {name} is manufactured already";
                }
            }

            Tank tank = new Tank(name, attackPoints, defensePoints);
            this.machines.Add(tank);

            return $"Tank {tank.Name} manufactured - attack: {tank.AttackPoints:f2}; defense: {tank.DefensePoints:f2}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            foreach (var machineToCheck in machines)
            {
                if (machineToCheck.Name == name)
                {
                    return $"Machine {name} is manufactured already";
                }
            }

            Fighter fighter = new Fighter(name, attackPoints, defensePoints);
            this.machines.Add(fighter);

            return $"Fighter {fighter.Name} manufactured - attack: {fighter.AttackPoints:f2}; defense: {fighter.DefensePoints:f2}; aggressive: ON";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            bool searchEndsRedForTheTank = false;

            foreach (var pilotToCheck in pilots)
            {
                if (pilotToCheck.Name == selectedPilotName)
                {
                    foreach (var machineToCheck in machines)
                    {
                        if (machineToCheck.Name == selectedMachineName && machineToCheck.Pilot == null)
                        {
                            machineToCheck.Pilot = (pilotToCheck);
                            pilotToCheck.AddMachine(machineToCheck);
                            return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
                        }
                        else if (machineToCheck.Name == selectedMachineName)
                        {

                            return $"Machine {selectedMachineName} is already occupied";
                        }
                        else
                        {
                            searchEndsRedForTheTank = true;
                        }
                    }
                }
            }

            if (searchEndsRedForTheTank)
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            return $"Pilot {selectedPilotName} could not be found";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            bool defMachineIsMissing = false;

            foreach (var machineToAttack in machines)
            {
                if (machineToAttack.Name == attackingMachineName)
                {
                    if (machineToAttack.HealthPoints <= 0)
                    {
                        return $"Dead machine {attackingMachineName} cannot attack or be attacked";
                    }
                    foreach (var machineToDefend in machines)
                    {
                        if (machineToDefend.Name == defendingMachineName)
                        {
                            if (machineToDefend.HealthPoints <= 0)
                            {
                                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
                            }

                            machineToAttack.Attack(machineToDefend);

                            return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {machineToDefend.HealthPoints:f2}";
                        }

                        defMachineIsMissing = true;
                    }
                }
            }

            if (defMachineIsMissing)
            {
                return $"Machine {defendingMachineName} could not be found";

            }

            return $"Machine {attackingMachineName} could not be found";
        }

        public string PilotReport(string pilotReporting)
        {
            var result = string.Empty;

            foreach (var pilotToCheck in pilots)
            {
                if (pilotToCheck.Name == pilotReporting)
                {
                    result = pilotToCheck.Report();
                }
            }

            return result;
        }

        public string MachineReport(string machineName)
        {
            var result = string.Empty;

            foreach (var machineToReport in machines)
            {
                if (machineToReport.Name == machineName)
                {
                    result = machineToReport.ToString();
                }
            }

            return result;
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            foreach (Fighter fighterToSearchFor in machines)
            {
                if (fighterToSearchFor.Name == fighterName)
                {
                    fighterToSearchFor.ToggleAggressiveMode();

                    return $"Fighter {fighterToSearchFor.Name} toggled aggressive mode";
                }
            }

            return $"Machine {fighterName} could not be found";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            foreach (Tank tankToSearchFor in machines)
            {
                if (tankToSearchFor.Name == tankName)
                {
                    tankToSearchFor.ToggleDefenseMode();

                    return $"Tank {tankToSearchFor.Name} toggled defense mode";
                }
            }

            return $"Machine {tankName} could not be found";
        }
    }
}