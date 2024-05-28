using Better.Commons.Runtime.Extensions;
using Better.Locators.Runtime;
using Better.SceneManagement.Runtime;
using StartlingPlay.Core.Models;
using StartlingPlay.Core.Presenters;
using StartlingPlay.Services.Character;
using StartlingPlay.Services.Persistence;
using StartlingPlay.Services.UI;
using UnityEngine;

namespace StartlingPlay.Core
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private SceneReference _characterSelectionScene;
        
        private void Start()
        {
            var charactersService = ServiceLocator.Get<CharactersService>();
            var userService = ServiceLocator.Get<UserService>();
            var screenService = ServiceLocator.Get<ScreenService>();

            var characterIndex = userService.CharacterIndexProperty.Value;

            charactersService.Create(characterIndex, Vector3.zero);

            var model = new GameplayModel(_characterSelectionScene);
            screenService.Open<GameplayPresenter, GameplayModel>(model).Forget();
        }
    }
}