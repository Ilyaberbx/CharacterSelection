using System.Threading.Tasks;
using StartlingPlay.Core;
using StartlingPlay.Core.Models;
using StartlingPlay.Core.Presenters;

namespace StartlingPlay.UI.Systems
{
    public interface IUISystem
    {
        Task<TPresenter> Open<TPresenter, TModel>(TModel model)
            where TPresenter : BasePresenter<TModel>
            where TModel : IModel;

        void Close();
    }
}