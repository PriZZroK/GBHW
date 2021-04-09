using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork
{
    public class Trap : MonoBehaviour, IBonus, ITriggerEnter
    {
        [SerializeField] private float BonusTime;
        [SerializeField] private float MultipleSpeed;
        private GameObject _player;
        private bool _startTimer;
        private Events _event;
        [SerializeField] private string DebuffText;

        void Awake()
        {
            _event = GameObject.FindGameObjectWithTag("Event").GetComponent<Events>();
        }
        void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            this.gameObject.GetComponent<Collider>().isTrigger = true;
        }
        public void DeleteBonus()
        {
            _player.GetComponent<Player>().Speed /= MultipleSpeed;
            _event._action -= () => _event.ChangeText(DebuffText);
            Destroy(this.gameObject);
        }

        public void ExecuteBonus()
        {
            _player.GetComponent<Player>().Speed *= MultipleSpeed;
            _startTimer = true;
        }

        public void OnTriggerEnter(Collider obj)
        {
            if (obj.GetComponent<Player>())
            {
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                _event._action += () => _event.ChangeText(DebuffText);
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

