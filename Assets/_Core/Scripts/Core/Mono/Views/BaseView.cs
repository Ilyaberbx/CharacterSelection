using Better.Commons.Runtime.Components.UI;
using UnityEngine;

namespace StartlingPlay.Core.Views
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class BaseView : UIMonoBehaviour
    {
        private CanvasGroup _canvasGroup;

        protected CanvasGroup CanvasGroup
        {
            get
            {
                if (_canvasGroup == null)
                {
                    _canvasGroup = GetComponent<CanvasGroup>();
                }

                return _canvasGroup;
            }
        }

        public bool Interactable
        {
            get => CanvasGroup.interactable;
            set => CanvasGroup.interactable = value;
        }

        public bool BlocksRayCasts
        {
            get => CanvasGroup.blocksRaycasts;
            set => CanvasGroup.blocksRaycasts = value;
        }
    }
}