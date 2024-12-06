using TMPro;
using UnityEngine;

public class WindowWithInformationLevelView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textEXP;

    private void Start()
    {
        LevelPresenter.updateEXPEvent += OutputInformationWithLevelEXP;
    }

    public void OutputInformationWithLevelEXP()
    {
        _textEXP.text = $"{PlayerModel.instance.experience} / {Levels.levels[PlayerModel.instance.level].experience}";
        _textEXP.font = FontsModel.GetFont();
    }
}