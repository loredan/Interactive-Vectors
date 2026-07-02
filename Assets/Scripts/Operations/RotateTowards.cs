using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Operations
{
    public class RotateTowards : MonoBehaviour, IDemo
    {
        public string DropdownName => "RotateTowards";

        [SerializeField] private Line a;
        [SerializeField] private Line b;
        [SerializeField] private Line c;
        [SerializeField] private Slider maxRadians;
        [SerializeField] private Slider maxMagnitude;

        [Space] [SerializeField] private CurvedLine helperMaxRadians;
        [SerializeField] private CurvedLine helperMaxMagnitude;
        [SerializeField] private float segmentLength = 16;

        private void Update()
        {
            c.SetEnd(Vector3.RotateTowards(a.EndPosition, b.EndPosition, maxRadians.value, maxMagnitude.value));
            helperMaxRadians.SetPoints(
                GenerateMaxRadiansHelperLinePoints(a.EndPosition, b.EndPosition, maxMagnitude.value));
            helperMaxMagnitude.SetPoints(
                GenerateMaxMagnitudeHelperLinePoints(a.EndPosition, b.EndPosition, maxRadians.value));
        }

        private Vector3[] GenerateMaxRadiansHelperLinePoints(Vector3 start, Vector3 end, float maxMagnitudeDelta)
        {
            var angle = Vector3.Angle(start, end) / 180 * Mathf.PI;
            var curveStart = Vector3.RotateTowards(start, end, 0, maxMagnitudeDelta);
            var curveEnd = Vector3.RotateTowards(start, end, angle, maxMagnitudeDelta);

            var points = new List<Vector3>();

            var tStepStart = angle;
            
            while (true)
            {
                var sample = Vector3.RotateTowards(start, end, tStepStart, maxMagnitudeDelta);
                var distance = Vector3.Distance(curveStart, sample);

                if (Math.Abs(distance - segmentLength) < 0.1f)
                    break;

                tStepStart /= distance / segmentLength;
            }

            var tStepEnd = angle;

            while (true)
            {
                var sample = Vector3.RotateTowards(start, end, angle - tStepEnd, maxMagnitudeDelta);
                var distance = Vector3.Distance(curveEnd, sample);

                if (Math.Abs(distance - segmentLength) < 0.1f)
                    break;

                tStepEnd /= distance / segmentLength;
            }

            for (var tCurrent = 0f;
                 tCurrent < angle;
                 tCurrent += tStepStart + (tStepEnd - tStepStart) * (tCurrent / angle))
            {
                var point = Vector3.RotateTowards(start, end, tCurrent, maxMagnitudeDelta);
                if (points.Count > 0 && point == points.Last())
                    break;
                points.Add(point);
            }

            var lastPoint = Vector3.RotateTowards(start, end, angle, maxMagnitudeDelta);
            if (points.Last() != lastPoint)
            {
                points.Add(lastPoint);
            }

            return points.ToArray();
        }

        private Vector3[] GenerateMaxMagnitudeHelperLinePoints(Vector3 start, Vector3 end, float maxRadiansDelta)
        {
            var startMagnitude = start.magnitude;
            var endMagnitude = end.magnitude;
            var maxMagnitudeRangeLength = Math.Abs(endMagnitude - startMagnitude);
            var curveStart = Vector3.RotateTowards(start, end, maxRadiansDelta, 0);
            var curveEnd = Vector3.RotateTowards(start, end, maxRadiansDelta, maxMagnitudeRangeLength);

            var points = new List<Vector3>();

            var tStepStart = maxMagnitudeRangeLength;

            while (true)
            {
                var sample = Vector3.RotateTowards(start, end, maxRadiansDelta, tStepStart);
                var distance = Vector3.Distance(curveStart, sample);

                if (sample == curveEnd || Math.Abs(distance - segmentLength) < 0.1f)
                    break;

                tStepStart /= distance / segmentLength;
            }

            var tStepEnd = maxMagnitudeRangeLength;

            while (true)
            {
                var sample = Vector3.RotateTowards(start, end, maxRadiansDelta, maxMagnitudeRangeLength - tStepEnd);
                var distance = Vector3.Distance(curveEnd, sample);

                if (sample == curveStart || Math.Abs(distance - segmentLength) < 0.1f)
                    break;

                tStepEnd /= distance / segmentLength;
            }

            for (var tCurrent = 0f;
                 tCurrent < maxMagnitudeRangeLength;
                 tCurrent += tStepStart + (tStepEnd - tStepStart) * (tCurrent / maxMagnitudeRangeLength))
            {
                var point = Vector3.RotateTowards(start, end, maxRadiansDelta, tCurrent);
                if (points.Count > 0 && point == points.Last())
                    break;
                points.Add(point);
            }

            var lastPoint = Vector3.RotateTowards(start, end, maxRadiansDelta, maxMagnitudeRangeLength);
            if (points.Last() != lastPoint)
            {
                points.Add(lastPoint);
            }

            return points.ToArray();
        }
    }
}