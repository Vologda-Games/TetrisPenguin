using UnityEngine;

public class ViewModel : MonoBehaviour
{
    public static ViewModel instance;

    [SerializeField] public GameObject _shop;
    [SerializeField] public GameObject _dailyTasks;
    [SerializeField] public GameObject _wheelOfLuck;
    [SerializeField] public GameObject _ratings;

    private void Awake()
    {
        instance = this;
    }

    public static Sprite GetSpriteButton(Sprite _trueSprite, Sprite _falseSprite, bool _conditionButton)
    {
        return _conditionButton ? _trueSprite : _falseSprite;
    }
}