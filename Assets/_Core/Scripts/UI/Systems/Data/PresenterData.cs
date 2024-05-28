using System;
using Better.Attributes.Runtime.Select;
using Better.Commons.Runtime.DataStructures.SerializedTypes;
using StartlingPlay.Core;
using StartlingPlay.Core.Presenters;
using UnityEngine;

namespace StartlingPlay.UI.Systems.Data
{
    [Serializable]
    public class PresenterData
    {
        [SerializeField,Select(typeof(BasePresenter))] private SerializedType _serializedType;
        [SerializeField] private BasePresenter _prefab;
        
        public BasePresenter Prefab => _prefab;

        public Type Type => _serializedType;
    }
}