using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Operations
{
    public class Slerp : MonoBehaviour, IDemo
    {
        public string DropdownName => "Slerp";

        [SerializeField] private Line a;
        [SerializeField] private Line b;
        [SerializeField] private Line c;
        [SerializeField] private Slider t;

        [Space] [SerializeField] private Toggle clamped;

        [Space] [SerializeField] private CurvedLine helper;
        [SerializeField] private float segmentLength = 16;
        [SerializeField] private float unclampedMaxAngle = 360;

        private void Update()
        {
            if (clamped.isOn)
            {
                c.SetEnd(Vector3.Slerp(a.EndPosition, b.EndPosition, t.value));
                helper.SetPoints(GenerateClampedHelperLinePoints(a.EndPosition, b.EndPosition));
            }
            else
            {
                c.SetEnd(Vector3.SlerpUnclamped(a.EndPosition, b.EndPosition, t.value));
                helper.SetPoints(GenerateUnclampedHelperLinePoints(a.EndPosition, b.EndPosition));
            }
        }

        private Vector3[] GenerateClampedHelperLinePoints(Vector3 start, Vector3 end)
        {
            var points = new List<Vector3> { start };

            var tStepStart = 1f;

            while (true)
            {
                var sample = Vector3.Slerp(start, end, tStepStart);
                var distance = Vector3.Distance(start, sample);
                print("Start distance: " + distance);

                if (Math.Abs(distance - segmentLength) < 0.1f)
                    break;

                tStepStart /= distance / segmentLength;
            }

            var tStepEnd = 1f;

            while (true)
            {
                var sample = Vector3.Slerp(start, end, 1 - tStepEnd);
                var distance = Vector3.Distance(end, sample);
                print("End distance: " + distance);

                if (Math.Abs(distance - segmentLength) < 0.1f)
                    break;

                tStepEnd /= distance / segmentLength;
            }

            for (var tCurrent = 0f; tCurrent < 1; tCurrent += tStepStart + (tStepEnd - tStepStart) * tCurrent)
            {
                points.Add(Vector3.Slerp(start, end, tCurrent));
            }

            points.Add(end);

            return points.ToArray();
        }

        private Vector3[] GenerateUnclampedHelperLinePoints(Vector3 start, Vector3 end)
        {
            var angle = Vector3.Angle(start, end);
            var tMax = unclampedMaxAngle / angle;

            var curveStart = Vector3.SlerpUnclamped(start, end, -tMax);
            var curveEnd = Vector3.SlerpUnclamped(start, end, tMax);

            var points = new List<Vector3> { curveStart };

            var tStepStart = Math.Min(180, unclampedMaxAngle) / angle;

            while (true)
            {
                var sample = Vector3.SlerpUnclamped(start, end, -tMax + tStepStart);
                var distance = Vector3.Distance(curveStart, sample);
                print("Start distance: " + distance);

                if (Math.Abs(distance - segmentLength) < 0.1f)
                    break;

                tStepStart /= distance / segmentLength;
            }

            var tStepEnd = Math.Min(180, unclampedMaxAngle) / angle;

            while (true)
            {
                var sample = Vector3.SlerpUnclamped(start, end, tMax - tStepEnd);
                var distance = Vector3.Distance(curveEnd, sample);
                print("End distance: " + distance);

                if (Math.Abs(distance - segmentLength) < 0.1f)
                    break;

                tStepEnd /= distance / segmentLength;
            }

            for (var tCurrent = -tMax;
                 tCurrent < tMax;
                 tCurrent += tStepStart + (tStepEnd - tStepStart) * ((tCurrent + tMax) / (2 * tMax)))
            {
                points.Add(Vector3.SlerpUnclamped(start, end, tCurrent));
            }

            points.Add(curveEnd);

            return points.ToArray();
        }
    }
}