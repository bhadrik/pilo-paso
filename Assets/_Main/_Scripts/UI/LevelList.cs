using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelList : SingletonBehaviour<LevelList>
{
    [SerializeField] GameObject pr_Card;
    [SerializeField] Button startButton;

    SmartToggleGroup toggleGroup;
    List<Card> cards = new List<Card>();

    int count = 1;

    // public LevelSO[] levels_so;
    public LevelData_SO levelData;

    public int Length
    {
        get {
            return levelData.levels.Count;
        }
    }


    private void Awake() {
        toggleGroup = GetComponent<SmartToggleGroup>();

        levelData = Resources.Load<LevelData_SO>("Level/Level Data");
        // levelData = new LevelData_SO();

        startButton.onClick.AddListener(() => {
            var card = toggleGroup.Selected.GetComponent<Card>();

            GameManager.Instance.LoadLevel(card.Id-1, $"Level {card.Id}");
        });
    }

    private void Start() {
        Toggle lastUnlockedLevel = null;

        foreach(var level in levelData.levels){
            Toggle t = Instantiate(pr_Card, transform).GetComponent<Toggle>();
            toggleGroup.Add(t);

            var card = t.gameObject.GetComponent<Card>();
            card.Initialize(level);
            cards.Add(card);

            count++;

            if(!level.isLocked) lastUnlockedLevel = t;
        }

        if(lastUnlockedLevel != null)
        lastUnlockedLevel.isOn = true;
    }

    public void UnlockIfLocked(int index){
        // Update unlock in db
        levelData.UnlockedLevel(index);

        // reflect changes on UI
        cards[index].UnlockCardIfNot();
    }
}