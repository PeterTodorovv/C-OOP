using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern
{
    internal class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] input = args.Split(' ');
            string commandName = input[0] + "Command"; 
            string[] parameters = input.Skip(1).ToArray();

            Type commandType = Assembly.GetCallingAssembly().GetTypes().Where(t => t.Name == commandName).FirstOrDefault();

            if(commandName == null)
            {
                throw new ArgumentException("Invalid Command");
            }

            ICommand command = (ICommand)Activator.CreateInstance(commandType);

            return command.Execute(parameters);
        }
    }
}