using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Image))] // Image is required to act as the Raycast Target
public class DragHandle : MonoBehaviour, IDragHandler
{
    [Header("Output")]
    public Vector3 CurrentValue { get; private set; }
    [SerializeField] private UnityEvent<Vector3> input;

    [Header("Setup (Auto-assigned if left empty)")]
    [SerializeField] private RectTransform canvasRectTransform;

    private void Awake()
    {
        if (canvasRectTransform == null)
            canvasRectTransform = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Convert screen touch/mouse position to Canvas local coordinates
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRectTransform, eventData.position, null, out Vector2 localPoint))
        {
            // Output the new Vector3
            CurrentValue = new Vector3(localPoint.x, localPoint.y, 0f);
            input?.Invoke(CurrentValue);
        }
    }
}