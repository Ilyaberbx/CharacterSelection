using System;
using System.Collections.Generic;
using Better.Commons.Runtime.Utility;
using UnityEngine;
using Object = UnityEngine.Object;

namespace StarlingPlay.Core.Character
{
    public class CharacterFactory
    {
        private readonly IReadOnlyList<CharacterData> _charactersData;

        public CharacterFactory(IReadOnlyList<CharacterData> charactersData)
        {
            _charactersData = charactersData;
        }

        public GameObject Create(int index, Vector3 at, Transform container = null)
        {
            if (_charactersData.Count < index)
            {
                DebugUtility.LogException<IndexOutOfRangeException>();
            }

            var data = _charactersData[index];
            
            var character = Object.Instantiate(data.Prefab, at, Quaternion.identity, container);
            
            return character;
        }
    }
}