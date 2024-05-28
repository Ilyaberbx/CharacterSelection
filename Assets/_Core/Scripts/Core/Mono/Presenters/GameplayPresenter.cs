using Better.Locators.Runtime;
using Better.SceneManagement.Runtime;
using StartlingPlay.Core.Models;
using StartlingPlay.Core.Views;

namespace StartlingPlay.Core.Presenters
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
            
            var sceneReference = Model.BackScene;

            var additiveTransition = SceneService.CreateAdditiveTransition();
            
            additiveTransition
                .UnloadAllScenes()
                .LoadScene(sceneReference)
                .Run();
        }
    }
}