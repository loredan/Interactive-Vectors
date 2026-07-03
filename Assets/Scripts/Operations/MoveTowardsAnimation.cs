using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Operations
{
    public class MoveTowardsAnimation : MonoBehaviour, IDemo
    {
        public string DropdownName => "MoveTowards Animation";

        [SerializeField] private Line a;
        [SerializeField] private Line b;
        [SerializeField] private Line c;
        [SerializeField] private Slider speed;
        
        [Space] [SerializeField] private Line helper;

        [Space] [SerializeField] private float loopEndDelay = 1f;

        private void Start()
        {
            StartCoroutine(AnimationLoop());
        }

        private IEnumerator AnimationLoop()
        {
            while (true)
            {
                c.SetEnd(a.EndPosition);

                yield return new WaitForSeconds(1f);

                while (c.EndPosition != b.EndPosition)
                {
                    c.SetEnd(Vector3.MoveTowards(c.EndPosition, b.EndPosition, Time.deltaTime * speed.value));
                    yield return null;
                }
                
                yield return new WaitForSeconds(loopEndDelay);
            }
        }

        private void Update()
        {
            helper.SetStart(a.EndPosition);
            helper.SetEnd(b.EndPosition);
        }
    }
}