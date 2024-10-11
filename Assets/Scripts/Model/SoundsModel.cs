using System.Linq;
using UnityEngine;

public class SoundsModel : MonoBehaviour
{
    //Key for boolian playing music ---> PlayMusic in the !!!STRING!!!
    //Key for boolian playing sounds ---> PlaySounds in the !!!STRING!!!

    [Header("MusicAndSounds")]
    [SerializeField] public static GameObject[] _music;
    [SerializeField] public static GameObject[] _sounds;

    [Header("Boolian")]
    [SerializeField] public static bool _playSouds;
    [SerializeField] public static bool _playMusic;

    private void Awake() 
    {
        _music = Resources.LoadAll<GameObject>("Prefabs/SoundsAndMusic/Music");
        _sounds = Resources.LoadAll<GameObject>("Prefabs/SoundsAndMusic/Sounds");
        if(!PlayerPrefs.HasKey("PlayMusic")) SetPlayOrStopMusic(true);
        if(!PlayerPrefs.HasKey("PlaySounds")) SetPlayOrStopSounds(true);
    }

    public static void SetPlayOrStopMusic(bool _playBoolMusic)
    {
        if(_playBoolMusic) PlayerPrefs.SetString("PlayMusic", "true");
        else PlayerPrefs.SetString("PlayMusic", "false");
        _playMusic = _playBoolMusic;
    }

    public static bool GetPlayOrStopMusic()
    {
        if(PlayerPrefs.HasKey("PlayMusic")) return PlayerPrefs.GetString("PlayMusic") == "true" ? true : false;
        else
        {
            SetPlayOrStopMusic(true);
            return true;
        }
    }

    public static void SetPlayOrStopSounds(bool _playBoolSounds)
    {
        if(_playBoolSounds) PlayerPrefs.SetString("PlaySounds", "true");
        else PlayerPrefs.SetString("PlaySounds", "false");
        _playMusic = _playBoolSounds;
    }

    public static bool GetPlayOrStopSounds()
    {
        if(PlayerPrefs.HasKey("PlaySounds")) return PlayerPrefs.GetString("PlaySounds") == "true" ? true : false;
        else
        {
            SetPlayOrStopMusic(true);
            return true;
        }
    }
}