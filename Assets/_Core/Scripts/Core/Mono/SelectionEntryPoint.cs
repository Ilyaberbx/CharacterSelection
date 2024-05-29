using Better.Commons.Runtime.Extensions;
using Better.Locators.Runtime;
using Better.SceneManagement.Runtime;
using StartlingPlay.Core.Character;
using StartlingPlay.Core.Models;
using StartlingPlay.Core.Presenters;
using StartlingPlay.Services.Persistence;
using StartlingPlay.Services.UI;
using UnityEngine;

namespace StartlingPlay.Core
{
    public class SelectionEntryPoint : MonoBehaviour
    {
        [SerializeField] private SceneReference _gameReference;
        [SerializeField] private CharactersDatabase _charactersDatabase;
        
        private void Start()
        {
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