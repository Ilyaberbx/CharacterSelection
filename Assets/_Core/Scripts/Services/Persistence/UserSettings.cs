using UnityEngine;

namespace StartlingPlay.Services.Persistence
{
    [CreateAssetMenu(fileName = "User Service Settings", menuName = "Configurations/Services/User", order = 0)]
    public class UserSettings : ScriptableObject
    {
        [SerializeField] private int _characterByDefault;

        public int CharacterIndexByDefault => _characterByDefault;
    }
}