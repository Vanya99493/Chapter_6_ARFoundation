using UnityEngine;

namespace AudioModule
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        
        private AudioClip[] _audioClips;
        private int _currentAudioClipIndex;

        public void Initialize(AudioClip[] audioClips)
        {
            _audioClips = audioClips;
        }
        
        public void StartAudio()
        {
            _currentAudioClipIndex = 0;
            _audioSource.clip = _audioClips[_currentAudioClipIndex];
            _audioSource.Play();
        }

        public void SetPause(bool isPaused)
        {
            if (isPaused)
            {
                _audioSource.Pause();
            }
            else
            {
                _audioSource.UnPause();
            }
        }

        public void StopAudio()
        {
            _audioSource.Stop();
        }

        public void ChangeAudioClip(int index)
        {
            _currentAudioClipIndex += index;
            _currentAudioClipIndex = (_currentAudioClipIndex % _audioClips.Length + _audioClips.Length) % _audioClips.Length;
            _audioSource.clip = _audioClips[_currentAudioClipIndex];
            _audioSource.Play();
        }
    }
}