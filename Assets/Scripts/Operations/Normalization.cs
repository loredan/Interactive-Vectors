using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Operations
{
    public class Normalization : MonoBehaviour, IDemo
    {
        public string DropdownName => "Normalize";
        
        [SerializeField] private Line a;
        [SerializeField] private Line b;

        [Space] [SerializeField] private float multiplier;

        private void Update()
        {
            b.SetEnd(a.EndPosition.normalized * multiplier);

            if (a.EndPosition.magnitude < multiplier)
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