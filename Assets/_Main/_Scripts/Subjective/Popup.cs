using UnityEngine;
using DG.Tweening;

public class Popup : MonoBehaviour
{
    #region  Variable
    //------------------------------------//
    [SerializeField] Vector3 punch = new Vector3(0.1f, 0.1f, 0f);
    [SerializeField] float duration = 0.3f;
    [SerializeField] int vibrato = 0;
    [SerializeField] float elasticity = 1;

    RectTransform rect;

    //------------------------------------//
    #endregion




    #region  Unity Method
    //------------------------------------//

    private void Awake() {
        rect = transform.GetChild(0).GetComponent<RectTransform>();
    }

    private void OnEnable() {
        if(rect == null) return;

        rect.DOPunchScale(punch, duration, vibrato, elasticity);
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
