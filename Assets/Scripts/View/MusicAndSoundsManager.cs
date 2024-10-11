using UnityEngine;

public class MusicAndSoundsManager : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] public Transform _parentMusic;
    [SerializeField] public Transform _parentSounds;

    private void Start() 
    {
        PlaySound(Vector2.zero, "BackgroundMusic", "Music");
    }

    public void PlaySound(Vector2 _pos, string _nameSound, string _typeValue)
    {
        if(_typeValue == "Sounds")
        {
           if(SoundsModel.GetPlayOrStopSounds())
            {
                foreach(GameObject i in SoundsModel._sounds)
                {
                    if(i.gameObject.name == _nameSound)
                    {
                        GameObject _newClick = Instantiate(i.gameObject, _pos, Quaternion.identity, _parentSounds);
                        Destroy(_newClick, 0.5f);
                    }
                }
            } 
        } else if(_typeValue == "Music")
        {
           if(SoundsModel.GetPlayOrStopMusic())
            {
                foreach(GameObject i in SoundsModel._music)
                {
                    if(i.gameObject.name == _nameSound) Instantiate(i.gameObject, _pos, Quaternion.identity, _parentMusic);
                }
            } 
        }
        
    }

    public void PlaySoundClickOnButton()
    {
        PlaySound(Vector2.zero, "Click", "Sounds");
    }
}