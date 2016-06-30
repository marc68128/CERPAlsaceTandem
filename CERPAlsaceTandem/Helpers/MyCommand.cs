using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CERPAlsaceTandem.Helpers
{
    public class MyCommand : ICommand
    {
        private Func<bool> _canExecuteFunc;
        private Action _execute; 
        public MyCommand(Func<bool> canExecute, Action execute)
        {
            if (canExecute != null)
                _canExecuteFunc = canExecute;
            else
                _canExecuteFunc = () => true;

            if (execute != null)
                _execute = execute;
            else
                _execute = () => { };
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteFunc.Invoke();
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }

        public event EventHandler CanExecuteChanged;
    }
}
