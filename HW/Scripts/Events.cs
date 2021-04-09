using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HomeWork
{

    public sealed class Events : MonoBehaviour
    {
        [SerializeField] private Text _text;
        public event Action _action = delegate { };

        public void InvokeAction()
        {
            _action?.Invoke();
        }

        public void ChangeText(string txt)
        {
            StartCoroutine(ChngTxt(txt));
        }
        IEnumerator ChngTxt(string txt)
        {
            _text.text = txt;
            yield return new WaitForSeconds(1);
            _text.text = "";

        }

    }
}

