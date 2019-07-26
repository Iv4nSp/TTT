using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TicTacToe
{
        public class CommandHandler : ICommand
        {
            private Action<object> _action;
            private Func<object, bool> _canExecute;
            public CommandHandler(Func<object, bool> canExecute, Action<object> action)
            {
                _action = action;
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute(parameter);
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                _action(parameter);
            }
        }
        /// <summary>
        /// Command handler za gumb za novu igru
        /// </summary>
        public class CommandHandlerNew : ICommand
        {
            private Action<object> _action;
            private Func<object, bool> _canExecute;
            public CommandHandlerNew(Func<object, bool> canExecute, Action<object> action)
            {
                _action = action;
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute(parameter);
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                _action(parameter);
            }
    }
}
