using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyRewardsModel : MonoBehaviour
{
    public static DailyRewardsModel instance;
    public List<int> rewards = new List<int>();
    public List<bool> claimRewadsBool;
    [SerializeField] public int maxDay = 7;
    [SerializeField] public int currentDay;

    private void Awake()
    {
        instance = this;
        maxDay = 7;
        claimRewadsBool = LoadBoolList();
        for (int i = 0; i < claimRewadsBool.Count; i++)
        {
            Debug.Log(claimRewadsBool[i]);
        }
        currentDay = PlayerPrefs.GetInt("currentDay");
    }

    public void SaveBoolList(List<bool> claimRewadsBool)  // сохранение списка
    {
        string boolString = string.Join(",", claimRewadsBool);
        PlayerPrefs.SetString("claimRewadsBool", boolString);
    }

    public List<bool> LoadBoolList() // загрузка сохраненного списка 
    {
        string boolString = PlayerPrefs.GetString("claimRewadsBool");

        if (boolString != "")
        {//Десериализация
            string[] boolArray = boolString.Split(",");
            List<bool> claimRewadsBool = new List<bool>();
            foreach (string boolValue in boolArray)
            {
                claimRewadsBool.Add(bool.Parse(boolValue));
            }
            return claimRewadsBool;
        }
        else
        {
            Debug.Log("return");
            return new List<bool>();
        }
    }
}
