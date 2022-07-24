using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class AnimateUI : MonoBehaviour
{
    #region  Variable
    //------------------------------------//

    RectTransform rectTransform;
    Vector2 size;

    //------------------------------------//
    #endregion




    #region  Unity Method
    //------------------------------------//

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();

        size = new Vector2(rectTransform.rect.width, rectTransform.rect.height);
        rectTransform.localPosition = Vector3.up * (size.y + 10);
    }

    //------------------------------------//
    #endregion




    #region  Public
    //------------------------------------//
    
    

    public void ShowPanel(){
        // Sequence inAndOut = DOTween.Sequence();
        // inAndOut.Append(rectTransform.DOAnchorPosY(0, 0.7f));
        // inAndOut.AppendInterval(1f);
        // inAndOut.Append(rectTransform.DOAnchorPosY(size.y + 10, 0.7f));

        rectTransform.DOAnchorPosY(0, 1f);
    }

    //------------------------------------//
    #endregion




    #region  Private
    //------------------------------------//

    //------------------------------------//
    #endregion
    
    
}
