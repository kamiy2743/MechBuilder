using UnityEngine;

namespace MB
{
    [CreateAssetMenu(fileName = "AudioConfig", menuName = "ScriptableObjects/AudioConfig")]
    public class AudioConfig : ScriptableObject
    {
        public float DefaultBGMVolume = 0.5f;
        public float DefaultSEVolume = 0.5f;

        public string BGMVolumeKey = "BGMVolumeKey";
        public string SEVolumeKey = "SEVolumeKey";

        public BGMClip[] BGMClips;
        public SEClip[] SEClips;
    }
}