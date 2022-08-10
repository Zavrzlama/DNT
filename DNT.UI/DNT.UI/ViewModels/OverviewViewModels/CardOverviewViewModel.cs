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
    public class CardOverviewViewModel : OverviewViewModelBase<Card>
    {
        private readonly ICardRepository _cardRepository;

        public CardOverviewViewModel(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
            LoadDataCommand.Execute(null);
        }

        #region Abstract implementation
        protected override void Add()
        {
            var window = ShowCustomDialog("Nova kartica", 500);
            var viewModel = SetUpViewModel(window, false);
            window.Content = new EditCardView(viewModel); ;
            window.ShowDialog();

            Items.Add(viewModel.Model);
        }

        protected async override Task Delete()
        {
            var result = DialogManager.ShowDialog("Jeste li sigurni da želite obrisati firmu?");
            if (result == Enums.DialogResult.Yes)
                await _cardRepository.Delete(SelectedItem.Id);
        }

        protected override void Edit()
        {
            var window = ShowCustomDialog("Ažuriraj karticu", 300);
            var viewModel = SetUpViewModel(window, true);
            window.Content = new EditCardView(viewModel);

            window.ShowDialog();

        }

        protected async override Task Load()
        {
            var list = await _cardRepository.GetCardsForOverview();
            Items = new ObservableCollection<Card>(list);
        }
        #endregion

        private EditCardViewModel SetUpViewModel(Window window, bool forUpdate)
        {
            var viewModel = App.ServiceProvider.GetRequiredService<EditCardViewModel>();
            viewModel.ForUpdate = forUpdate;
            viewModel.Window = window;
            viewModel.Model = forUpdate ? SelectedItem : new Card();
            return viewModel;
        }
    }
}
