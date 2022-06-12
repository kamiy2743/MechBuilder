using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class AudioClipProvider : MonoBehaviour, IStaticAwake
    {
        [SerializeField] private AudioConfig _config;

        private Dictionary<BGMType, AudioClip> _BGMDictionary = new Dictionary<BGMType, AudioClip>();
        private Dictionary<SEType, AudioClip> _SEDictionary = new Dictionary<SEType, AudioClip>();

        public void StaticAwake()
        {
            foreach (var item in _config.BGMClips)
            {
                _BGMDictionary[item.Type] = item.Clip;
            }

            foreach (var item in _config.SEClips)
            {
                _SEDictionary[item.Type] = item.Clip;
            }
        }

        /// <returns>Success</returns>
        public bool TryGetBGM(BGMType type, out AudioClip clip)
        {
            if (_BGMDictionary.ContainsKey(type))
            {
                clip = _BGMDictionary[type];
                return true;
            }

            clip = null;
            Debug.Log("BGMClipが設定されていません");
            return false;
        }

        /// <returns>Success</returns>
        public bool TryGetSE(SEType type, out AudioClip clip)
        {
            if (_SEDictionary.ContainsKey(type))
            {
                clip = _SEDictionary[type];
                return true;
            }

            clip = null;
            Debug.Log("SEClipが設定されていません");
            return false;
        }
    }

    [System.Serializable]
    public class BGMClip
    {
        public BGMType Type;
        public AudioClip Clip;
    }

    [System.Serializable]
    public class SEClip
    {
        public SEType Type;
        public AudioClip Clip;
    }
}
