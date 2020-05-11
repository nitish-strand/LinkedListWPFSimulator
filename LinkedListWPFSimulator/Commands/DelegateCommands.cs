using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LinkedListWPFSimulator.Commands
{
    class DelegateCommands : ICommand
    {
        Action<object> actionOnMethod;  
        public DelegateCommands(Action<object> action)
        {
            actionOnMethod = action;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            actionOnMethod(parameter);
        }
    }
}
