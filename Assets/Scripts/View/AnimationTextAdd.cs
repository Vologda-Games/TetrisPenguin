using System.Collections;
using TMPro;
using UnityEngine;

public class AnimationTextAdd : MonoBehaviour
{
    [Header("UI")]

    [SerializeField] private TMP_Text _thisText;

    public void MoveDownAndLoad(int _valueExperience)
    {
        _thisText.text = $"+{_valueExperience}";
        StartCoroutine(MoveObject());
    }

    private IEnumerator MoveObject()
    {
        Vector3 _currentPosition = transform.position;
        while (transform.position.y > _currentPosition.y - .3f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y - .3f, 0f), 1f);
            if (transform.position.y <= _currentPosition.y - .06f) _thisText.color = Color.Lerp(_thisText.color, new Color(_thisText.color.r, _thisText.color.b, _thisText.color.g, 0f), .08f);
            yield return new WaitForSeconds(0.02f);
        }
        Destroy(gameObject);
    }
}