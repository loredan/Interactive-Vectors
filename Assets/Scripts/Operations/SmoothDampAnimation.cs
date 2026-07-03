using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Operations
{
    public class SmoothDampAnimation : MonoBehaviour, IDemo
    {
        public string DropdownName => "SmoothDamp Animation";

        [SerializeField] private Line a;
        [SerializeField] private Line b;
        [SerializeField] private Line c;
        [SerializeField] private Slider smoothTime;
        [SerializeField] private Slider maxSpeed;

        [Space] [SerializeField] private Line helper;

        [Space] [SerializeField] private float loopEndDelay = 1f;
        [SerializeField] private float animationTimeLimit = 10f;

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

                var currentVelocity = Vector3.zero;
                var timer = 0f;
                while (c.EndPosition != b.EndPosition && timer < animationTimeLimit)
                {
                    timer += Time.deltaTime;
                    c.SetEnd(Vector3.SmoothDamp(
                        c.EndPosition,
                        b.EndPosition,
                        ref currentVelocity,
                        smoothTime.value,
                        maxSpeed.value
                    ));
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