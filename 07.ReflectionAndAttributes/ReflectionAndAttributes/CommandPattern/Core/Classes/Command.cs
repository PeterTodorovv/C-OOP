using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern.Core.Contracts;


namespace CommandPattern.Core.Classes
{
    internal abstract class Command : ICommand
    {
        public abstract string Execute(string[] args);
        
    }
}
