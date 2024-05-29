using System.Threading.Tasks;
using Better.Commons.Runtime.Extensions;
using Better.Locators.Runtime;
using Better.SceneManagement.Runtime;
using StarlingPlay.Core.Models;
using StarlingPlay.Core.Presenters;
using StarlingPlay.Services.Character;
using StarlingPlay.Services.Persistence;
using StarlingPlay.Services.UI;
using UnityEngine;

namespace StarlingPlay.Core
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private SceneReference _backScene;
        
        private void Start()
        {
            Debug.Log("Entry Gameplay");
            
            InitializeCharacters();
            InitializeScreen().Forget();
        }
        
        private Task<GameplayPresenter> InitializeScreen()
        {
            var screenService = ServiceLocator.Get<ScreenService>();
            
            var model = new GameplayModel(_backScene);

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