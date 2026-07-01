using UnityEngine;
using UnityEngine.UI;

namespace Operations
{
    [RequireComponent(typeof(RectTransform))]
    public class Lerp : MonoBehaviour, IDemo
    {
        public string DropdownName => "Lerp";

        [SerializeField] private Line a;
        [SerializeField] private Line b;
        [SerializeField] private Line c;
        [SerializeField] private Slider t;

        [Space] [SerializeField] private Toggle clamped;

        [Space] [SerializeField] private Line helper;
        
        private RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            if (clamped.isOn)
            {
                c.SetEnd(Vector3.Lerp(a.EndPosition, b.EndPosition, t.value));
                
                helper.SetStart(a.EndPosition);
                helper.SetEnd(b.EndPosition);
            }
            else
            {
                c.SetEnd(Vector3.LerpUnclamped(a.EndPosition, b.EndPosition, t.value));
                
                var diagonal = rectTransform.rect.max.magnitude;
                helper.SetStart(a.EndPosition + (a.EndPosition - b.EndPosition).normalized * diagonal);
                helper.SetEnd(b.EndPosition + (b.EndPosition - a.EndPosition).normalized * diagonal);
            }
        }
    }
}