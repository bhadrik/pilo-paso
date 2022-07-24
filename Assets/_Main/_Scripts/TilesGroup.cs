using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesGroup : MonoBehaviour
{
    #region  Variable
    //------------------------------------//

    Tile[] tiles = new Tile[14*14];
    [SerializeField] GameObject TilePrefab;
    [SerializeField] int saveToLevelIndex;

    //------------------------------------//
    #endregion




    #region  Unity Method
    //------------------------------------//

    private void OnEnable() {
        // tiles = GetComponentsInChildren<Tile>();
    }

    private void Start() {
        LevelSO level = Resources.LoadAll<LevelSO>("Levels")[0];
        bool levelOk = level.tilesTypei.Length != 0;

        Debug.Log($"Level: {level.name} length is: {level.tilesTypei.Length} LevelOK: {levelOk}");

        var index = 0;

        for(int i = 0; i < 14; i++){
            for(int j = 0; j < 14; j++){
                Vector3 pos = new Vector3(i, -0.5f, j); 
                tiles[index] = Instantiate(TilePrefab, pos, Quaternion.identity, transform).GetComponent<Tile>();

                if(levelOk)
                // tiles[index].GenerateTile(level.tilesTypei[index]);

                index++;
            }
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.O)){
            SaveToFile();
        }
    }

    //------------------------------------//
    #endregion




    #region  Public
    //------------------------------------//
    
    

    //------------------------------------//
    #endregion




    #region  Private
    //------------------------------------//
    
    private void SaveToFile(){
        var level = Resources.LoadAll<LevelSO>("Levels")[saveToLevelIndex];
        level.tilesTypei = new TileNumber[14*14];

        var index = 0;

        for(int i=0; i < tiles.Length; i++)
        {
            // Debug.Log($"Index: {index}({i},{j}) {tiles[index].gameObject.name} {tiles[index].tileType}");
            Debug.Log("Index: " + index);
            if(tiles == null)
                Debug.Log("tiles null");
            else{
                Debug.Log(tiles.Length);
            }
            level.tilesTypei[index] = tiles[index].tileType;
            index++;
        }


        Debug.Log("last Index: " + index);
    }

    //------------------------------------//
    #endregion
    
}
