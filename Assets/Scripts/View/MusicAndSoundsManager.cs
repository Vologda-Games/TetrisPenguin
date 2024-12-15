using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicAndSoundsManager : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] public Transform parentMusic, parentSounds;

    [Header("Scripts")]
    [SerializeField] public static MusicAndSoundsManager instance;

    [Header("Sprites")]
    [SerializeField] public Sprite _trueSpriteButtonMusic;
    [SerializeField] public Sprite _falseSpriteButtonMusic;

    [SerializeField] public Sprite _trueSpriteButtonSounds;
    [SerializeField] public Sprite _falseSpriteButtonSounds;

    [Header("UI")]
    [SerializeField] public Image _buttonSounds;
    [SerializeField] public Image _buttonMusic;

    [Header("Audio")]

    private List<AudioSource> _audioSourcesMusic = new List<AudioSource>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PlaySound("BackgroundMusic");
        _buttonSounds.sprite = ViewModel.GetSpriteButton(_trueSpriteButtonSounds, _falseSpriteButtonSounds, SoundsModel.instance.playSounds);
        _buttonMusic.sprite = ViewModel.GetSpriteButton(_trueSpriteButtonMusic, _falseSpriteButtonMusic, SoundsModel.instance.playMusic);
    }

    public void PlaySound(string _nameSound, float _direction)
    {
        if (SoundsModel.instance.playSounds)
        {
            foreach (GameObject i in SoundsModel.sounds)
            {
                if (i.gameObject.name == _nameSound)
                {
                    GameObject _newClick = Instantiate(i.gameObject, Vector2.zero, Quaternion.identity, parentSounds);
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
                GameObject _newMusic = Instantiate(i.gameObject, Vector2.zero, Quaternion.identity, parentMusic);
                AudioSource _newSource = _newMusic.GetComponent<AudioSource>();
                _audioSourcesMusic.Add(_newSource);
                if (SoundsModel.instance.playMusic) _newSource.Play();
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
        SoundsModel.instance.playSounds = !SoundsModel.instance.playSounds;
        _buttonSounds.sprite = ViewModel.GetSpriteButton(_trueSpriteButtonSounds, _falseSpriteButtonSounds, SoundsModel.instance.playSounds);
        DataPresenter.SaveSoundsModel();
    }

    public void SwitchMusicPlayback()
    {
        ChangeMusicCondition();
        _buttonMusic.sprite = ViewModel.GetSpriteButton(_trueSpriteButtonMusic, _falseSpriteButtonMusic, SoundsModel.instance.playMusic);
        DataPresenter.SaveSoundsModel();
    }

    public void ChangeMusicCondition()
    {
        SoundsModel.instance.playMusic = !SoundsModel.instance.playMusic;
        if (SoundsModel.instance.playMusic)
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
    }
}