using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private Transform container;
    
    [Space] [SerializeField] private MonoBehaviour[] demos;

    private GameObject current;

    private void Awake()
    {
        dropdown.ClearOptions();

        var options = new List<string>();
        foreach (var demo in demos)
        {
            if (demo is IDemo demoInterface)
            {
                options.Add(demoInterface.DropdownName);
            }
        }
        
        dropdown.AddOptions(options);
        dropdown.onValueChanged.AddListener(SwitchDemo);
    }

    private void Start()
    {
        SwitchDemo(0);
    }

    private void SwitchDemo(int index)
    {
        if (current)
        {
            Destroy(current);
        }

        current = Instantiate(demos[index].gameObject, container);
    }
}
