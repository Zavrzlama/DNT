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
    public class CompanyOverviewViewModel : OverviewFilterBase<Company>
    {
        private readonly ICompanyRepository _repository;

        public CompanyOverviewViewModel(ICompanyRepository repository)
        {
            _repository = repository;
            LoadDataCommand.Execute(null);
        }

        #region Abstract implementation
        protected override void Add()
        {
            var window = ShowCustomDialog("Nova firma", 500);
            var viewModel = SetUpViewModel(window, false);
            window.Content = new EditCompanyView(viewModel); ;
            window.ShowDialog();

            Items.Add(viewModel.Model);
        }

        protected override async Task Delete()
        {
            var result = DialogManager.ShowDialog("Jeste li sigurni da želite obrisati firmu?");
            if (result == Enums.DialogResult.Yes)
                await _repository.Delete(SelectedItem.Id);
        }

        protected override void Edit()
        {
            var window = ShowCustomDialog("Ažuriraj firmu", 500);
            var viewModel = SetUpViewModel(window, true);
            window.Content = new EditCompanyView(viewModel);

            window.ShowDialog();
        }

        protected override Task Clear()
        {
            throw new System.NotImplementedException();
        }

        protected override Task Find()
        {
            throw new System.NotImplementedException();
        }

        protected override async Task Load()
        {
            var list = await _repository.GetAll();
            Items = new ObservableCollection<Company>(list);
        }
        #endregion

        private EditCompanyViewModel SetUpViewModel(Window window, bool forUpdate)
        {
            var viewModel = App.ServiceProvider.GetRequiredService<EditCompanyViewModel>();
            viewModel.ForUpdate = forUpdate;
            viewModel.Window = window;
            viewModel.Model = forUpdate ? SelectedItem : new Company();
            return viewModel;
        }
    }
}