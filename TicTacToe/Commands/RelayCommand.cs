using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TicTacToe.Commands
{
    internal class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private readonly Action<object>? _execute;
        private readonly Predicate<object>? _canExecute;
        private ICommand? newGameCommand;

        public RelayCommand(Action<object>? execute, Predicate<object>? canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object>? execute) : this(execute, null)
        {
            _execute = execute;
        }

        public RelayCommand(ICommand? newGameCommand)
        {
            this.newGameCommand = newGameCommand;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute?.Invoke(parameter);
        }
    }

}
