using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "New Level Data")]
public class LevelData_SO : ScriptableObject
{
    public Sprite thumbnailNotFound;
    public List<LevelInfo> levels = new List<LevelInfo>();
    
    private const string UNLOCKED_LEVEL = "UNLOCKED_LEVEL";
    private const string LOCKED_SIGN = "1";
    private const string UNLOCKED_SIGN = "0";

    GameObject[] prefabs;
    Sprite[] thumbnails;
    bool[] isLocked;

    int counter = 1;
    string unlockedLevels;
    bool noLevlDataFound = true;

    private void Awake() {
        // Debug.Log($"<color=#ebe134>[LevelData_SO]: Awake</color>");

        unlockedLevels = PlayerPrefs.GetString(UNLOCKED_LEVEL);
        noLevlDataFound = string.IsNullOrEmpty(unlockedLevels);

        Debug.Log($"<color=white>Unlocked: {unlockedLevels}</color>");

        // unlockedLevels = "0 0 0 1 1 1 1 1 1 1 1 1 1 1 1 1"
        if(!noLevlDataFound){
            int i = 0;

            isLocked =  new bool[unlockedLevels.Length];

            foreach(var value in unlockedLevels.Split(' ')){
                isLocked[i++] = value == LOCKED_SIGN;
            }
        }

        AutoFillLevelData();
    }

    public void AutoFillLevelData(){
        // Debug.Log($"<color=#ebe134>--- Auto fill level data ---</color>");
        levels.Clear();

        counter = 1;

        prefabs = Resources.LoadAll<GameObject>("Level/L_Prefab");
        Array.Sort(prefabs, new ObjectNameComparer());

        thumbnails = Resources.LoadAll<Sprite>("Level/L_Thumbnail");
        Array.Sort(thumbnails, new ObjectNameComparer());

        StringBuilder rawString = new StringBuilder();

        foreach(var prefab in prefabs){
            int index = counter - 1;

            var info = new LevelInfo();
            info.prefab = prefab;
            info.id = counter++;
            
            // Debug.Log($"<color=green>Thumbnail index: {index}, T: {thumbnails.Length}</color>");
            if(thumbnails != null && index < thumbnails.Length){
                info.thumbnail = thumbnails[index];
            }else{
                info.thumbnail = thumbnailNotFound;
            }

            if(noLevlDataFound){
                info.isLocked = true;
                string status = LOCKED_SIGN;

                if(index == 0){
                    info.isLocked = false;
                    status = UNLOCKED_SIGN;
                }

                rawString.Append(status + ' ');

                Debug.Log($"<color=green>New Data: {rawString}</color>");

                PlayerPrefs.SetString(UNLOCKED_LEVEL, rawString.ToString());
            }
            else{
                info.isLocked = isLocked[index];
            }

            levels.Add(info);
        }
    }
    
    public void UnlockedLevel(int index){
        string[] data = PlayerPrefs.GetString(UNLOCKED_LEVEL).Split(" ");
        if(data[index].Equals(UNLOCKED_SIGN)) return;

        data[index] = UNLOCKED_SIGN;
        PlayerPrefs.SetString(UNLOCKED_LEVEL, string.Join(" ", data));
        levels[index].isLocked = false;
    }

    public void ResetData(){
        Awake();
    }
}

[Serializable]
public class LevelInfo
{
    /* [HideInInspector]  */public int id;
    public Sprite thumbnail;
    public GameObject prefab;
    public bool isLocked = true;

    public LevelInfo(int id, Sprite thum, GameObject pre){
        this.id = id;
        thumbnail = thum;
        prefab = pre;
        if(id == 1){
            isLocked = false;
        }
    }
    public LevelInfo(){

    }
}

class ObjectNameComparer : IComparer
{
    public int Compare(object x, object y)
    {
        int xId = int.Parse(((UnityEngine.Object)x).name.Split("_")[1]);
        int yId = int.Parse(((UnityEngine.Object)y).name.Split("_")[1]);

        return xId.CompareTo(yId);
    }
}

#if UNITY_EDITOR
 [CustomEditor(typeof(LevelData_SO))]
 public class TestScriptableEditor : Editor
 {
     public override void OnInspectorGUI()
     {
         base.OnInspectorGUI();
         var script = (LevelData_SO)target;
 
        if(GUILayout.Button("Update Data"))
        {
            script.ResetData();
            // script.AutoFillLevelData();
        }
         
     }
 }
 #endif