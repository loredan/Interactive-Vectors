using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Operations
{
    public class Subtraction : MonoBehaviour, IDemo
    {
        public string DropdownName => "Sub";

        [SerializeField] private Line a;
        [SerializeField] private Line b;
        [SerializeField] private Line c;

        [Space] [SerializeField] [InspectorLabel("b'")]
        private Line bHelper;

        [SerializeField] [InspectorLabel("c'")]
        private Line cHelper;

        private void Update()
        {
            c.SetEnd(a.EndPosition - b.EndPosition);

            bHelper.SetStart(a.EndPosition);
            bHelper.SetEnd(c.EndPosition);

            cHelper.SetStart(b.EndPosition);
            cHelper.SetEnd(a.EndPosition);
        }
    }
}