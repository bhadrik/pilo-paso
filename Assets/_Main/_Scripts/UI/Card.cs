using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] GameObject blackout;
    [SerializeField] Image thumbnail;
    [SerializeField] GameObject deshLine;

    Toggle toggle;
    TextMeshProUGUI levelNumber;
    LevelInfo levelData;
    Image notSelectedOutline;
    RectTransform rect;
    // LineRenderer deshLine;

    public int Id{
        get{
            return levelData.id;
        }
    }

    private void Awake() {
        levelNumber = GetComponentInChildren<TextMeshProUGUI>();
        toggle = GetComponent<Toggle>();
        notSelectedOutline = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        // deshLine = GetComponentInChildren<LineRenderer>();
        // deshLine.enabled = false;

        toggle.onValueChanged.AddListener(OnToggle);

        deshLine.SetActive(false);
    }

    private void OnToggle(bool isOn)
    {
        if(deshLine != null)
        deshLine.SetActive(isOn);
        // deshLine.enabled = isOn;

        if(isOn){
            rect.DOScale(Vector3.one * 1.08f, 0.1f);
        }else{
            rect.DOScale(Vector3.one, 0.1f);
        }
    }

    public void Initialize(LevelInfo levelData){
        this.levelData = levelData;

        levelNumber.text = "Level " + levelData.id;
        blackout.SetActive(levelData.isLocked);
        toggle.interactable = !levelData.isLocked;
        thumbnail.sprite = levelData.thumbnail;
    }

    public void UnlockCardIfNot(){
        levelData.isLocked = false;
        blackout.SetActive(false);
        toggle.interactable = true;
        toggle.isOn = true;
    }
}
