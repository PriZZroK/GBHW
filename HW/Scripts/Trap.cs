using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork
{
    public class Trap : MonoBehaviour, IBonus, ITriggerEnter
    {
        [SerializeField] private float BonusTime;
        private float _timer;
        [SerializeField] private float MultipleSpeed;
        private GameObject _player;
        private bool _startTimer;


        void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            this.gameObject.GetComponent<Collider>().isTrigger = true;
        }
        public void DeleteBonus()
        {
            _player.GetComponent<Player>().Speed /= MultipleSpeed;
            Destroy(this.gameObject);

        }

        public void ExecuteBonus()
        {
            _timer = BonusTime;
            _player.GetComponent<Player>().Speed *= MultipleSpeed;
            _startTimer = true;
        }

        public void OnTriggerEnter(Collider obj)
        {
            if (obj.GetComponent<Player>())
            {
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                ExecuteBonus();
            }
        }


        void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0 & _startTimer)
            {
                DeleteBonus();
            }
        }
    }
}

