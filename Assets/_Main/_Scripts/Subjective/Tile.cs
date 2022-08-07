
using UnityEngine;
using UnityEngine.Events;

public class Tile : MonoBehaviour
{
    #region  Variable
    //------------------------------------//

    [SerializeField] public TileNumber tileType;

    [SerializeField] GameObject deshLine;
    [SerializeField] GameObject fullLine;

    [Space]
    [SerializeField] Color notCollectedColor_icon;
    [SerializeField] Color notCollectedColor_bg;
    [SerializeField] Color collectedColor_icon;
    [SerializeField] Color collectedColor_bg;
    public bool isActive;


    [HideInInspector]
    public UnityEvent onFill;

    AudioSource sound;
    MeshRenderer tileRenderer;

    const string BACK_COLOR = "_BgColor";
    const string ICON_COLOR = "_IconColor";

    //------------------------------------//
    #endregion




    #region Unity Method
    //------------------------------------//
    private void Awake() {
        tileRenderer = GetComponentInChildren<MeshRenderer>();
        sound = GetComponent<AudioSource>();
    }

    private void Start() {
        fullLine.SetActive(isActive);
        deshLine.SetActive(!isActive);

        ActiveStatus(isActive);
    }

    private void OnTriggerEnter(Collider other)
    {
        // In game tile touch
        if(isActive) return;

        else if(other.gameObject.CompareTag(tileType.ToString())){
            isActive = true;

            // Visual changes in tile
            fullLine.gameObject.SetActive(true);
            deshLine.gameObject.SetActive(false);
            ActiveStatus(isActive);

            sound.Play();
            onFill.Invoke();
        }
    }

    // private void OnValidate() {
    //     ActiveStatus(isActive);
    // }

    //------------------------------------//
    #endregion




    #region Public
    //------------------------------------//
    
    

    //------------------------------------//
    #endregion




    #region Private
    //------------------------------------//
    
    private void ActiveStatus(bool isActive){
        Color bg = isActive? collectedColor_bg : notCollectedColor_bg;
        Color icon = isActive? collectedColor_icon : notCollectedColor_icon;


#if UNITY_EDITOR
        if(!Application.isPlaying){
            tileRenderer = GetComponentInChildren<MeshRenderer>();

            tileRenderer.sharedMaterial.SetColor(BACK_COLOR, bg);
            tileRenderer.sharedMaterial.SetColor(ICON_COLOR, icon);
            return;
        }
#endif

        tileRenderer.material.SetColor(BACK_COLOR, bg);
        tileRenderer.material.SetColor(ICON_COLOR, icon);
    }

    //------------------------------------//
    #endregion
    
}

public enum TileNumber{
    none,
    one,
    two,
    three,
    four,
    five,
    six,
    deth
}