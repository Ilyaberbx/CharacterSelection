using System;
using UnityEngine;

namespace StarlingPlay.Core.Character
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