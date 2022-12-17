using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Color selected;
    [SerializeField] Color unselected;

    [SerializeField] GameObject blackout;

    Toggle toggle;
    TextMeshProUGUI levelNumber;
    Image backgroundImg;
    LevelSO levelData;

    public int Id{
        get{
            return levelData.id;
        }
    }

    private void Awake() {
        backgroundImg = GetComponent<Image>();
        levelNumber = GetComponentInChildren<TextMeshProUGUI>();
        toggle = GetComponent<Toggle>();

        toggle.onValueChanged.AddListener(OnToggle);
    }

    private void OnToggle(bool isOn)
    {
        if(isOn) backgroundImg.color = selected;
        else backgroundImg.color = unselected;
    }

    public void SetLevelData(LevelSO levelData){
        this.levelData = levelData;

        levelNumber.text = "Level " + levelData.id;
        blackout.SetActive(levelData.isLocked);
        toggle.interactable = !levelData.isLocked;
    }
}
