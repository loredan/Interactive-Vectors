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

    private RectTransform _rectTransform;
    private Image _image;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();

        _rectTransform.pivot = new Vector2(0, 0.5f);
        UpdateLine();
    }

    private void OnValidate()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        if (!_image || !_rectTransform) return;

        _rectTransform.anchoredPosition3D = start;
        var magnitude = (end - start).magnitude;
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, magnitude);
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Math.Min(magnitude, maxSpriteHeight));
        _rectTransform.rotation = Quaternion.FromToRotation(Vector3.right, end - start);

        _image.color = color;
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