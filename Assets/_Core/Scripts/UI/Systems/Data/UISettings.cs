using System.Collections.Generic;
using UnityEngine;

namespace StartlingPlay.UI.Systems.Data
{
    [CreateAssetMenu(fileName = "UI Settings", menuName = "Configurations/Services/UI", order = 0)]
    public class UISettings : ScriptableObject
    {
        [SerializeField] private PresenterData[] _presentersData;

        public IReadOnlyList<PresenterData> Presenters => _presentersData;
    }
}