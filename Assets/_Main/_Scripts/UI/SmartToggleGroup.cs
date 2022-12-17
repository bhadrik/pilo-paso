using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SmartToggleGroup : ToggleGroup
{
    [HideInInspector] public UnityEvent<Toggle> onSelectionChange;

    Toggle[] toggles;

    public Toggle Selected
    {
        get{
            foreach (var t in ActiveToggles())
            {
                return t;
            }

            // if allowed turn off
            return null;
        }
    }

    protected override void Awake()
    {
        base.Awake();

        toggles = GetComponentsInChildren<Toggle>();

        foreach(var t in toggles){
            t.group = this;

            t.onValueChanged.AddListener((isOn) => 
            {
                if(isOn){
                    onSelectionChange.Invoke(t);
                }
            });
        }
    }

    public void Add(Toggle t){
        t.group = this;

        t.onValueChanged.AddListener((isOn) => 
        {
            if(isOn){
                onSelectionChange.Invoke(t);
            }
        });
    }
}
