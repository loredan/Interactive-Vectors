using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Operations
{
    public class Project : MonoBehaviour, IDemo
    {
        public string DropdownName => "Project";
        
        [SerializeField] private Line a;
        [SerializeField] private Line b;
        [SerializeField] private Line c;

        [Space] [SerializeField]
        private Line helper;

        private void Update()
        {
            c.SetEnd(Vector3.Project(a.EndPosition, b.EndPosition));
            
            helper.SetStart(a.EndPosition);
            helper.SetEnd(c.EndPosition);

            if (b.EndPosition.sqrMagnitude < c.EndPosition.sqrMagnitude)
            {
                b.transform.SetAsLastSibling();
            }
            else
            {
                c.transform.SetAsLastSibling();
            }
        }
    }
}