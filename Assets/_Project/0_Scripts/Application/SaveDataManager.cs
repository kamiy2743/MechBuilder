using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class SaveDataManager
    {
        public static void Save<T>(string key, T value)
        {
            if (typeof(T) == typeof(int))
            {
                PlayerPrefs.SetInt(key, (int)(object)value);
                return;
            }

            if (typeof(T) == typeof(float))
            {
                PlayerPrefs.SetFloat(key, (float)(object)value);
                return;
            }

            PlayerPrefs.SetString(key, (string)(object)value);
        }

        public static T Load<T>(string key, T defaultValue)
        {
            if (typeof(T) == typeof(int))
            {
                return (T)(object)PlayerPrefs.GetInt(key, (int)(object)defaultValue);
            }

            if (typeof(T) == typeof(float))
            {
                return (T)(object)PlayerPrefs.GetFloat(key, (float)(object)defaultValue);
            }

            return (T)(object)PlayerPrefs.GetString(key, (string)(object)defaultValue);
        }
    }
}
