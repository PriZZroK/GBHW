using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HomeWork
{
    public class GB_5_HM : MonoBehaviour
    {
        [SerializeField] private string Extension_Method_String;
        [SerializeField] private List<int> _intList = new List<int>{};
        void Start()
        {
            //Extension_Method
            Debug.Log("� ������ Extension_Method_String " + Extension_Method.CharCount(Extension_Method_String) + " ��������");

            foreach (int value in _intList.Distinct())
            {
                Debug.Log(value + " ����������� � ������ " + "_intList " + _intList.Where(a => a==value).Count()+" ���");
            }
        }


    }
}

