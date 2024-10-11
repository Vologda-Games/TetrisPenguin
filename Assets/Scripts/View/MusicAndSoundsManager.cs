using UnityEngine;

public class MusicAndSoundsManager : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] public Transform _parentMusic;
    [SerializeField] public Transform _parentSounds;

    [Header("Scripts")]
    [SerializeField] public static MusicAndSoundsManager _instance;

    private void Start() 
    {
        PlaySound(Vector2.zero, "BackgroundMusic");
        _instance = this;
    }

    public void PlaySound(Vector2 _pos, string _nameSound, float _direction)
    {
        if(SoundsModel.GetPlayOrStopSounds())
        {
            foreach(GameObject i in SoundsModel._sounds)
            {
                if(i.gameObject.name == _nameSound)
                {
                    GameObject _newClick = Instantiate(i.gameObject, _pos, Quaternion.identity, _parentSounds);
                    Destroy(_newClick, _direction);
                }
            }
        } 
    }

    public void PlaySound(Vector2 _pos, string _nameSound)
    {
        if (SoundsModel.GetPlayOrStopMusic())
        {
            foreach (GameObject i in SoundsModel._music)
            {
                if (i.gameObject.name == _nameSound) Instantiate(i.gameObject, _pos, Quaternion.identity, _parentMusic);
            }
        }
    }

    public void PlaySoundClickOnButton()
    {
        PlaySound(Vector2.zero, "Click", 0.5f);
    }
}