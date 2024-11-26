using UnityEngine;

public class SpawnOfPenguinCardsView : MonoBehaviour
{
    [Header("Transforms")]
    [SerializeField] private Transform _parentForPenguinsCards;

    [Header("Objects")]
    [SerializeField] private GameObject _penguinCard;

    private void Start()
    {
        SpawnOfPenguinCards();
    }

    private void SpawnOfPenguinCards()
    {
        for(int i = 0; i < PenguinsModel.instance.penguinsCardsInformations.Count; i++)
        {
            GameObject _newPenguinCard = Instantiate(_penguinCard, _parentForPenguinsCards);
            _newPenguinCard.GetComponent<PenguinCardView>().OutputInformationPenguinCard(i);
        }
    }
}