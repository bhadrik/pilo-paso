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
        GameManager.Instance.PlayerActiveToggle(false);
    }

    private void OnDisable() {
        global.profile = previousProfile;
    }

    //------------------------------------//
    #endregion
    


}
