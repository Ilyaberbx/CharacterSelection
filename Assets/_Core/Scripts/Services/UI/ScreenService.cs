using System;
using System.Threading;
using System.Threading.Tasks;
using Better.Services.Runtime;
using StartlingPlay.Core.Models;
using StartlingPlay.Core.Presenters;
using StartlingPlay.UI.Systems;
using StartlingPlay.UI.Systems.Data;
using UnityEngine;

namespace StartlingPlay.Services.UI
{
    [Serializable]
    public class ScreenService : PocoService<UISettings>, IUISystem
    {
        [SerializeField] private RectTransform _uiRoot;

        private IUISystem _uiSystem;

        protected override async Task OnInitializeAsync(CancellationToken cancellationToken)
        {
            await base.OnInitializeAsync(cancellationToken);

            _uiSystem = new SingleUISystem(_uiRoot, Settings.Presenters);
        }

        #region IUISystem

        public Task<TPresenter> Open<TPresenter, TModel>(TModel model)
            where TPresenter : BasePresenter<TModel> where TModel : IModel => _uiSystem.Open<TPresenter, TModel>(model);

        public void Close() => _uiSystem.Close();

        #endregion
    }
}