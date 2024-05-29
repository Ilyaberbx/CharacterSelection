using Better.Locators.Runtime;
using Better.SceneManagement.Runtime;
using StarlingPlay.Core.Models;
using StarlingPlay.Core.Views;
using StarlingPlay.Extensions;
using StarlingPlay.Utility;

namespace StarlingPlay.Core.Presenters
{
    public class GameplayPresenter : BasePresenter<GameplayView, GameplayModel>
    {
        private readonly ServiceProperty<SceneService> _sceneServiceProperty = new();
        private SceneService SceneService => _sceneServiceProperty.CachedService;

        private void Start() => View.OnBackClick += OnBackClicked;

        private void OnDestroy() => View.OnBackClick -= OnBackClicked;

        private void OnBackClicked()
        {
            View.Interactable = false;

            var scene = Model.BackScene;

            using var additiveTransition = SceneService.CreateAdditiveTransition();
            
            additiveTransition
                .SafeUnloadAll()
                .LoadScene(scene)
                .RunWithActive(scene);
            
            UIUtility.CloseAll();
        }
    }
}