using System.Threading.Tasks;
using StarlingPlay.Core.Models;
using StarlingPlay.Core.Presenters;

namespace StarlingPlay.UI.Systems
{
    public interface IUISystem
    {
        Task<TPresenter> Open<TPresenter, TModel>(TModel model)
            where TPresenter : BasePresenter<TModel>
            where TModel : IModel;

        void Close();
    }
}