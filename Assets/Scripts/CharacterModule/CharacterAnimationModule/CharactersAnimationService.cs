using CharacterModule.CharacterAnimationModule.FactoryModule;
using UnityEngine;

namespace CharacterModule.CharacterAnimationModule
{
    public class CharactersAnimationService : MonoBehaviour
    {
        [SerializeField] private CharactersSpawner _charactersSpawner;

        private CharactersAnimationController _charactersAnimationController;
        
        public int SpawnedCharacters => _charactersAnimationController.CharactersCount;
        
        public void Initialize(string[] animationsTriggers)
        {
            _charactersAnimationController = new CharactersAnimationController(animationsTriggers);
        }

        public void AddNewCharacter(Vector3 position)
        {
            var characterAnimController = _charactersSpawner.SpawnCharacter(position);
            _charactersAnimationController.AddCharacterAnimatorController(characterAnimController);
        }

        public void ChangeAnimation(int index)
        {
            _charactersAnimationController.ChangeAnimation(index);
        }

        public void SetPause(bool isPaused)
        {
            _charactersAnimationController.SetPause(isPaused);
        }

        public void DestroyAllCharacters()
        {
            _charactersAnimationController.DestroyAllCharacters();
        }
    }
}