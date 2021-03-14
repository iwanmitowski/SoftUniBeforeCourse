using PlayersAndMonsters.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Core
{
    class Engine : IEngine
    {
        private readonly ManagerController managerController;
        public Engine()
        {
            this.managerController = new ManagerController();
        }
        public void Run()
        {
            while (true)
            {
                try
                {
                    var input = Console.ReadLine().Split().ToArray();
                    string command = input[0];

                    if (command=="Exit")
                    {
                        Environment.Exit(0);
                    }
                    else if (command=="AddPlayer")
                    {
                        string playerType = input[1];
                        string name = input[2];

                        managerController.AddPlayer(playerType, name);
                    }
                    else if (command == "AddCard")
                    {
                        string cardType = input[1];
                        string name = input[2];

                        managerController.AddCard(cardType, name);
                    }
                    else if (command == "AddPlayerCard")
                    {
                        string name = input[1];
                        string cardName = input[2];

                        managerController.AddPlayerCard(name,cardName);
                    }
                    else if (command == "Fight")
                    {
                        string attackUser = input[1];
                        string enemyUser = input[2];

                        managerController.Fight(attackUser, enemyUser);
                    }
                    else if (command=="Report")
                    {
                        Console.WriteLine(managerController.Report()); 
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
