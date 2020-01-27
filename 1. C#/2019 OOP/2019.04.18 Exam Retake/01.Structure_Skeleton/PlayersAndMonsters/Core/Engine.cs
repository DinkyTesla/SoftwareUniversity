
using PlayersAndMonsters.Core.Contracts;
using System;
using System.Linq;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private ManagerController managerController;

        public Engine()
        {
            this.managerController = new ManagerController();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "Exit")
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
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }
        }

        private string ReadCommand(string command, string[] args)
        {

            string result = string.Empty;

            switch (command)
            {
                case "AddPlayer":
                    string playerType = args[0];
                    string playerName = args[1];

                    result = this.managerController.AddPlayer(playerType, playerName);
                    break;

                case "AddCard":
                    string cardType = args[0];
                    string cardName = args[1];

                    result = this.managerController.AddCard(cardType, cardName);
                    break;

                case "AddPlayerCard":
                    string username = args[0];
                     cardName = args[1];

                    result = this.managerController.AddPlayerCard(username, cardName);
                    break;

                case "Fight":
                    string attackUser = args[0];
                    string enemyUser = args[1];

                    result = this.managerController.Fight(attackUser, enemyUser);
                    break;

                case "Report":

                    result = this.managerController.Report();
                    break;
            }

            return result;
        }
    }
}
