using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MB
{
    public class CustomInput : MonoBehaviour, IStaticAwake
    {
        private TMP_InputField _inputField;
        public string Text => _inputField.text;

        public void StaticAwake()
        {
            _inputField = GetComponent<TMP_InputField>();
        }

        public bool IsEmpty()
        {
            return _inputField.text == "";
        }
    }
}
