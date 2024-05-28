using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Better.Services.Runtime;
using StartlingPlay.Core.Character;
using UnityEngine;

namespace StartlingPlay.Services.Character
{
    public class CharactersService : PocoService<CharactersDatabase>
    {
        private CharacterFactory _factory;

        private List<GameObject> _characters;

        public IReadOnlyList<GameObject> Characters => _characters; // For future usage
        
        protected override async Task OnInitializeAsync(CancellationToken cancellationToken)
        {
            await base.OnInitializeAsync(cancellationToken);

            _factory = new CharacterFactory(Settings.CharactersData);
            _characters = new List<GameObject>();
        }

        public GameObject Create(int index, Vector3 at, Transform container = null)
        {
            var character = _factory.Create(index, at, container);

            _characters.Add(character);

            return character;
        }
    }
}