using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PenguinCardView : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text _textLevel;
    [SerializeField] private Image _imageSoftPenguin;

    public void OutputInformationPenguinCard(int levelPenguin)
    {
        _textLevel.text = $"{PenguinsModel.instance.penguinsCardsInformations[levelPenguin].levelPenguin + 1} уровень";
        if(PenguinsModel.instance.penguinsCardsInformations[levelPenguin].ready)
        {
            _imageSoftPenguin.sprite = PenguinsModel.instance.penguinsCardsInformations[levelPenguin].softSprite;
            Debug.Log(PenguinsModel.instance.penguinsCardsInformations[levelPenguin].softSprite.name);
        }
        else
        {
            _imageSoftPenguin.sprite = PenguinsModel.instance.penguinsCardsInformations[levelPenguin].unknownSprite;
            Debug.Log(PenguinsModel.instance.penguinsCardsInformations[levelPenguin].unknownSprite.name);
        }
    }
}