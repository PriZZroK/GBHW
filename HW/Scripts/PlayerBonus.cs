using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork
{
    public interface IBonus
    {
        public abstract void ExecuteBonus();
        public abstract void DeleteBonus();
    }

    public interface ITriggerEnter
    {
        public abstract void OnTriggerEnter(Collider obj);

    }
}

