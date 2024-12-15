using UnityEngine;

public class SoundsModel : MonoBehaviour
{
    //Key for boolian playing music ---> PlayMusic in the !!!STRING!!!
    //Key for boolian playing sounds ---> PlaySounds in the !!!STRING!!!

    [Header("MusicAndSounds")]
    [SerializeField] public static GameObject[] music;
    [SerializeField] public static GameObject[] sounds;

    [Header("Boolian")]
    [HideInInspector] public bool playSounds;
    [HideInInspector] public bool playMusic;

    [Header("Scripts")]
    public static SoundsModel instance;

    private void Awake()
    {
        instance = this;
    }
}

public class SaveSoundsModel
{
    public bool playSounds;
    public bool playMusic;
}