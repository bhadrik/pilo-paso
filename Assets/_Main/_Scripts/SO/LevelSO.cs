using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level")]
public class LevelSO : ScriptableObject
{
    public int id;
    public Sprite thumbnail;
    public bool isLocked = true;
    public GameObject prefab;
}
