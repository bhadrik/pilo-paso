using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MainMenu : MonoBehaviour
{
    #region  Variable
    //------------------------------------//
    public Volume global;
    [SerializeField] VolumeProfile mainMenuProfile;
    // [SerializeField] VolumeProfile inGame_Profile;
    VolumeProfile previousProfile;

    Vignette vignette;
    //------------------------------------//
    #endregion




    #region  Unity Method
    //------------------------------------//

    private void OnEnable() {
        previousProfile = global.profile;
        global.profile = mainMenuProfile;
    }

    private void OnDisable() {
        global.profile = previousProfile;
    }

    //------------------------------------//
    #endregion
    


}
