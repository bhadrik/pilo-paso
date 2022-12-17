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

    public LevelSO[] levels_so;


    private void Awake() {
        toggleGroup = GetComponent<SmartToggleGroup>();
        levels_so = Resources.LoadAll<LevelSO>("");
        Array.Sort(levels_so, new LevelSoComparer());

        startButton.onClick.AddListener(() => {
            var card = toggleGroup.Selected.GetComponent<Card>();

            GameManager.Instance.LoadLevel(card.Id-1, $"Level {card.Id}");
        });
    }

    private void Start() {
        foreach(var level in levels_so){
            Toggle t = Instantiate(pr_Card, transform).GetComponent<Toggle>();
            toggleGroup.Add(t);

            var card = t.gameObject.GetComponent<Card>();
            card.SetLevelData(level);
            cards.Add(card);

            count++;
        }
    }

    public void UnlockIfLocked(int index){
        levels_so[index].isLocked = false;
        cards[index].SetLevelData(levels_so[index]);
    }
}

class LevelSoComparer : IComparer
{
    public int Compare(object x, object y)
    {
        return ((LevelSO)x).id.CompareTo(((LevelSO)y).id);
    }
}