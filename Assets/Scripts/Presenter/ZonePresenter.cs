using UnityEngine;
using UnityEngine.SceneManagement;

public class ZonePresenter : MonoBehaviour
{
    float time = 0;
    

    private void OnTriggerStay2D(Collider2D other)
    {
        time += Time.deltaTime;
        if (time > 3)
        {
            DataPresenter.DeleteAllData();
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        time = 0;
    }
}