using Better.Locators.Runtime;
using Better.SceneManagement.Runtime;
using StarlingPlay.Core.Models;
using StarlingPlay.Core.Views;
using StarlingPlay.Extensions;
using StarlingPlay.Utility;
using UnityEngine;

namespace StarlingPlay.Core.Presenters
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
            if (!Model.IsCharacterSelected)
                return;

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