using UnityEngine;

namespace CharacterModule.CharacterAnimationModule.FactoryModule
{
    public class CharactersSpawner : MonoBehaviour
    {
        [SerializeField] private CharacterAnimatorController _prefab;
        [SerializeField] private Transform _parentForSpawn;
        [SerializeField] private Transform _lookAtTransform;

        public CharacterAnimatorController SpawnCharacter(Vector3 position)
        {
            CharacterAnimatorController character = Instantiate(_prefab, _parentForSpawn);
            character.transform.position = position;

            Vector3 lookAtPosition = _lookAtTransform.position;

            if (lookAtPosition != Vector3.zero)
            {
                lookAtPosition.y = character.transform.position.y;
                character.transform.LookAt(lookAtPosition);
            }

            return character;
        }
    }
}