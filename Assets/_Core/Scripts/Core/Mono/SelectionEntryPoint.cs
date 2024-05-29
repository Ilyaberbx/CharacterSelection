using Better.Commons.Runtime.Extensions;
using Better.Locators.Runtime;
using Better.SceneManagement.Runtime;
using StarlingPlay.Core.Character;
using StarlingPlay.Core.Models;
using StarlingPlay.Core.Presenters;
using StarlingPlay.Services.Persistence;
using StarlingPlay.Services.UI;
using UnityEngine;

namespace StarlingPlay.Core
{
    public class SelectionEntryPoint : MonoBehaviour
    {
        [SerializeField] private SceneReference _gameReference;
        [SerializeField] private CharactersDatabase _charactersDatabase;
        
        private void Start()
        {
            Debug.Log("Entry Selection");
            
            InitializeScreen();
        }

        private void InitializeScreen()
        {
            var userService = ServiceLocator.Get<UserService>();
            var screenService = ServiceLocator.Get<ScreenService>();

            var data = _charactersDatabase.CharactersData;
            var model = new SelectionModel(data, userService, _gameReference);

            screenService.Open<SelectionPresenter, SelectionModel>(model).Forget();
        }
    }
}