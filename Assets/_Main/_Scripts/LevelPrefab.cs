using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelPrefab : MonoBehaviour
{
    #region  Variable
    //------------------------------------//
#if UNITY_EDITOR
    [Header("Editor")]
    [Tooltip("Level will not change, move infinite")]
    [SerializeField] public bool infinite;
#endif
    [HideInInspector] public Transform playerStart;
    [Header("Config")]
    [SerializeField] public int moves;
    // [Range(1,6)]
    // [SerializeField] public int diceUpNumber = 1;

    Tile[] tiles;

    public bool Completed{
        get
        {
            bool allDone = true;

            foreach (var tile in tiles)
            {
                allDone = allDone && tile.isActive;
                if(!allDone) break;
            }

#if UNITY_EDITOR
            if(infinite)
                allDone = false;
#endif

            return allDone;
        }
    }

    [HideInInspector]
    public UnityEvent onObjectiveComplete;

    //------------------------------------//
    #endregion




    #region  Unity Method
    //------------------------------------//

    private void Awake() {
        tiles = GetComponentsInChildren<Tile>();

        foreach (var tile in tiles)
        {
            tile.onFill.AddListener(OnAnyTileFill);
        }

        playerStart = transform.GetChild(0);
    }

    //------------------------------------//
    #endregion



    #region  Private
    //------------------------------------//
    
    private void OnAnyTileFill(){
        if(Completed){
            onObjectiveComplete.Invoke();
        }
    }

    //------------------------------------//
    #endregion
    
}
