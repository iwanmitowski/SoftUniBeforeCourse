using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern
{
    class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string commandName = args.Split().First();
            string[] arguments = args.Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();

            Type classType = Type.GetType($"{commandName}Command");

            Type commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.Name == $"{commandName}Command")
                .FirstOrDefault();


            ICommand command = (ICommand)Activator.CreateInstance(commandType);

            string result = command.Execute(arguments);

            return result;
        }
    }
}
