using System;
using Better.Attributes.Runtime.Select;
using Better.Commons.Runtime.DataStructures.SerializedTypes;
using StarlingPlay.Core.Presenters;
using UnityEngine;

namespace StarlingPlay.Services.UI.Data
{
    [Serializable]
    public class PresenterData
    {
        [SerializeField,Select(typeof(BasePresenter))] private SerializedType _serializedType;
        [SerializeField] private BasePresenter _prefab;
        
        public BasePresenter Prefab => _prefab;

        public Type Type => _serializedType.Type;
    }
}