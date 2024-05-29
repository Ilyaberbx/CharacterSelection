using UnityEngine.SceneManagement;

namespace StarlingPlay.Utility
{
    public static class SceneHelper
    {
        public static string CoreSceneName => System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(0));
    }
}