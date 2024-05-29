using UnityEngine.SceneManagement;

namespace StartlingPlay.Utility
{
    public static class SceneHelper
    {
        public static Scene CoreScene => SceneManager.GetSceneAt(0);
    }
}