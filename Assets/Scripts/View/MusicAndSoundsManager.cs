using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MusicAndSoundsManager : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] public Transform _parentMusic;
    [SerializeField] public Transform _parentSounds;

    [Header("Scripts")]
    [SerializeField] public static MusicAndSoundsManager _instance;

    [Header("Sprites")]
    [SerializeField] public Sprite _trueSpriteButton;
    [SerializeField] public Sprite _falseSpriteButton;

    [Header("UI")]
    [SerializeField] public Image _buttonSounds;
    [SerializeField] public Image _buttonMusic;

    private void Start() 
    {
        _instance = this;
        PlaySound("BackgroundMusic");
        _buttonSounds.sprite = ViewModel.GetSpriteButton(_trueSpriteButton, _falseSpriteButton, SoundsModel.GetPlayOrStopSounds());
        _buttonMusic.sprite = ViewModel.GetSpriteButton(_trueSpriteButton, _falseSpriteButton, SoundsModel.GetPlayOrStopMusic());
    }

    public void PlaySound(string _nameSound, float _direction)
    {
        if(SoundsModel.GetPlayOrStopSounds())
        {
            foreach(GameObject i in SoundsModel._sounds)
            {
                if(i.gameObject.name == _nameSound)
                {
                    GameObject _newClick = Instantiate(i.gameObject, Vector2.zero, Quaternion.identity, _parentSounds);
                    Destroy(_newClick, _direction);
                }
            }
        } 
    }

    public void PlaySound(string _nameSound)
    {
        foreach (GameObject i in SoundsModel._music)
        {
            if (i.gameObject.name == _nameSound)
            {
                GameObject _newMusic = Instantiate(i.gameObject, Vector2.zero, Quaternion.identity, _parentMusic);
                if(SoundsModel.GetPlayOrStopMusic())  _newMusic.GetComponent<AudioSource>().Play();
                else _newMusic.GetComponent<AudioSource>().Pause();
            }
        }
    }

    public void PlaySoundClickOnButton()
    {
        PlaySound("Click", 0.5f);
    }

    public void SwitchSoundsPlayback()
    {
        SoundsModel.SetPlayOrStopSounds(!SoundsModel.GetPlayOrStopSounds());
        _buttonSounds.sprite = ViewModel.GetSpriteButton(_trueSpriteButton, _falseSpriteButton, SoundsModel.GetPlayOrStopSounds());
    }

    public void SwitchMusicPlayback()
    {
        SoundsModel.SetPlayOrStopMusic(!SoundsModel.GetPlayOrStopMusic());
        _buttonMusic.sprite = ViewModel.GetSpriteButton(_trueSpriteButton, _falseSpriteButton, SoundsModel.GetPlayOrStopMusic());
       if(SoundsModel.GetPlayOrStopMusic())
       {
        for(int i = 0; i < _parentMusic.childCount; i++)
        {
            _parentMusic.GetChild(i).GetComponent<AudioSource>().Play();
        }
       } 
       else
       {
        for(int i = 0; i < _parentMusic.childCount; i++)
        {
            _parentMusic.GetChild(i).GetComponent<AudioSource>().Pause();
        }
       }
    }
}