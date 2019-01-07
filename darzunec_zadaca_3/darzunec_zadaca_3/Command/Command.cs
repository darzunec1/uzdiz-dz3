using System;
using System.Collections.Generic;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Models;

namespace org.foi.uzdiz.darzunec.dz3.Command
{
    public interface ICommand
    {
        void Execute();
    }

    public class Switch
    {
        private List<ICommand> _commands = new List<ICommand>();

        public void StoreAndExecute(ICommand command) 
        {
            _commands.Add(command);
            command.Execute();
        }
    }
}
