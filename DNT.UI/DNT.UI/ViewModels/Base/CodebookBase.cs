using DNT.UI.Enums;
using DNT.UI.Utils;
using Microsoft.Toolkit.Mvvm.Input;
using MvvmValidation;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DNT.UI.ViewModels.Base
{
    public abstract class CodebookBase<T>: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Public properties
        public T Model { get; set; }
        public bool ForUpdate { get; set; }
        public Window Window { get; set; }
        public ValidationHelper Validator { get; private set; }
        private NotifyDataErrorInfoAdapter NotifyDataErrorInfoAdapter { get; set; }
        #endregion

        #region Commands
        public ICommand SaveCommand { get; set; }
        #endregion

        #region Command handlers
        protected abstract Task Save();
        #endregion

        protected abstract void AddValidationRules();

        public CodebookBase()
        {
            Validator = new ValidationHelper();
            NotifyDataErrorInfoAdapter = new NotifyDataErrorInfoAdapter(Validator);
            InitializeCommands();
            AddValidationRules();
        }

        private void InitializeCommands()
        {
            SaveCommand = new AsyncRelayCommand(Save);
        }

        public bool Validate()
        {
            ValidationResult validationResult = Validator.ValidateAll();

            if (!validationResult.IsValid)
                DialogManager.ShowMessage("Potrebno je ispuniti potrebne podatke", OperationResult.Error);
            return validationResult.IsValid;
        }

    }
}
