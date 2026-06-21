using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(Line))]
public class Arrow : MonoBehaviour
{
    [SerializeField] private Vector3 start = Vector3.zero;
    [SerializeField] private Vector3 end = Vector3.right;
    [SerializeField] private Color color = Color.red;
    [Space] [SerializeField] private Image arrowhead;
    [SerializeField] private float stemOffset;

    private Line _line;


    private void Awake()
    {
        _line = GetComponent<Line>();
        UpdateArrow();
    }

    private void OnValidate()
    {
        UpdateArrow();
    }

    private void UpdateArrow()
    {
        if (_line == null) return;

        ((RectTransform)arrowhead.transform).anchoredPosition3D = Vector3.right * stemOffset;
        arrowhead.transform.rotation = Quaternion.FromToRotation(Vector3.right, end - start);
        arrowhead.color = color;
        _line.SetStart(start);
        _line.SetEnd(end - Vector3.Normalize(end - start) * stemOffset);
        _line.SetColor(color);
    }

    public void SetStart(Vector3 value)
    {
        start = value;
        UpdateArrow();
    }

    public void SetEnd(Vector3 value)
    {
        end = value;
        UpdateArrow();
    }

    public void SetVector3Value(Vector3 value)
    {
        SetEnd(value);
    }
}