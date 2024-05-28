using System.Collections.Generic;
using Better.SceneManagement.Runtime;
using StartlingPlay.Core.Character;
using StartlingPlay.Services.Persistence;
using UnityEngine;

namespace StartlingPlay.Core.Models
{
    public class SelectionModel : IModel
    {
        private readonly UserService _userService;
        
        private int _currentCharacterIndex;
        
        public IReadOnlyList<CharacterData> CharactersToSelect { get; }
        public SceneReference GameScene { get; }
        public bool IsCharacterSelected => CurrentCharacterIndex >= 0;
        public Sprite CharacterIcon => CharactersToSelect[CurrentCharacterIndex].Icon;

        public int CurrentCharacterIndex
        {
            get => _userService.CharacterIndexProperty.Value;

            set
            {
                if (value > 0)
                {
                    _userService.CharacterIndexProperty.Value = value;
                }
            }
        }

        public SelectionModel(IReadOnlyList<CharacterData> charactersToSelect
            , UserService userService
            , SceneReference gameScene)
        {
            CharactersToSelect = charactersToSelect;
            _userService = userService;
            GameScene = gameScene;
        }
    }
}