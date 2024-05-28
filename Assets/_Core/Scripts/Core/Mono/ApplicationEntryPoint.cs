using System.Threading;
using Better.Locators.Runtime;
using Better.SceneManagement.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

namespace StartlingPlay.Core
{
    public class ApplicationEntryPoint : MonoBehaviour
    {
        private const string CoreScene = "Bootstrapper";

        [SerializeField] private SceneReference _characterSelectionScene;

        private CancellationTokenSource _tokenSource;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void ApplySettings()
        {
            Application.runInBackground = true;
            Application.targetFrameRate = 60;

            if (SceneManager.GetActiveScene().name != CoreScene)
                SceneManager.LoadSceneAsync(CoreScene, LoadSceneMode.Single);
        }

        private void Awake()
        {
            _tokenSource = new CancellationTokenSource();
        }

        private async void Start()
        {
            var sceneService = await ServiceLocator.GetAsync<SceneService>(_tokenSource.Token);

            await sceneService
                .CreateAdditiveTransition()
                .LoadScene(_characterSelectionScene)
                .RunAsync();
        }

        private void OnDestroy()
        {
            _tokenSource?.Cancel();
        }
    }
}