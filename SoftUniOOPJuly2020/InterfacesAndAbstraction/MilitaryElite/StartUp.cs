using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            // Да оправя try catcha pri commando
            string[] soldierInput = Console.ReadLine().Split();
            List<ISoldier> soldiers = new List<ISoldier>();
            Dictionary<int, ISoldier> privates = new Dictionary<int, ISoldier>();


            while (soldierInput[0] != "End")
            {
                int id = int.Parse(soldierInput[1]);
                string firstName = soldierInput[2];
                string lastName = soldierInput[3];
                decimal salary = decimal.Parse(soldierInput[4]);


                switch (soldierInput[0])
                {
                    case "Private":
                        ISoldier @private = new Private(id, firstName, lastName, salary);
                        soldiers.Add(@private);
                        privates.Add(id, @private);
                        break;
                    case "Spy":
                        int codeNumber = int.Parse(soldierInput[4]);
                        soldiers.Add(new Spy(id, firstName, lastName, codeNumber));
                        break;
                    case "LieutenantGeneral":
                        var lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);
                        int[] privateIds = soldierInput.Skip(5).Select(int.Parse).ToArray();
                        foreach (var privId in privateIds)
                        {
                            lieutenantGeneral.AddPrivate(privates[privId]);
                        }

                        soldiers.Add(lieutenantGeneral);
                        break;
                    case "Engineer":
                        string corps = string.Empty;
                        try
                        {
                            corps = soldierInput[5];
                            var engineer = new Engineer(id, firstName, lastName, salary, corps);
                            string[] repairs = soldierInput.Skip(6).ToArray();

                            for (int i = 0; i < repairs.Length; i += 2)
                            {
                                Repair repari = new Repair(repairs[i], int.Parse(repairs[i + 1]));//IRepair ?!
                                engineer.AddRepair(repari);
                            }

                            soldiers.Add(engineer);
                        }
                        catch (InvalidCorpsException)
                        {
                        }
                       

                        
                        break;
                    case "Commando":
                        string corpsCom = string.Empty;
                        try
                        {
                            corpsCom = soldierInput[5];
                            string[] missions = soldierInput.Skip(6).ToArray();
                            var commando = new Commando(id, firstName, lastName, salary, corpsCom);
                            for (int i = 0; i < missions.Length; i += 2)
                            {
                                try
                                {
                                    Mission mission = new Mission(missions[i], missions[i + 1]);
                                    commando.AddMission(mission);
                                }
                                catch (InvalidMissionException)
                                {


                                }
                                catch (InvalidStateException)
                                {

                                }

                            }
                            soldiers.Add(commando);
                        }
                        catch (InvalidCorpsException)
                        {

                        }

                        

                        break;

                    default:
                        break;
                }

                soldierInput = Console.ReadLine().Split();
            }
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }

        }

    }
}
