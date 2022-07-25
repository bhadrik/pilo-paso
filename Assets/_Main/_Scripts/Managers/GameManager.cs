using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    #region  Variable
    //------------------------------------//
    #if UNITY_EDITOR
    // int moveCountsAfterClear;

    [Header("Editor")]
    [Tooltip("Level will not change, move infinite")]
    [SerializeField] public bool infinite;
    #endif

    [Header("General")]
    [SerializeField] Dice player;
    [SerializeField] TextMeshProUGUI moveText;
    [SerializeField] GameObject finishCanvas;
    [SerializeField] GameObject uiCanvas;
    [SerializeField] SceneCover blackCurtain;
    [SerializeField] TextMeshProUGUI levelCountText;


    [Header("Clip")]
    [SerializeField] AudioClip positiveClip;
    [SerializeField] AudioClip negativeClip;


    [Header("Level")]
    [SerializeField] GameObject[] levels;

    
    LevelPrefab lodedLevel;
    AudioSource audioSource;
    AnimateUI endUI;
    InputControl inputControl;

    int loadedLevelIndex;
    int remainMoves;
    bool currentLevelCompleted;

    //------------------------------------//
    #endregion




    #region  Unity Method
    //------------------------------------//

    private void Awake() {
        player.onPlayerMove.AddListener(OnPlayerMove);
        blackCurtain.reachMax.AddListener(ActualLevelChange);
        audioSource = GetComponent<AudioSource>();
        endUI = finishCanvas.GetComponentInChildren<AnimateUI>();
        inputControl = new InputControl();
    }

    private void Start() {
        LoadLevel(0, "Level 1");
        moveText.text = "";
        levelCountText.text = $"{loadedLevelIndex+1}/{levels.Length}";

        inputControl.GemeControl.Enable();
        inputControl.GemeControl.Restart.performed += (c) => RestartLevel();
        inputControl.GemeControl.NextLevel.performed += (c) => NextLevel();
        inputControl.GemeControl.PreviousLevel.performed += (c) => PreviousLevel();
    }

    //------------------------------------//
    #endregion




    #region  Public
    //------------------------------------//

    public void RestartGame(){
        SceneManager.LoadSceneAsync(0);
    }

    public void RestartLevel(string msg = null){
        // player.enabled = false;
        player.Control(false);

        if(string.IsNullOrEmpty(msg))
            msg = $"Level {loadedLevelIndex+1}";
            
        LoadLevel(loadedLevelIndex, msg);
    }

    public void OpenLink(){
        Application.OpenURL("https://pixabay.com/sound-effects/");
    }

// #if UNITY_EDITOR
    public void NextLevel(){
        if(loadedLevelIndex == 9) return;
        LoadLevel(loadedLevelIndex+1, "Next Level " + (loadedLevelIndex + 2));
    }

    public void PreviousLevel(){
        if(loadedLevelIndex == 0) return;
        LoadLevel(loadedLevelIndex-1, "Previous Level " + (loadedLevelIndex));
    }
// #endif
    //------------------------------------//
    #endregion




    #region  Private
    //------------------------------------//
    
    private void LoadLevel(int i, string msg){
        // Debug.Log("Load level: "+ i + " Level.Length" + levels.Length);

        // player.enabled = false;

        loadedLevelIndex = i;

        if(i == levels.Length){
            //[Show congrets on all level complete]
            ShowFinishUI();
        }
        else{
            blackCurtain.StartCover(msg);
        }
    }

    //[Called by animator event after scene is covered properly]
    private void ActualLevelChange(){
        if(lodedLevel != null){
            Destroy(lodedLevel.gameObject);
        }

        lodedLevel = Instantiate(levels[loadedLevelIndex], Vector3.zero, Quaternion.identity).GetComponent<LevelPrefab>();
        
        lodedLevel.onObjectiveComplete.AddListener(() => OnLevelComplete());
        currentLevelCompleted = false;

        player.ResetMovingConstrains();
        player.transform.SetPositionAndRotation(lodedLevel.playerStart.position, lodedLevel.playerStart.rotation);
        player.ResetGraphicsScale();

        Run.After(1.5f, () => {
            // player.enabled = true;
            player.Control(true);
            player.CommingAnim();
        });

        remainMoves = lodedLevel.moves;
        moveText.text = remainMoves.ToString();
        levelCountText.text = $"{loadedLevelIndex+1}/{levels.Length}";
    }

    private void ShowFinishUI(){
        finishCanvas.SetActive(true);
        uiCanvas.SetActive(false);
        endUI.ShowPanel();
    }

    private void OnPlayerMove(){
        remainMoves--;
        moveText.text = remainMoves.ToString();

#if UNITY_EDITOR
        if(infinite) return;
#endif

        //[Check for move finish]
        if(remainMoves == 0){
            // [Lost control while level finish check]
            // player.enabled = false;
            player.Control(false);

            Run.After(1, () => {
                if(!currentLevelCompleted){
                    audioSource.PlayOneShot(negativeClip);
                    RestartLevel("Out of moves");
                }
            });
        }
    }

    private void OnLevelComplete(){
        // Debug.Log("Level complete");
        // player.enabled = false;
        player.Control(false);
        currentLevelCompleted = true;

        player.GoingAnim();

        audioSource.PlayOneShot(positiveClip);

        Run.After(1.0f, () => {
            LoadLevel(loadedLevelIndex+1, $"Level {loadedLevelIndex+2}");
        });
    }

    //------------------------------------//
    #endregion
    
}