using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CurvedLine : MaskableGraphic
{
    [SerializeField] private Color lineColor;
    [SerializeField] private float thickness;

    private Vector3[] linePoints = Array.Empty<Vector3>();

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        for (var i = 0; i < linePoints.Length - 1; i++)
        {
            Vector3? prev = i > 0 ? linePoints[i - 1] : null;
            Vector3? next = i < linePoints.Length - 1 ? linePoints[i + 1] : null;

            AddSegment(vh, prev, linePoints[i], linePoints[i + 1], next);
        }
    }

    private void AddSegment(VertexHelper vh, Vector3? prev, Vector3 start, Vector3 end, Vector3? next)
    {
        prev ??= start + (start - end);
        next ??= end + (end - start);

        var startPerpendicular = (Quaternion.Euler(0, 0, 90) * (end - start).normalized +
                                  Quaternion.Euler(0, 0, 90) * (start - prev).Value.normalized).normalized;

        var endPerpendicular = (Quaternion.Euler(0, 0, 90) * (end - start).normalized +
                                Quaternion.Euler(0, 0, 90) * (next - end).Value.normalized).normalized;

        var v1 = new UIVertex
        {
            position = start + startPerpendicular * thickness / 2,
            color = lineColor,
            normal = Vector3.back
        };
        var v2 = new UIVertex
        {
            position = end + endPerpendicular * thickness / 2,
            color = lineColor,
            normal = Vector3.back
        };
        var v3 = new UIVertex
        {
            position = end - endPerpendicular * thickness / 2,
            color = lineColor,
            normal = Vector3.back
        };
        var v4 = new UIVertex
        {
            position = start - startPerpendicular * thickness / 2,
            color = lineColor,
            normal = Vector3.back
        };

        vh.AddUIVertexQuad(new[] { v1, v2, v3, v4 });
    }

    private void OnDrawGizmos()
    {
        for (var i = 0; i < linePoints.Length - 1; i++)
        {
            Gizmos.DrawLine(linePoints[i], linePoints[i + 1]);   
        }
    }

    public void SetPoints(Vector3[] points)
    {
        linePoints = points;
        SetVerticesDirty();
    }
}