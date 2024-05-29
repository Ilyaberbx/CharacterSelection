using System.Threading;
using Better.Locators.Runtime;
using Better.SceneManagement.Runtime;
using StarlingPlay.Extensions;
using StarlingPlay.Utility;
using UnityEngine;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

namespace StarlingPlay.Core
{
    public class ApplicationEntryPoint : MonoBehaviour
    {
        [SerializeField] private SceneReference _characterSelectionScene;

        private CancellationTokenSource _tokenSource;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void ApplySettings()
        {
            Application.runInBackground = true;
            Application.targetFrameRate = 60;

            var coreSceneName = SceneHelper.CoreSceneName;
            
            if (SceneManager.GetActiveScene().name != coreSceneName)
            {
                SceneManager.LoadSceneAsync(coreSceneName);
            }
        }

        private void Awake()
        {
            _tokenSource = new CancellationTokenSource();
        }

        private async void Start()
        {
            Debug.Log("Entry Application");
            
            var sceneService = await ServiceLocator.GetAsync<SceneService>(_tokenSource.Token);

            sceneService
                .CreateAdditiveTransition()
                .LoadScene(_characterSelectionScene)
                .RunWithActive(_characterSelectionScene);
        }

        private void OnDestroy()
        {
            _tokenSource?.Cancel();
        }
    }
}