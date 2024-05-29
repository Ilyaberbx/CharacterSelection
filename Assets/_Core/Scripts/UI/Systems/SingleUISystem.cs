using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Better.Commons.Runtime.Utility;
using StartlingPlay.Core;
using StartlingPlay.Core.Models;
using StartlingPlay.Core.Presenters;
using StartlingPlay.Services.UI.Data;
using UnityEngine;
using Object = UnityEngine.Object;

namespace StartlingPlay.UI.Systems
{
    public class SingleUISystem : IUISystem
    {
        private readonly RectTransform _root;
        private readonly IReadOnlyList<PresenterData> _presenters;

        private BasePresenter _currentPresenter;

        public SingleUISystem(RectTransform root, IReadOnlyList<PresenterData> presenters)
        {
            _root = root;
            _presenters = presenters;
        }

        public Task<TPresenter> Open<TPresenter, TModel>(TModel model)
            where TPresenter : BasePresenter<TModel>
            where TModel : IModel
        {
            var data = _presenters.FirstOrDefault(presenter => presenter.Type == typeof(TPresenter));

            if (data == null)
            {
                DebugUtility.LogException<NullReferenceException>();
                return Task.FromResult<TPresenter>(null);
            }

            Debug.Log("Open Single UI: " + typeof(TPresenter).Name);
            
            var presenter = Object.Instantiate(data.Prefab, _root).GetComponent<TPresenter>();

            presenter.SetDerivedModel(model);

            Close();

            _currentPresenter = presenter;

            return Task.FromResult(presenter);
        }

        public void Close()
        {
            if (_currentPresenter == null)
                return;

            Object.Destroy(_currentPresenter.gameObject);
        }
    }
}