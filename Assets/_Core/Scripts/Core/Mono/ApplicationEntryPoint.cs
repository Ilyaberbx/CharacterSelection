using System.Threading;
using Better.Locators.Runtime;
using Better.SceneManagement.Runtime;
using StartlingPlay.Extensions;
using StartlingPlay.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

namespace StartlingPlay.Core
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

            if (SceneManager.GetActiveScene() != SceneHelper.CoreScene)
                SceneManager.LoadSceneAsync(SceneHelper.CoreScene.name, LoadSceneMode.Single);
        }

        private void Awake()
        {
            _tokenSource = new CancellationTokenSource();
        }

        private async void Start()
        {
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