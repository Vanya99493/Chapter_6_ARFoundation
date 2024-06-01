using CustomClasses;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "AnimationSoundConfig", menuName = "ScriptableObjects/AnimationSoundConfig")]
    public class AnimationSoundConfig : ScriptableObject
    {
        public SerializableDictionary<string, AudioClip> SoundsByTriggerName;
    }
}