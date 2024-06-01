using System.Collections.Generic;
using UnityEngine;

namespace CharacterModule.CharacterAnimationModule
{
    public class CharactersAnimationController
    {
        private string[] _animationsTriggers;
        private List<CharacterAnimatorController> _characterAnimatorControllers = new ();
        private int _currentAnimationTriggerIndex = 0;

        public int CharactersCount => _characterAnimatorControllers.Count;
        
        public CharactersAnimationController(string[] animationsTriggers)
        {
            _animationsTriggers = animationsTriggers;
        }

        public void AddCharacterAnimatorController(CharacterAnimatorController characterAnimController)
        {
            characterAnimController.StartAnimation(_animationsTriggers[_currentAnimationTriggerIndex]);
            _characterAnimatorControllers.Add(characterAnimController);
        }

        public void SetPause(bool isPaused)
        {
            foreach (var characterAnimatorController in _characterAnimatorControllers)
            {
                characterAnimatorController.SetActiveAnimator(!isPaused);
            }
        }

        public void ChangeAnimation(int index)
        {
            _currentAnimationTriggerIndex += index;
            _currentAnimationTriggerIndex =
                (_currentAnimationTriggerIndex % _animationsTriggers.Length + _animationsTriggers.Length) %
                _animationsTriggers.Length;

            foreach (var characterAnimatorController in _characterAnimatorControllers)
            {
                characterAnimatorController.StartAnimation(_animationsTriggers[_currentAnimationTriggerIndex]);
            }
        }

        public void DestroyAllCharacters()
        {
            foreach (var characterAnimatorController in _characterAnimatorControllers)
            {
                Object.Destroy(characterAnimatorController.gameObject);
            }

            _characterAnimatorControllers = new ();
            _currentAnimationTriggerIndex = 0;
        }
    }
}