using Better.SceneManagement.Runtime;

namespace StarlingPlay.Core.Models
{
    public class GameplayModel : IModel
    {
        public SceneReference BackScene { get; }

        public GameplayModel(SceneReference backScene)
        {
            BackScene = backScene;
        }
    }
}