using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Operations
{
    public class Multiplication : MonoBehaviour, IDemo
    {
        public string DropdownName => "Multiply";
        
        [SerializeField] private Line a;
        [SerializeField] private Line b;

        [Space] [SerializeField] private Slider k;

        private void Update()
        {
            b.SetEnd(k.value * a.EndPosition);

            if (Math.Abs(k.value) > 1)
            {
                a.transform.SetAsLastSibling();
            }
            else
            {
                b.transform.SetAsLastSibling();
            }
        }
    }
}