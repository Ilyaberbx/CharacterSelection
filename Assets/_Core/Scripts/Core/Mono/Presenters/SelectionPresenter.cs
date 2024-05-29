using Better.Locators.Runtime;
using Better.SceneManagement.Runtime;
using StartlingPlay.Core.Models;
using StartlingPlay.Core.Views;
using StartlingPlay.Extensions;
using StartlingPlay.Utility;
using UnityEngine;

namespace StartlingPlay.Core.Presenters
{
    public class SelectionPresenter : BasePresenter<SelectionView, SelectionModel>
    {
        private readonly ServiceProperty<SceneService> _sceneServiceProperty = new();
        private SceneService SceneService => _sceneServiceProperty.CachedService;

        private void Start()
        {
            View.OnGenerateClick += OnGenerateClicked;
            View.OnPlayClick += OnPlayClicked;

            if (Model.IsCharacterSelected)
            {
                Rebuild();
            }
        }

        private void OnDestroy()
        {
            View.OnGenerateClick -= OnGenerateClicked;
            View.OnPlayClick -= OnPlayClicked;
        }

        public override void Rebuild()
        {
            base.Rebuild();
            
            var icon = Model.CharacterIcon;

            View.Rebuild(icon);
        }

        private void OnGenerateClicked()
        {
            var charactersCount = Model.CharactersToSelect.Count;

            var randomCharacter = Random.Range(0, charactersCount);

            Model.CurrentCharacterIndex = randomCharacter;

            Rebuild();
        }

        private void OnPlayClicked()
        {
            View.Interactable = false;
            
            using var additiveTransition = SceneService.CreateAdditiveTransition();
            
            var scene = Model.GameScene;
            
            additiveTransition
                .SafeUnloadAll()
                .LoadScene(scene)
                .RunWithActive(scene);
            
            UIUtility.CloseAll();
        }
    }
}