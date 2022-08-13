using MahApps.Metro.Controls;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DNT.UI.ViewModels.Base
{
    /// <summary>
    /// Base class for List binding. 
    /// Contains Commands for adding new item in list as well updating and deleting existingitems
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class OverviewViewModelBase<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        #region Public properties
        public ObservableCollection<T> Items { get; set; }
        public T SelectedItem { get; set; }
        #endregion

        #region Commands
        public ICommand AddNewCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand LoadDataCommand { get; set; }

        #endregion

        #region CommandsHandlers
        protected abstract Task Load();
        protected abstract void Add();
        protected abstract void Edit();
        protected abstract Task Delete();
        #endregion

        public OverviewViewModelBase()
        {
            InitializeCommands();
        }

        #region Protected methods

        protected void UpdateRefresh(T item)
        {
            Items.Remove(item);
            Items.Add(item);
        }

        protected Window ShowCustomDialog(string title, int height)
        {
            var window = new MetroWindow
            {
                WindowState = WindowState.Normal,
                Width = 550,
                Height = height,
                Title = title,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            return window;
        }
        #endregion

        private void InitializeCommands()
        {
            AddNewCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit);
            DeleteCommand = new AsyncRelayCommand(Delete);
            LoadDataCommand = new AsyncRelayCommand(Load);
        }
    }
}