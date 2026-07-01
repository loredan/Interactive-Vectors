using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TMP_Text))]
public class SliderLabel : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        text.text = slider.value.ToString("F");
    }
}