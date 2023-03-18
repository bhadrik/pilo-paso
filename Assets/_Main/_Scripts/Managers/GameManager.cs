using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
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


    [Header("Clip")]
    [SerializeField] AudioClip positiveClip;
    [SerializeField] AudioClip negativeClip;


    // [Header("Level")]
    // [SerializeField] GameObject[] levels;

    LevelPrefab lodedLevel;
    AudioSource audioSource;
    AnimateUI endUI;
    InputControl inputControl;

    [HideInInspector] public Material tile1;
    [HideInInspector] public Material tile2;
    [HideInInspector] public Material tile3;
    [HideInInspector] public Material tile4;
    [HideInInspector] public Material tile5;
    [HideInInspector] public Material tile6;

    int loadedLevelIndex;
    int remainMoves;
    bool currentLevelCompleted;

    //------------------------------------//
    #endregion




    #region  Unity Method
    //------------------------------------//

    private void Awake() {
        player.onPlayerMove.AddListener(OnPlayerMove);
        // blackCurtain.reachMax.AddListener(ActualLevelChange);
        audioSource = GetComponent<AudioSource>();
        inputControl = new InputControl();

        tile1 = Resources.Load<Material>("Shadow mat/tile 1");
        tile2 = Resources.Load<Material>("Shadow mat/tile 2");
        tile3 = Resources.Load<Material>("Shadow mat/tile 3");
        tile4 = Resources.Load<Material>("Shadow mat/tile 4");
        tile5 = Resources.Load<Material>("Shadow mat/tile 5");
        tile6 = Resources.Load<Material>("Shadow mat/tile 6");
    }

    private void Start() {
        // LoadLevel(0, "Level 1");
        // moveText.text = "";
        // UIManager.Instance.UpdateRemainingMoves(remainMoves);
        // UIManager.Instance.UpdateLevelNumber(loadedLevelIndex+1/LevelList.Instance.levels_so.Length);


        inputControl.GameControl.Enable();
        inputControl.GameControl.Restart.performed += (c) => RestartLevel();
        inputControl.GameControl.NextLevel.performed += (c) => NextLevel();
        inputControl.GameControl.PreviousLevel.performed += (c) => PreviousLevel();
        inputControl.GameControl.FinishGame.performed += (c) => UIManager.Instance.SwitchState(UIState.Finish);
    }


    //------------------------------------//
    #endregion




    #region  Public
    //------------------------------------//

    public void PlayerActiveToggle(bool isOn){
        player.ToggleActiveState(isOn);
    }

    public void RestartGame(){
        SceneManager.LoadSceneAsync(0);
    }

    public void RestartLevel(string msg = null){
        player.ToggleActiveState(false);

        if(string.IsNullOrEmpty(msg))
            msg = $"Level {loadedLevelIndex+1}";
            
        LoadLevel(loadedLevelIndex, msg);
    }

    public void OpenLink(){
        Application.OpenURL("https://pixabay.com/sound-effects/");
    }

    public void QuitGame(){
        Application.Quit();
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
    
    public void LoadLevel(int i, string msg){
        // Debug.Log("Load level: "+ i + " Level.Length" + levels.Length);

        loadedLevelIndex = i;

        // [completed last level]
        if(loadedLevelIndex == LevelList.Instance.Length){
            UIManager.Instance.SwitchState(UIState.Finish);
        }
        // [load next level]
        else{
            UIManager.Instance.ShowCover(msg, onCoverMax: ActualLevelChange);
        }

        BackgroundMusic.Instance.InGame();
    }

    //[Called by animator event after scene is covered properly]
    private void ActualLevelChange(){
        if(lodedLevel != null){
            Destroy(lodedLevel.gameObject);
        }

        lodedLevel = Instantiate(LevelList.Instance.levelData.levels[loadedLevelIndex].prefab, Vector3.zero, Quaternion.identity).GetComponent<LevelPrefab>();
        
        lodedLevel.onObjectiveComplete.AddListener(OnLevelComplete);
        currentLevelCompleted = false;

        player.ResetMovingConstrains();
        player.transform.SetPositionAndRotation(lodedLevel.playerStart.position, lodedLevel.playerStart.rotation);
        player.ResetGraphicsScale();

        Run.After(1.5f, () => {
            player.CommingAnim();
        });

        remainMoves = lodedLevel.moves;
        UIManager.Instance.UpdateRemainingMoves(remainMoves);
        UIManager.Instance.UpdateLevelNumber((loadedLevelIndex+1)%LevelList.Instance.Length);
        UIManager.Instance.SwitchState(UIState.InGame);

        // [Show tutorial video in first level only]
        if(loadedLevelIndex==0) UIManager.Instance.ShowTutorialVideo();
    }

    private void OnPlayerMove(){
        if(remainMoves < 0) return;

        remainMoves--;
        UIManager.Instance.UpdateRemainingMoves(remainMoves);

#if UNITY_EDITOR
        if(infinite) return;
#endif

        //[Check for move finish]
        if(remainMoves == 0){
            // [Lost control while level finish check]
            
            player.ToggleActiveState(false);

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
        player.ToggleActiveState(false);
        currentLevelCompleted = true;

        player.GoingAnim();

        audioSource.PlayOneShot(positiveClip);

        Run.After(1.0f, () => {
            int nextLevelIndex = loadedLevelIndex+1;

            LevelList.Instance.UnlockIfLocked(nextLevelIndex);
            LoadLevel(nextLevelIndex, $"Level {nextLevelIndex+1}");
        });
    }

    //------------------------------------//
    #endregion
    
}