using System;
using Better.Commons.Runtime.Components.UI;
using UnityEngine;
using UnityEngine.UI;

namespace StartlingPlay.Core.UI.Essentials
{
    public class ActionButton : UIMonoBehaviour
    {
        public event Action OnClick;
        
        [SerializeField] private Button _button;

        private void Awake() => _button.onClick.AddListener(OnClicked);

        private void OnDestroy() => _button.onClick.RemoveListener(OnClicked);

        private void OnClicked() => OnClick?.Invoke();
    }
}