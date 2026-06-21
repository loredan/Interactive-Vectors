using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Operations
{
    public class Addition : MonoBehaviour
    {
        [SerializeField] private Line a;
        [SerializeField] private Line b;
        [SerializeField] private Line c;

        [Space] [SerializeField] [InspectorLabel("a'")]
        private Line aHelper;

        [SerializeField] [InspectorLabel("b'")] private Line bHelper;

        private void Update()
        {
            c.SetEnd(a.EndPosition + b.EndPosition);
            
            aHelper.SetStart(b.EndPosition);
            aHelper.SetEnd(c.EndPosition);
            
            bHelper.SetStart(a.EndPosition);
            bHelper.SetEnd(c.EndPosition);
        }
    }
}