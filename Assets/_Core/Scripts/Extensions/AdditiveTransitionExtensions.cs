using System.Collections.Generic;
using System.Threading.Tasks;
using Better.Commons.Runtime.Extensions;
using Better.SceneManagement.Runtime;
using Better.SceneManagement.Runtime.Transitions;
using StarlingPlay.Utility;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

namespace StarlingPlay.Extensions
{
    public static class AdditiveTransitionExtensions
    {
        public static AdditiveTransitionInfo SafeUnloadAll(this AdditiveTransitionInfo transition)
        {
            var activeScene = UnitySceneManager.GetActiveScene();
            var sceneCount = UnitySceneManager.sceneCount;
            var scenesToUnload = new List<SceneReference>();
            var coreSceneName = SceneHelper.CoreSceneName;
            
            if (activeScene.name != coreSceneName)
            {
                activeScene = UnitySceneManager.GetSceneByName(coreSceneName);

                UnitySceneManager.SetActiveScene(activeScene);
            }

            for (int i = 0; i < sceneCount; i++)
            {
                var scene = UnitySceneManager.GetSceneAt(i);

                if (scene.IsValid() && scene.isLoaded && scene != activeScene)
                {
                    scenesToUnload.Add(new SceneReference(scene));
                }

                transition.UnloadScenes(scenesToUnload);
            }

            return transition;
        }

        public static async Task RunAsyncWithActive(this AdditiveTransitionInfo transition,
            SceneReference sceneReference)
        {
            if (sceneReference.Validate())
            {
                await transition.RunAsync();
                UnitySceneManager.SetActiveScene(UnitySceneManager.GetSceneByName(sceneReference.Name));
            }
        }

        public static void RunWithActive(this AdditiveTransitionInfo transition, SceneReference sceneReference)
        {
            RunAsyncWithActive(transition, sceneReference).Forget();
        }
    }
}