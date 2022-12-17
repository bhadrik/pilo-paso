using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGuide : MonoBehaviour
{
    #region  Variable
    //------------------------------------//
    MeshRenderer mesh;
    //------------------------------------//
    #endregion




    #region  Unity Method
    //------------------------------------//

    private void Awake() {
        mesh = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other) {
        // Debug.Log($"<color=green>[TileGuide]: Tag:{other.gameObject.tag}</color>");
        var tag = other.gameObject.tag;
        
        switch (tag)
        {
            case "one":
            mesh.material = GameManager.Instance.tile1;
            break;

            case "two":
            mesh.material = GameManager.Instance.tile2;
            break;

            case "three":
            mesh.material = GameManager.Instance.tile3;
            break;

            case "four":
            mesh.material = GameManager.Instance.tile4;
            break;

            case "five":
            mesh.material = GameManager.Instance.tile5;
            break;

            case "six":
            mesh.material = GameManager.Instance.tile6;
            break;
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
    
    

    //------------------------------------//
    #endregion
    
}
