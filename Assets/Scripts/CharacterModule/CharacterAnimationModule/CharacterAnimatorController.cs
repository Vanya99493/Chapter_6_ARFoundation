using UnityEngine;

namespace CharacterModule.CharacterAnimationModule
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimatorController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void StartAnimation(string triggerName)
        {
            _animator.SetTrigger(triggerName);
        }

        public void SetActiveAnimator(bool isActive)
        {
            _animator.enabled = isActive;
        }
    }
}