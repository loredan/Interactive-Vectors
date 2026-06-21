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
    [SerializeField] private float width = 0.1f;

    private RectTransform _rectTransform;
    private Image _image;

    void Awake()
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
        if (_image == null || _rectTransform == null) return;

        _rectTransform.anchoredPosition3D = start;
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, width);
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (end - start).magnitude);
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