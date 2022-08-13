using Microsoft.Toolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DNT.UI.ViewModels.Base
{

    /// <summary>
    /// Base class for filtering list of generic items. 
    /// Extends OverviewViewModelBase which contains properties for simple List and SelectedItem bindings
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class OverviewFilterBase<T> : OverviewViewModelBase<T>
    {
        public T Filter { get; set; }

        #region Commands
        public ICommand ClearCommand { get; set; }
        public ICommand FindCommand { get; set; }
        #endregion

        #region Command handlers
        protected abstract Task Clear();
        protected abstract Task Find();
        #endregion

        public OverviewFilterBase()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            ClearCommand = new AsyncRelayCommand(Clear);
            FindCommand = new AsyncRelayCommand(Find);
        }
    }
}
