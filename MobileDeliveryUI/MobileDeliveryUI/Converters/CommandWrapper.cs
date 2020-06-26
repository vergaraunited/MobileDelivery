namespace MobileDeliveryUniversal.Converters
{
    using System;
    using System.Windows.Input;

    public class CommandWrapper : ICommand
    {
        public CommandWrapper(MobileDeliveryMVVM.Command.ICommand source)
        {
            _source = source;
            _source.CanExecuteChanged += OnSource_CanExecuteChanged;
            SimpleCommandManager.RequerySuggested += OnCommandManager_RequerySuggested;
        }

        public void Execute(object parameter)
        {
            _source.Execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return _source.CanExecute(parameter);
        }

        public event System.EventHandler CanExecuteChanged = delegate { };


        // Implementation.
        private void OnSource_CanExecuteChanged(object sender, EventArgs args)
        {
            CanExecuteChanged(sender, args);
        }

        private void OnCommandManager_RequerySuggested(object sender, EventArgs args)
        {
            CanExecuteChanged(sender, args);
        }

        private readonly MobileDeliveryMVVM.Command.ICommand _source;
    }
}
