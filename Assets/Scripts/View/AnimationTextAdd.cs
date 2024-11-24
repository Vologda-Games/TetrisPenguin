using System.Collections;
using TMPro;
using UnityEngine;

public class AnimationTextAdd : MonoBehaviour
{
    [Header("UI")]

    [SerializeField] private TMP_Text _thisText;
    [SerializeField] private Color _colorAddCoins;
    [SerializeField] private Color _colorReduceCoins;

    public void MoveDownAndLoad(int _valueCurrency)
    {
        if (_valueCurrency > 0)
        {
            _thisText.color = _colorAddCoins;
            _thisText.text = $"+{_valueCurrency}";
        }
        else
        {
            _thisText.color = _colorReduceCoins;
            _thisText.text = $"{_valueCurrency}";
        }
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