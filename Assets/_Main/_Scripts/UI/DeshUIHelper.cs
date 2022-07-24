using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeshUIHelper : MonoBehaviour
{
    #region  Variable
    //------------------------------------//
    [SerializeField] float offset = 1;

    LineRenderer lineRenderer;
    RectTransform rectTransform;

    Vector2 newPos;
    //------------------------------------//
    #endregion




    #region  Unity Method
    //------------------------------------//

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start() {
        // Debug.Log($"x: {rectTransform.anchoredPosition.x}");
        // Debug.Log($"y: {rectTransform.anchoredPosition.y}");
        // Debug.Log($"width: {rectTransform.rect.width}");
        // Debug.Log($"height: {rectTransform.rect.height}");
        
        newPos = new Vector2(rectTransform.rect.width/10 - offset, rectTransform.rect.height/10 - offset);

        lineRenderer.SetPosition(0, new Vector2(-newPos.x, -newPos.y));
        lineRenderer.SetPosition(1, new Vector2(newPos.x, -newPos.y));
        lineRenderer.SetPosition(2, new Vector2(newPos.x, newPos.y));
        lineRenderer.SetPosition(3, new Vector2(-newPos.x, newPos.y));
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
