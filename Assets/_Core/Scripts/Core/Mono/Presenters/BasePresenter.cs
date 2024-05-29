using System;
using StarlingPlay.Core.Models;
using StarlingPlay.Core.Views;
using UnityEngine;

namespace StarlingPlay.Core.Presenters
{
    [RequireComponent(typeof(BaseView))]
    public abstract class BasePresenter : MonoBehaviour
    {
        protected BaseView DerivedView { get; private set; }
        protected IModel DerivedModel { get; private set; }

        protected virtual void Awake()
        {
            DerivedView = GetComponent<BaseView>();
        }

        public virtual void SetDerivedModel(IModel value)
        {
            DerivedModel = value;
        }

        public virtual void Rebuild()
        {
        }
    }

    public abstract class BasePresenter<TModel> : BasePresenter where TModel : IModel
    {
        protected TModel Model { get; private set; }

        public sealed override void SetDerivedModel(IModel value)
        {
            base.SetDerivedModel(value);

            if (value is TModel model)
            {
                SetModel(model);
            }
            else
                throw new InvalidCastException();
        }

        private void SetModel(TModel model)
        {
            Model = model;
        }
    }
    
    public abstract class BasePresenter<TView, TModel> : BasePresenter<TModel>
        where TModel : IModel
        where TView : BaseView
    {
        [SerializeField] private TView _view;

        protected TView View => _view;
    }
}