using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork
{
    public static class Extension_Method
    {
        public static int CharCount(this string _str)
        {
            return _str.Length;
        }
    }
}
