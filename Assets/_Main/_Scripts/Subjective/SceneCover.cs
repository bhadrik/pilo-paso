using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SceneCover : MonoBehaviour
{
    
    #region  Variable
    //------------------------------------//

    [HideInInspector]
    public UnityEvent reachMax;

    TextMeshProUGUI messageText;
    RectTransform rectTransform;

    Vector2 size;

    //------------------------------------//
    #endregion




    #region  Unity Method
    //------------------------------------//

    private void Awake() {
        messageText = GetComponentInChildren<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();

        size = new Vector2(rectTransform.rect.width, rectTransform.rect.height);
        rectTransform.localPosition = Vector3.up * (size.y + 10);
    }

    //------------------------------------//
    #endregion




    #region  Public
    //------------------------------------//
    
    

    public void StartCover(string msg){
        messageText.text = msg;

        Sequence inAndOut = DOTween.Sequence();
        inAndOut.Append(rectTransform.DOAnchorPosY(0, 0.7f));
        inAndOut.AppendCallback(new TweenCallback(OnRechMax));
        inAndOut.AppendInterval(1f);
        inAndOut.Append(rectTransform.DOAnchorPosY(size.y + 10, 0.7f));
    }

    //------------------------------------//
    #endregion




    #region  Private
    //------------------------------------//

    private void OnRechMax(){
        reachMax?.Invoke();
    }

    //------------------------------------//
    #endregion
    
}
