using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackgroundMusic : SingletonBehaviour<BackgroundMusic>
{
    #region  Variable
    //------------------------------------//
    
    AudioSource audioSource;

    [SerializeField] AudioClip mainMenuClip;
    [SerializeField] AudioClip inGameClip;

    bool isMainMenu = true;

    //------------------------------------//
    #endregion




    #region  Unity Method
    //------------------------------------//

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    //------------------------------------//
    #endregion




    #region  Public
    //------------------------------------//
    
    [ContextMenu("Play MainMenu")]
    public void MainMenu(){
        if(isMainMenu) return;

        ChangeClip(mainMenuClip);
        isMainMenu = true;
    }   

    [ContextMenu("Play InGame")]
    public void InGame(){
        if(!isMainMenu) return;

        ChangeClip(inGameClip);
        isMainMenu = false;
    } 

    //------------------------------------//
    #endregion




    #region  Private
    //------------------------------------//

    void ChangeClip(AudioClip clip){
        Sequence sequence = DOTween.Sequence();
        sequence.Append(audioSource.DOFade(0, 0.5f));
        sequence.AppendCallback(() => {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        });
        sequence.AppendInterval(0.3f);
        sequence.Append(audioSource.DOFade(1, 0.5f));
    }

    //------------------------------------//
    #endregion
    
}
