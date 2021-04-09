using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HomeWork
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField] private Button _restartBut;
        [HideInInspector] public int BuffCount;
        [SerializeField] private int BuffToEnd;
        [SerializeField] private Text _wintxt;

        void Start()
        {
            _restartBut.onClick.AddListener(Restart);
            
        }

        public void CheckBuffCount()
        {
            if (BuffCount == BuffToEnd) StartCoroutine(WonRestart());
        }
        private void Restart()
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        private void Won()
        {
            _wintxt.text = "Won!";
        }

        IEnumerator WonRestart()
        {
            Won();
            yield return new WaitForSeconds(4);
            Restart();
        }
    }
}
