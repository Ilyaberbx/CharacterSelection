using System.Collections.Generic;
using UnityEngine;

namespace StartlingPlay.Core.Character
{
    [CreateAssetMenu(fileName = "Characters Database", menuName = "Configurations/Characters", order = 0)]
    public class CharactersDatabase : ScriptableObject
    {
        [SerializeField] private CharacterData[] charactersData;

        public IReadOnlyList<CharacterData> CharactersData => charactersData;
    }
}