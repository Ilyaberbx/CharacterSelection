using System.Threading;
using System.Threading.Tasks;
using Better.Saves.Runtime.Data;
using Better.Services.Runtime;

namespace StartlingPlay.Services.Persistence
{
    public class UserService : PocoService<UserSettings>
    {
        private const string CharacterKey = "Current Character Data";
        public SavesProperty<int> CharacterIndexProperty { get; private set; }

        protected override Task OnPostInitializeAsync(CancellationToken cancellationToken)
        {
            CharacterIndexProperty = new SavesProperty<int>(CharacterKey, Settings.CharacterIndexByDefault);

            return Task.CompletedTask;
        }
    }
}