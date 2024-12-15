using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ZonePresenter : MonoBehaviour
{
    [SerializeField] private Image _zone;
    private int _time = 0;
    private List<GameObject> _enterPenguinView = new List<GameObject>();
    private bool _timerActive = false;
    private bool _zoneActivation = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Penguin"))
        {
            _enterPenguinView.Add(collision.gameObject);
            if (!_timerActive) StartCoroutine(TimerOnZone());
            if (!_zoneActivation) StartCoroutine(ActivationZone());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Penguin")) _enterPenguinView.Remove(other.gameObject);
        if (_enterPenguinView.Count == 0) _time = 0;
    }

    private IEnumerator TimerOnZone()
    {
        _timerActive = true;
        _time = 0;
        yield return new WaitForSeconds(1f);
        while (_enterPenguinView.Count > 0)
        {
            _time += 1;
            if (_time >= 3)
            {
                DataPresenter.DeleteDataPenguins();
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            yield return new WaitForSeconds(1f);
        }
        _timerActive = false;
    }

    private IEnumerator ActivationZone()
    {
        _zoneActivation = true;
        while (_enterPenguinView.Count > 0)
        {
            if (_time >= 2f &&  _zone.color.a < .8f) _zone.color += new Color(0, 0, 0, 0.09f);
            yield return new WaitForSeconds(0.1f);
        }
        _zone.color = new Color(_zone.color.r, _zone.color.g, _zone.color.b, 0f);
        _zoneActivation = false;
    }
}