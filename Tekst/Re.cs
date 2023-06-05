using System;
using System.Windows.Input;

namespace Tekst
{
    internal class Re : ICommand
    {
        private readonly Predicate<object> canExecute;
        private readonly Action<object> execute;

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Re(Action<object> execute, Predicate<object> predicate = null)
        {
            this.execute = execute;
            this.canExecute = predicate;
        }
    }
}
