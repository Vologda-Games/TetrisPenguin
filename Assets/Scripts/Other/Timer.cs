using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(Saving());
    }

    public void DeleteAllData()
    {
        DataPresenter.DeleteAllData();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator Saving()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            DataPresenter.SaveAllData();
        }
    }
}