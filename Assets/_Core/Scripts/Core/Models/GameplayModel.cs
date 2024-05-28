using Better.SceneManagement.Runtime;

namespace StartlingPlay.Core.Models
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