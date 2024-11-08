using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class LuckWheelPresenter : MonoBehaviour
{
    public static LuckWheelPresenter instance;

    private bool isSpin = false;
    private GameObject wheel;
    private float rotationSpeed; //скорость вращения
    private float slowDownTime; //время вращения
    private float accelerationTime;
    private float rotationTimeMaxSpeed;
    private int numberOfSpins;

    private float maxAngel = 0f;
    private float minAngel = 0f;

    private int randomSectors;

    private List<string> prizes;

     void Awake()
    {
        // Инициализация instance, если его нет
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);  // Убедитесь, что существует только один экземпляр
        }
    }

    public void Initialization() 
    {
        // Проверяем наличие экземпляра LuckWheelView перед обращением
        if (LuckWheelView.instance != null)
        {
            if (LuckWheelView.instance.wheel != null) 
            {
                wheel = LuckWheelView.instance.wheel;
            }
            rotationSpeed = LuckWheelView.instance.rotationSpeed;
            accelerationTime = LuckWheelView.instance.accelerationTime;
            rotationTimeMaxSpeed = LuckWheelView.instance.rotationTimeMaxSpeed;
            prizes = LuckWheelModel.instance.prizes;
            numberOfSpins = LuckWheelView.instance.numberOfSpins;
        }
        else
        {
            Debug.LogError("LuckWheelView instance is not set.");
        }
    }

    public void OnClickButton() 
    {
        StartCoroutine(SpinWheel());
    }

    IEnumerator SpinWheel() 
    {
        if (wheel == null)
        {
            yield break; // Завершаем корутину, если объект уже уничтожен
        }

        setWin();
        isSpin = true;
        LuckWheelView.instance.ShowSpinningStatus(isSpin);
        float elapsedTime = 0f; // отвечает за прошедшее время
        float rotSpeed; // текущая скорость вращения

        while (elapsedTime < accelerationTime)
        {
            if (wheel == null)
            {
                yield break; // Завершаем корутину, если объект уничтожен в процессе
            }

            rotSpeed = Mathf.Lerp(0, rotationSpeed, elapsedTime / accelerationTime);
            
            wheel.transform.rotation *= Quaternion.Euler(0, 0, rotSpeed * Time.deltaTime);
            
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elapsedTime = 0f;

        while (elapsedTime < rotationTimeMaxSpeed)
        {
            if (wheel == null)
            {
                yield break; // Завершаем корутину, если объект уничтожен в процессе
            }
            wheel.transform.rotation *= Quaternion.Euler(0, 0, rotationSpeed * Time.deltaTime);
            
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        float distance = (numberOfSpins * 360f) + UnityEngine.Random.Range(minAngel+5, maxAngel-5) - LuckWheelView.instance.wheel.transform.rotation.eulerAngles.z;
        slowDownTime = (2 * distance) / rotationSpeed;
        float slowDown = rotationSpeed / slowDownTime;
        rotSpeed = rotationSpeed;

        elapsedTime = 0f;

        while (elapsedTime < slowDownTime)
        {
            if (wheel == null)
            {
                yield break; // Завершаем корутину, если объект уничтожен в процессе
            }
            rotSpeed = Mathf.Lerp(rotationSpeed, 0, elapsedTime / slowDownTime);
            wheel.transform.rotation *= Quaternion.Euler(0, 0, rotSpeed * Time.deltaTime);
            
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isSpin = false;
        LuckWheelView.instance.ShowSpinningStatus(isSpin);
        GetPrize();
    }

    public void setWin()
    {
        int randomSector = UnityEngine.Random.Range(0, prizes.Count);
        Debug.Log("WIN " + prizes[randomSector] + "/ index = " + randomSector);
        randomSectors = randomSector;
        maxAngel = 360f / prizes.Count * (randomSector + 1);
        minAngel = 360f / prizes.Count * randomSector;
    }

    void OnDestroy()
    {
        StopAllCoroutines(); // Останавливаем все корутины при уничтожении объекта
    }

    public void GetPrize() 
    {
        Debug.Log("Поздровляю вам выпал: " + prizes[randomSectors]);
        switch (randomSectors) 
        {
            case 0:
                Debug.Log("Выдан: " + randomSectors);
                break;
            case 1:
                Debug.Log("Выдан: " + randomSectors);
                break;
            case 2:
                Debug.Log("Выдан: " + randomSectors);
                break;
            case 3:
                Debug.Log("Выдан: " + randomSectors);
                break;
            case 4:
                Debug.Log("Выдан: " + randomSectors);
                break;
            case 5:
                Debug.Log("Выдан: " + randomSectors);
                break;
            case 6:
                Debug.Log("Выдан: " + randomSectors);
                break;
            case 7:
                Debug.Log("Выдан: " + randomSectors);
                break;
            default:
                Debug.Log("Приз не найден");
                break;
        }
    }
    
    public static int GetTokens()
    {
        return LuckWheelModel.instance.token;
    }

    public static void AddToken(int value)
    {
        LuckWheelModel.instance.token += value;
    }
}