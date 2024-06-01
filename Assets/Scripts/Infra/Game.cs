using System.Linq;
using AudioModule;
using CharacterModule.CharacterAnimationModule;
using Infra.RaycastModule;
using ScriptableObjects;
using UIModule;
using UnityEngine;

namespace Infra
{
    public class Game : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private AnimationSoundConfig _animationSoundConfig;

        [Header("Components")]
        [SerializeField] private CharactersAnimationService _charactersAnimationService;
        [SerializeField] private RayCaster _rayCaster;
        [SerializeField] private AudioController _audioController;
        [SerializeField] private UIController _uiController;

        private bool _isPaused = false;
        
        private void Awake()
        {
            _audioController.Initialize(_animationSoundConfig.SoundsByTriggerName.Values.ToArray());
            _charactersAnimationService.Initialize(_animationSoundConfig.SoundsByTriggerName.Keys.ToArray());
            _rayCaster.RayHitEvent += OnRayHit;
            _uiController.Initialize(
                OnPauseButtonClick,
                OnResetButtonClick,
                OnIncreaseButtonClick,
                OnDecreaseButtonClick
                );
            _uiController.DeactivateUI();
            _uiController.ActivateIntroductionPanel();
        }

        private void OnRayHit(Vector3 hitPosition)
        {
            if (_isPaused)
            {
                return;
            }

            _charactersAnimationService.AddNewCharacter(hitPosition);
            if (_charactersAnimationService.SpawnedCharacters == 1)
            {
                _audioController.StartAudio();
                _uiController.ActivateUI();
            }
        }

        private void OnPauseButtonClick()
        {
            _isPaused = !_isPaused;
            _charactersAnimationService.SetPause(_isPaused);
            _uiController.SetPause(_isPaused);
            _audioController.SetPause(_isPaused);
        }

        private void OnResetButtonClick()
        {
            _isPaused = false;
            _uiController.SetPause(_isPaused);
            _audioController.StopAudio();
            _uiController.DeactivateUI();
            _charactersAnimationService.DestroyAllCharacters();
        }

        private void OnIncreaseButtonClick()
        {
            _charactersAnimationService.ChangeAnimation(1);
            _audioController.ChangeAudioClip(1);
        }

        private void OnDecreaseButtonClick()
        {
            _charactersAnimationService.ChangeAnimation(-1);
            _audioController.ChangeAudioClip(-1);
        }
    }
}