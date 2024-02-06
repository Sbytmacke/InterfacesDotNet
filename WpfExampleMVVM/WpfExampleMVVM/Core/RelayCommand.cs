using System;
using System.Windows.Input;

namespace WpfExampleMVVM.Core;

internal class RelayCommand : ICommand
{
    // Como los comandos son acciones podemos crear esto:
    private Action<object?>? _execute;
    private Func<object, bool>? _canExecute;

    // En el ViewModel hay que crear un RelayCommand
    public RelayCommand(Action<object?>? execute, Func<object, bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    // Como es una función podemos hacer esto
    public event EventHandler? CanExecuteChanged
    {
        // Esto sería como un mini-crud, de las propiedades 
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute == null || _canExecute(parameter);
    }

    public void Execute(object? parameter) => _execute?.Invoke(parameter);
}
