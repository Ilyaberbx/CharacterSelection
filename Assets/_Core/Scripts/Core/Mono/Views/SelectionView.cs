using System;
using StarlingPlay.UI.Essentials;
using UnityEngine;
using UnityEngine.UI;

namespace StarlingPlay.Core.Views
{
    public class SelectionView : BaseView
    {
        public event Action OnGenerateClick;
        public event Action OnPlayClick;
        
        [SerializeField] private Image _currentIcon;
        [SerializeField] private ActionButton _generateButton;
        [SerializeField] private ActionButton _playButton;
        
        private void Awake()
        {
            _generateButton.OnClick += OnGenerateClicked;
            _playButton.OnClick += OnPlayClicked;
        }

        private void OnDestroy()
        {
            _generateButton.OnClick -= OnGenerateClicked;
            _playButton.OnClick -= OnPlayClicked;
        }

        public void Rebuild(Sprite icon)
        {
            _currentIcon.sprite = icon;
            _currentIcon.color = Color.white;
        }

        private void OnGenerateClicked()
        {
            OnGenerateClick?.Invoke();
        }

        private void OnPlayClicked()
        {
            OnPlayClick?.Invoke();
        }
    }
}