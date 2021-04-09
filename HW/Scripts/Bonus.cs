using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork
{


    public class Bonus : MonoBehaviour, IBonus, ITriggerEnter
    {
        [SerializeField] private float BonusTime;
        [SerializeField] private float MultipleSpeed;
        private GameObject _player;
        private bool _startTimer;
        private Events _event;
        private CanvasController _canvas;
        [SerializeField] private string BonusText;

        void Awake()
        {
            _event = GameObject.FindGameObjectWithTag("Event").GetComponent<Events>();
        }
        void Start()
        {
            _canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasController>();
            _player = GameObject.FindGameObjectWithTag("Player");
            this.gameObject.GetComponent<Collider>().isTrigger = true;
        }

        public void DeleteBonus()
        {
            _player.GetComponent<Player>().Speed /= MultipleSpeed;
            _event._action -= () => _event.ChangeText(BonusText);
            Destroy(this.gameObject);
        }
        
        public void ExecuteBonus()
        {
            _player.GetComponent<Player>().Speed = MultipleSpeed;
            _canvas.BuffCount++;
            _canvas.CheckBuffCount();
            _startTimer = true;
        }

        public void OnTriggerEnter(Collider obj)
        {
            if (obj.GetComponent<Player>())
            {
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                _event._action += () => _event.ChangeText(BonusText);
                _event.InvokeAction();
                StartCoroutine(BonusTimer(BonusTime));
            }
        }

        IEnumerator BonusTimer(float _time)
        {
            ExecuteBonus();
            yield return new WaitForSeconds(_time);
            DeleteBonus();
        }

    }
}

