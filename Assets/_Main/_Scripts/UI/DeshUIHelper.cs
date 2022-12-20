using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeshUIHelper : MonoBehaviour
{
    #region  Variable
    //------------------------------------//
    [SerializeField] float offset = 1;
    [SerializeField] float scaler = 5;
    [SerializeField] bool hideRightSide;

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

        transform.localScale = Vector3.one * scaler;
        
        newPos = new Vector2(rectTransform.rect.width/2/scaler - offset, rectTransform.rect.height/2/scaler - offset);

        lineRenderer.SetPosition(0, new Vector2(-newPos.x, -newPos.y));

        lineRenderer.SetPosition(1, new Vector2(newPos.x + (hideRightSide ? 5:0), -newPos.y));
        lineRenderer.SetPosition(2, new Vector2(newPos.x + (hideRightSide ? 5:0), newPos.y));
        lineRenderer.SetPosition(3, new Vector2(-newPos.x, newPos.y));
    }

    [ContextMenu("Update line")]
    private void UpdateScale(){
        Start();
    }

    //------------------------------------//
    #endregion
}
