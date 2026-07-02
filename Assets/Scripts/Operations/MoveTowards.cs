using UnityEngine;
using UnityEngine.UI;

namespace Operations
{
    [RequireComponent(typeof(RectTransform))]
    public class MoveTowards : MonoBehaviour, IDemo
    {
        public string DropdownName => "MoveTowards";

        [SerializeField] private Line a;
        [SerializeField] private Line b;
        [SerializeField] private Line c;
        [SerializeField] private Slider t;

        [Space] [SerializeField] private Line helper;

        private void Update()
        {
            c.SetEnd(Vector3.MoveTowards(a.EndPosition, b.EndPosition, t.value));

            helper.SetStart(a.EndPosition);
            helper.SetEnd(b.EndPosition);
        }
    }
}