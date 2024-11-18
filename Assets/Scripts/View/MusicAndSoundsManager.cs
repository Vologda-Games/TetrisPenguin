using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicAndSoundsManager : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] public Transform _parentMusic, _parentSounds;

    [Header("Scripts")]
    [SerializeField] public static MusicAndSoundsManager _instance;

    [Header("Sprites")]
    [SerializeField] public Sprite _trueSpriteButton;
    [SerializeField] public Sprite _falseSpriteButton;

    [Header("UI")]
    [SerializeField] public Image _buttonSounds;
    [SerializeField] public Image _buttonMusic;

    [Header("Audio")]

    private List<AudioSource> _audioSourcesMusic = new List<AudioSource>();

    private void Start()
    {
        _instance = this;
        PlaySound("BackgroundMusic");
        _buttonSounds.sprite = ViewModel.GetSpriteButton(_trueSpriteButton, _falseSpriteButton, SoundsModel.instance._playSouds);
        _buttonMusic.sprite = ViewModel.GetSpriteButton(_trueSpriteButton, _falseSpriteButton, SoundsModel.instance._playMusic);
    }

    public void PlaySound(string _nameSound, float _direction)
    {
        if (SoundsModel.instance._playSouds)
        {
            foreach (GameObject i in SoundsModel.sounds)
            {
                if (i.gameObject.name == _nameSound)
                {
                    GameObject _newClick = Instantiate(i.gameObject, Vector2.zero, Quaternion.identity, _parentSounds);
                    Destroy(_newClick, _direction);
                }
            }
        }
    }

    public void PlaySound(string _nameSound)
    {
        foreach (GameObject i in SoundsModel.music)
        {
            if (i.gameObject.name == _nameSound)
            {
                GameObject _newMusic = Instantiate(i.gameObject, Vector2.zero, Quaternion.identity, _parentMusic);
                AudioSource _newSource = _newMusic.GetComponent<AudioSource>();
                _audioSourcesMusic.Add(_newSource);
                print(_newSource);
                if (SoundsModel.instance._playMusic) _newSource.Play();
                else _newSource.Pause();
            }
        }
    }

    public void PlaySoundClickOnButton()
    {
        PlaySound("Click", 0.5f);
    }

    public void SwitchSoundsPlayback()
    {
        SoundsModel.instance._playSouds = !SoundsModel.instance._playSouds;
        _buttonSounds.sprite = ViewModel.GetSpriteButton(_trueSpriteButton, _falseSpriteButton, SoundsModel.instance._playSouds);
        DataPresenter.SaveSoundsModel();
    }

    public void SwitchMusicPlayback()
    {
        SoundsModel.instance._playMusic = !SoundsModel.instance._playMusic;
        _buttonMusic.sprite = ViewModel.GetSpriteButton(_trueSpriteButton, _falseSpriteButton, SoundsModel.instance._playMusic);
        if (SoundsModel.instance._playMusic)
        {
            for (int i = 0; i < _audioSourcesMusic.Count; i++)
            {
                if (_audioSourcesMusic[i] != null) _audioSourcesMusic[i].Play();
            }
        }
        else
        {
            for (int i = 0; i < _audioSourcesMusic.Count; i++)
            {
                if (_audioSourcesMusic[i] != null) _audioSourcesMusic[i].Pause();
            }
        }
        DataPresenter.SaveSoundsModel();
    }
}