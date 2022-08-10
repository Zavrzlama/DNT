using DNT.DAL.Interfaces;
using DNT.DAL.Models;
using DNT.UI.Utils;
using DNT.UI.ViewModels.Base;
using DNT.UI.ViewModels.EditViewModels;
using DNT.UI.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace DNT.UI.ViewModels.OverviewViewModels
{
    public class UserOverviewViewModel : OverviewViewModelBase<User>
    {
        private readonly IUserRepository _repository;

        public UserOverviewViewModel(IUserRepository repository)
        {
            _repository = repository;
            LoadDataCommand.Execute(null);
        }

        #region Abstract implemntation
        protected override async Task Load()
        {
            var list = await _repository.GetAll();
            Items = new ObservableCollection<User>(list);
        }

        protected override void Add()
        {
            var window = ShowCustomDialog("Novi korisnik", 500);
            var viewModel = SetUpViewModel(window, false);
            var editView = new EditUserView(viewModel);
            window.Content = editView;
            window.ShowDialog();
            if (viewModel.HasErors)
            {
                Items.Add(viewModel.Model);
            }
        }

        protected override void Edit()
        {
            var window = ShowCustomDialog("Novi korisnik", 500);
            var viewModel = SetUpViewModel(window, true);
            var editView = new EditUserView(viewModel);
            window.Content = editView;
            window.ShowDialog();
        }

        protected override async Task Delete()
        {
            var result = DialogManager.ShowDialog("Jeste li sigurni da želite obrisati korisnika?");
            if (result == Enums.DialogResult.Yes) { 
                await _repository.Delete(SelectedItem.Id);
                Items.Remove(SelectedItem);
            }
        }
        #endregion

        private EditUserViewModel SetUpViewModel(Window window, bool forUpdate)
        {
            var viewModel = App.ServiceProvider.GetRequiredService<EditUserViewModel>();
            viewModel.ForUpdate = forUpdate;
            viewModel.Window = window;
            viewModel.Model = forUpdate ? SelectedItem : new User();
            return viewModel;
        }
    }

}
