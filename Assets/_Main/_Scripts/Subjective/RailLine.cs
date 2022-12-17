using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailLine : MonoBehaviour
{
    #region  Variable
    //------------------------------------//



    //------------------------------------//
    #endregion



    #region One
    //------------------------------------//
    
    
    
    //------------------------------------//
    #endregion



    #region file
    //------------------------------------//
    
    
    
    //------------------------------------//
    #endregion


    #region  Private
    //------------------------------------//
    

    
    //------------------------------------//
    #endregion



    #region  Unity Method
    //------------------------------------//

    private void OnCollisionEnter(Collision other) {
        var dice = other.gameObject.GetComponent<Dice>();

        if(dice == null) return;
        
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
