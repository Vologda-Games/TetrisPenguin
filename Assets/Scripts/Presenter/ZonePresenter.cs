using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ZonePresenter : MonoBehaviour
{
    [SerializeField] private Image _zone;
    private float _time = 0;

    private void OnTriggerStay2D(Collider2D other)
    {
        _time += Time.fixedDeltaTime;
        if (_zone.color.a < .7f && _time > 0.5f) _zone.color += new Color(0, 0, 0, Time.fixedDeltaTime / 3.8f);
        if (_time > 3)
        {
            DataPresenter.DeleteDataPenguins();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _time = 0;
        _zone.color = new Color(_zone.color.r, _zone.color.g, _zone.color.b, 0f);
    }
}