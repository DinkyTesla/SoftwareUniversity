
namespace MortalEngines.Core
{
    using System;
    using System.Linq;

    public class Engine
    {
        private MachinesManager machinesManager;

        public Engine()
        {
            this.machinesManager = new MachinesManager();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "Quit")
            {
                try
                {
                    string[] inputArgs = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    string command = inputArgs[0];
                    string[] args = inputArgs.Skip(1).ToArray();

                    string result = ReadCommand(command, args);

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error" + ex.Message);
                }

                input = Console.ReadLine();
            }
        }

        private string ReadCommand(string command, string[] args)
        {
            string result = string.Empty;

            switch (command)
            {
                case "HirePilot":
                    string pilotName = args[0];

                    result = this.machinesManager.HirePilot(pilotName);
                    break;

                case "PilotReport":
                    pilotName = args[0];

                    result = this.machinesManager.PilotReport(pilotName);
                    break;

                case "ManufactureTank":
                    string tankName = args[0];
                    double tankAttackPoints = double.Parse(args[1]);
                    double tankDefensePoints = double.Parse(args[2]);

                    result = this.machinesManager.ManufactureTank(tankName, tankAttackPoints, tankDefensePoints);
                    break;

                case "ManufactureFighter":
                    string fighterName = args[0];
                    double fighterAttackPoints = double.Parse(args[1]);
                    double fighterDefensePoints = double.Parse(args[2]);

                    result = this.machinesManager.ManufactureFighter(fighterName, fighterAttackPoints, fighterDefensePoints);
                    break;

                case "MachineReport":
                    string machineName = args[0];

                    result = this.machinesManager.MachineReport(machineName);
                    break;

                case "AggressiveMode":
                    machineName = args[0];

                    result = this.machinesManager.ToggleFighterAggressiveMode(machineName);
                    break;

                case "DefenseMode":
                    machineName = args[0];

                    result = this.machinesManager.ToggleTankDefenseMode(machineName);
                    break;

                case "Engage":
                    pilotName = args[0];
                    machineName = args[1];

                    result = this.machinesManager.EngageMachine(pilotName, machineName);
                    break;

                case "Attack":
                    string attackingMachineName = args[0];
                    string defendingMachineName = args[1];

                    result = this.machinesManager.AttackMachines(attackingMachineName, defendingMachineName);
                    break;

                default:
                    break;
            }

            return result;
        }
    }
}
