using System;
using StarlingPlay.UI.Essentials;
using UnityEngine;

namespace StarlingPlay.Core.Views
{
    public class GameplayView : BaseView
    {
        public event Action OnBackClick;
        
        [SerializeField] private ActionButton _backButton;

        private void Awake() => _backButton.OnClick += OnBackClicked;

        private void OnDestroy() => _backButton.OnClick -= OnBackClicked;

        private void OnBackClicked() => OnBackClick?.Invoke();
    }
}