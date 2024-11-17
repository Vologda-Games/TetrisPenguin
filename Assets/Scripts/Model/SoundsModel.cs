using UnityEngine;

public class SoundsModel : MonoBehaviour
{
    //Key for boolian playing music ---> PlayMusic in the !!!STRING!!!
    //Key for boolian playing sounds ---> PlaySounds in the !!!STRING!!!

    [Header("MusicAndSounds")]
    [SerializeField] public static GameObject[] _music;
    [SerializeField] public static GameObject[] _sounds;

    [Header("Boolian")]
    public bool _playSouds;
    public bool _playMusic;

    [Header("Scripts")]
    public static SoundsModel instance;

    private void Awake() 
    {
        instance = this;
        _music = Resources.LoadAll<GameObject>("Prefabs/SoundsAndMusic/Music");
        _sounds = Resources.LoadAll<GameObject>("Prefabs/SoundsAndMusic/Sounds");
    }
}

public class SaveSoundsModel
{
    public bool _playSouds;
    public bool _playMusic;
}