using System;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Image))]
public class Line : MonoBehaviour
{
    [SerializeField] private Vector3 start = Vector3.zero;
    [SerializeField] private Vector3 end = Vector3.right;
    [SerializeField] private Color color = Color.white;

    [Space] [SerializeField] private float maxSpriteHeight = 256;

    public Vector3 StartPosition => start;
    public Vector3 EndPosition => end;

    private RectTransform rectTransform;
    private Image image;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        rectTransform.pivot = new Vector2(0, 0.5f);
        UpdateLine();
    }

    private void OnValidate()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        if (!image || !rectTransform) return;

        rectTransform.anchoredPosition3D = start;
        var magnitude = (end - start).magnitude;
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, magnitude);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Math.Min(magnitude, maxSpriteHeight));
        rectTransform.rotation = Quaternion.FromToRotation(Vector3.right, end - start);

        image.color = color;
    }

    public void SetStart(Vector3 value)
    {
        start = value;
        UpdateLine();
    }

    public void SetEnd(Vector3 value)
    {
        end = value;
        UpdateLine();
    }

    public void SetColor(Color value)
    {
        color = value;
        UpdateLine();
    }
}