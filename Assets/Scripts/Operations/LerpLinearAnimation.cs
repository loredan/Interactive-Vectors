using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Operations
{
    public class LerpLinearAnimation : MonoBehaviour, IDemo
    {
        public string DropdownName => "Lerp Linear Animation";

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

                var t = 0f;
                while (c.EndPosition != b.EndPosition)
                {
                    t += Time.deltaTime * speed.value;
                    c.SetEnd(Vector3.Lerp(a.EndPosition, b.EndPosition, t));
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