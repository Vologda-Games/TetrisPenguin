using UnityEngine;
using UnityEngine.UI;

public class LeveManagerView : MonoBehaviour
{
    [Header("Transform")]

    [SerializeField] private Transform _parentButtonBafs;

    [Header("UI")]
    [SerializeField] private Button _buttonDailyTasks;
    [SerializeField] private Button _buttonShop;
    [SerializeField] private Button _buttonLuckWheel;

    private void Start() 
    {
        for(int i = 0; i < _parentButtonBafs.childCount; i++)
        {
            _parentButtonBafs.GetChild(i).name = $"Baff{_parentButtonBafs.GetChild(i).GetSiblingIndex()}";
        }
    }
}