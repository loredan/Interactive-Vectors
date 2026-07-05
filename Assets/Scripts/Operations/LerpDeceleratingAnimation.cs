using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Operations
{
    public class LerpDeceleratingAnimation : MonoBehaviour, IDemo
    {
        public string DropdownName => "Lerp Decelerating Animation";

        [SerializeField] private Line a;
        [SerializeField] private Line b;
        [SerializeField] private Line c;
        [SerializeField] private Slider speed;
        
        [Space] [SerializeField] private Line helper;

        [Space] [SerializeField] private float loopEndDelay = 1f;
        [SerializeField] private float animationFinishRadius = 1f;

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

                while (Vector3.Distance(c.EndPosition, b.EndPosition) > animationFinishRadius)
                {
                    c.SetEnd(Vector3.Lerp(c.EndPosition, b.EndPosition, Time.deltaTime * speed.value));
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