using System.Threading.Tasks;
using Better.Commons.Runtime.Extensions;
using Better.Locators.Runtime;
using Better.SceneManagement.Runtime;
using StartlingPlay.Core.Models;
using StartlingPlay.Core.Presenters;
using StartlingPlay.Services.Character;
using StartlingPlay.Services.Persistence;
using StartlingPlay.Services.UI;
using UnityEngine;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

namespace StartlingPlay.Core
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private SceneReference _characterSelectionScene;
        [SerializeField] private SceneReference _currentScene;
        
        private void Start()
        {
            SetActive(_currentScene);
            InitializeCharacters();
            InitializeScreen().Forget();
        }

        private void SetActive(SceneReference scene)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene.Name));
        }

        private Task<GameplayPresenter> InitializeScreen()
        {
            var screenService = ServiceLocator.Get<ScreenService>();
            
            var model = new GameplayModel(_characterSelectionScene);

            return screenService.Open<GameplayPresenter, GameplayModel>(model);
        }

        private void InitializeCharacters()
        {
            var charactersService = ServiceLocator.Get<CharactersService>();
            var userService = ServiceLocator.Get<UserService>();
            
            var characterIndex = userService.CharacterIndexProperty.Value;
            charactersService.Create(characterIndex, Vector3.zero);
        }
    }
}