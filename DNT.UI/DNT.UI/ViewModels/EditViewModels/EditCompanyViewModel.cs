using DNT.DAL.Interfaces;
using DNT.DAL.Models;
using DNT.UI.Enums;
using DNT.UI.Utils;
using DNT.UI.ViewModels.Base;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DNT.UI.ViewModels.EditViewModels
{
    public class EditCompanyViewModel : CodebookBase<Company>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Private fields
        private readonly ICompanyRepository _repository;
        #endregion

        public EditCompanyViewModel(ICompanyRepository repository)
        {
            _repository = repository;
        }

        #region Abstract implemetations
        protected override async Task Save()
        {
            if (!Validate()) return;
            
            if (ForUpdate)
            {
                await _repository.Update(Model);
                DialogManager.ShowMessage("Firma uspješno ažurirana", OperationResult.Success);
                Window.Close();
            }
            else
            {
                await _repository.Create(Model);
                DialogManager.ShowMessage("Firma uspješno dodana", OperationResult.Success);
                Window.Close();
            }
        }

        protected override void AddValidationRules()
        {
            //throw new System.NotImplementedException();
        }
        #endregion
    }
}
