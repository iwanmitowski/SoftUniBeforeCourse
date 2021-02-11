using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (type != "Beast!")
            {
                if (input.Length!=3)
                {

                    type = Console.ReadLine();
                    input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }
                try
                {
                    string name = input[0];
                    int age;
                    if (!int.TryParse(input[1],out age))
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                                       
                    string gender = string.Empty;
                    if (type!="Kittens"&&type!="Tomcat")
                    {
                        gender = input[2];

                    }

                    if (age <= 0)
                    {
                        throw new ArgumentException("Invalid input!");

                        type = Console.ReadLine();
                        input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }

                    switch (type)
                    {
                        case "Dog":
                            Dog dog = new Dog(name, age, gender);
                            Console.WriteLine(dog);
                            dog.ProduceSound();
                            break;
                        case "Cat":
                            Cat cat = new Cat(name, age, gender);
                            Console.WriteLine(cat);
                            cat.ProduceSound();
                            break;
                        case "Frog":
                            Frog frog = new Frog(name, age, gender);
                            Console.WriteLine(frog);
                            frog.ProduceSound();
                            break;
                        case "Kittens":
                            Kitten kitten = new Kitten(name, age);
                            Console.WriteLine(kitten);
                            kitten.ProduceSound();
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(name, age);
                            Console.WriteLine(tomcat);
                            tomcat.ProduceSound();
                            break;

                        default:
                            throw new ArgumentException("Invalid input!");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }



                type = Console.ReadLine();
                if (type=="Beast!")
                {
                    break;
                }
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

        }
    }
}
