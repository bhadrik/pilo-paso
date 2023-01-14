using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using System;
using UnityEngine.InputSystem;

public class Dice : MonoBehaviour
{
    #region  Variable
    //------------------------------------//

    [SerializeField] GameObject diceMesh;
    [SerializeField] int speed = 300;
    bool isMoving = false;

    [SerializeField] bool blockLeft;
    [SerializeField] bool blockRight;
    [SerializeField] bool blockForward;
    [SerializeField] bool blockBack;

    // [SerializeField] MeshRenderer right;
    // [SerializeField] MeshRenderer left;
    // [SerializeField] MeshRenderer forward;
    // [SerializeField] MeshRenderer back;

    [HideInInspector]
    public UnityEvent onPlayerMove;

    AudioSource sound;
    InputControl inputControl;
    // GameObject shadowPanelParent;

    

    //------------------------------------//
    #endregion




    #region  Unity Method
    //------------------------------------//

    private void Awake() {
        sound = GetComponent<AudioSource>();
        inputControl = new InputControl();
        // shadowPanelParent = right.transform.parent.gameObject;
    }

    private void Start() {
        inputControl.Dice.Enable();

        inputControl.Dice.Forward.performed += (c) =>{
            if(!blockForward) StartCoroutine(I_Roll(Vector3.forward));
        };

        inputControl.Dice.Backward.performed += (c) =>{
            if(!blockBack) StartCoroutine(I_Roll(Vector3.back));
        };

        inputControl.Dice.Right.performed += (c) =>{
            if(!blockRight) StartCoroutine(I_Roll(Vector3.right));
        };

        inputControl.Dice.Left.performed += (c) =>{
            if(!blockLeft) StartCoroutine(I_Roll(Vector3.left));
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("block left"))
            blockLeft = true;
        else if(other.gameObject.CompareTag("block right"))
            blockRight = true;
        else if(other.gameObject.CompareTag("block forward"))
            blockForward = true;
        else if(other.gameObject.CompareTag("block back"))
            blockBack = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("block left"))
            blockLeft = false;
        else if(other.gameObject.CompareTag("block right"))
            blockRight = false;
        else if(other.gameObject.CompareTag("block forward"))
            blockForward = false;
        else if(other.gameObject.CompareTag("block back"))
            blockBack = false;
    }

    //------------------------------------//
    #endregion




    #region  Public
    //------------------------------------//
    
    public void ResetMovingConstrains(){
        blockBack = false;
        blockForward = false;
        blockLeft = false;
        blockRight = false;
    }

    public void GoingAnim(){
        Sequence s = DOTween.Sequence();
        s.Append(diceMesh.transform.DOScale(Vector3.one * 1.05f, 0.1f));
        s.Append(diceMesh.transform.DOScale(Vector3.zero, 0.4f));
    }

    public void CommingAnim(bool activeOnComplete = true){
        Sequence s = DOTween.Sequence();
        s.Append(diceMesh.transform.DOScale(Vector3.one * 1.05f, 0.4f));
        s.Append(diceMesh.transform.DOScale(Vector3.one, 0.1f));

        if(activeOnComplete)
        s.AppendCallback(() => {
            ToggleActiveState(true);
        });
    }

    public void ToggleActiveState(bool isOn){
        if(inputControl==null) {
            StartCoroutine(I_WaitForInputController(isOn));
            return;
        }

        if(isOn) inputControl.Dice.Enable();
        else inputControl.Dice.Disable();
    }

    public void ResetGraphicsScale(){
        diceMesh.transform.localScale = Vector3.zero;
    }

    //------------------------------------//
    #endregion




    #region  Private
    //------------------------------------//
    
    IEnumerator I_Roll(Vector3 direction) {
        // [Exit if already moveing]
        if(isMoving) yield break;

        isMoving = true;
        // shadowPanelParent.SetActive(false);

        onPlayerMove.Invoke();
        sound.Play();

        float remainingAngle = 90;
        Vector3 rotationCenter = transform.position + direction / 2 + Vector3.down / 2;
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);

        while (remainingAngle > 0) {
            float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
            transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
            remainingAngle -= rotationAngle;
            yield return null;
        }

        // shadowPanelParent.SetActive(true);
        // shadowPanelParent.transform.rotation = Quaternion.identity;
        isMoving = false;
    }

    IEnumerator I_WaitForInputController(bool isOn){
        while(inputControl == null) yield return null;

        ToggleActiveState(isOn);
    }

    //------------------------------------//
    #endregion
    
}