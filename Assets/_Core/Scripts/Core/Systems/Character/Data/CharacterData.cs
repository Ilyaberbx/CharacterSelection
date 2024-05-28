using System;
using UnityEngine;

namespace StartlingPlay.Core.Character
{
    [Serializable]
    public class CharacterData 
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private GameObject _prefab;

        public Sprite Icon => _icon;
        public GameObject Prefab => _prefab;
    }
}