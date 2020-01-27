namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private List<string> hiredPilotsList;
        private List<IPilot> pilots;
        private List<Tank> currentTanks;
        private List<Fighter> currentFighters;
        private List<string> manufacturedTanks;
        private List<string> manufacturedFighters;

        private List<BaseMachine> testMachines;

        public string HirePilot(string name)
        {
            if (hiredPilotsList.Contains(name))
            {
                return $"Pilot {name} is hired already";
            }

            Pilot pilot = new Pilot(name);
            hiredPilotsList.Add(name);
            return $"Pilot {name} hired";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (manufacturedTanks.Contains(name))
            {
                return $"Machine {name} is manufactured already";
            }

            Tank tank = new Tank(name, attackPoints, defensePoints);
            currentTanks.Add(tank);
            manufacturedTanks.Add(tank.Name);
            testMachines.Add(tank);

            return $"Tank {name} manufactured - attack: {attackPoints}; defense: {defensePoints}";

        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (manufacturedFighters.Contains(name))
            {
                return $"Machine {name} is manufactured already";
            }

            Fighter fighter = new Fighter(name, attackPoints, defensePoints);
            currentFighters.Add(fighter);
            manufacturedFighters.Add(fighter.Name);
            testMachines.Add(fighter);

            return $"Fighter {name} manufactured - attack: {attackPoints}; defense: {defensePoints}; aggressive: ON";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (!hiredPilotsList.Contains(selectedPilotName))
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            if (!manufacturedTanks.Contains(selectedMachineName) || !manufacturedTanks.Contains(selectedMachineName))
            {
                return $"Machine {selectedMachineName} could not be found";
            }
            //foreach (var machine in testMachines)
            //{
            //    if (machine.Name == selectedMachineName)
            //    {
            //        if (machine[])
            //        {

            //        }
            //    }
            //    else
            //    {
            //        return $"Machine {selectedMachineName} could not be found";
            //    }
            //}
            foreach (var tank in currentTanks)
            {
                if (tank.Name == selectedMachineName)
                {
                    if (tank.IsEngaged)
                    {
                        return $"Machine {selectedMachineName} is already occupied";
                    }
                }
            }
            foreach (var fighter in currentFighters)
            {
                if (fighter.Name == selectedMachineName)
                {
                    if (fighter.IsEngaged)
                    {
                        return $"Machine {selectedMachineName} is already occupied";
                    }
                }
            }

            foreach (var pilot in pilots)
            {
                if (pilot.Name == selectedPilotName)
                {
                    foreach (var fighter in currentFighters)
                    {
                        if (fighter.Name == selectedMachineName)
                        {
                            pilot.AddMachine(fighter);
                        }
                    }
                    foreach (var tank in currentTanks)
                    {
                        if (tank.Name == selectedMachineName)
                        {
                            pilot.AddMachine(tank);
                        }
                    }
                }

            }
            return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            if (!manufacturedFighters.Contains(attackingMachineName))
            {
                return $"Machine {attackingMachineName} could not be found";
            }
            if (!manufacturedFighters.Contains(defendingMachineName))
            {
                return $"Machine {defendingMachineName} could not be found";
            }
            if (!manufacturedTanks.Contains(attackingMachineName))
            {
                return $"Machine {attackingMachineName} could not be found";
            }
            if (!manufacturedTanks.Contains(defendingMachineName))
            {
                return $"Machine {defendingMachineName} could not be found";
            }

            foreach (var fighter in currentFighters)
            {
                if (fighter.HealthPoints <= 0)
                {
                    return $"Dead machine {fighter.Name} cannot attack or be attacked";
                }
            }
            foreach (var tank in currentTanks)
            {
                if (tank.HealthPoints <= 0)
                {
                    return $"Dead machine {tank.Name} cannot attack or be attacked";
                }
            }

            var result = string.Empty;

            foreach (var attacker in testMachines)
            {
                if (attacker.Name == attackingMachineName)
                {
                    foreach (var defender in testMachines)
                    {
                        if (defender.Name == defendingMachineName)
                        {
                            attacker.Attack(defender);
                            double defenderHealthPoints = defender.HealthPoints;
                            result = $"Machine {defender.Name} was attacked by machine {attacker.Name} - current health: {defenderHealthPoints}";
                        }
                    }
                }
            }

            //if (manufacturedTanks.Contains(defendingMachineName))
            //{
            //    foreach (var tank in currentTanks)
            //    {
            //        if (tank.Name == defendingMachineName)
            //        {
            //            defMachineHealt = tank.HealthPoints;
            //        }
            //    }
            //}
            //else if (manufacturedFighters.Contains(defendingMachineName))
            //{
            //    foreach (var fighter in currentFighters)
            //    {
            //        if (fighter.Name == defendingMachineName)
            //        {
            //            defMachineHealt = fighter.HealthPoints;
            //        }
            //    }
            //}

            return result;
        }

        public string PilotReport(string pilotReporting)
        {
            var result = string.Empty;

            foreach (var pilot in pilots)
            {
                if (pilot.Name == pilotReporting)
                {
                    result = pilot.Report();
                }

            }

            return result;
        }

        public string MachineReport(string machineName)
        {
            var result = string.Empty;
            foreach (var machine in testMachines)
            {
                result = machine.ToString();
            }
            return result;
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var result = string.Empty;

            foreach (var fighter in currentFighters)
            {
                if (fighter.Name == fighterName)
                {
                    fighter.ToggleAggressiveMode();
                    result = $"Fighter {fighterName} toggled aggressive mode";
                }
                else
                {
                    result = $"Machine {fighterName} could not be found";
                }
            }

            return result;
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var result = string.Empty;

            foreach (var tank in currentTanks)
            {
                if (tank.Name == tankName)
                {
                    tank.ToggleDefenseMode();
                    result = $"Fighter {tankName} toggled aggressive mode";
                }
                else
                {
                    result = $"Machine {tankName} could not be found";
                }
            }

            return result;
        }
    }
}