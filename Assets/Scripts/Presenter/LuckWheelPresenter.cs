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
            rotationSpeed = LuckWheelModel.instance.rotationSpeed;
            accelerationTime = LuckWheelModel.instance.accelerationTime;
            rotationTimeMaxSpeed = LuckWheelModel.instance.rotationTimeMaxSpeed;
            prizes = LuckWheelModel.instance.prizes;
            numberOfSpins = LuckWheelModel.instance.numberOfSpins;
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
            case 0: // 100 монет
                AddToken(100);
                break;
            case 1: // боксерских перчатки
                AddBoks(2);
                break; 
            case 2: // торнадо
                AddTornadoes(2);
                break;
            case 3: // 200 монет
                AddToken(200);
                break;
            case 4: // яйцо
                AddEggs(2);
                break;
            case 5: // магнит
                AddMagnet(2);
                break;
            case 6: // 300 монет
                AddToken(300);
                break;
            case 7: // бомба
                AddBombs(2);
                break;
            default:
                break;
        }
    }
    
    public static int GetTokens()
    {
        return LuckWheelModel.instance.token;
    }

    private static void AddBoks(int value)
    {
        BafsModel.instance.springBafs += value;
        BafsView.instance.RenderCountBafs();
    }

    private static void AddTornadoes(int value) 
    {
        BafsModel.instance.tornadoBafs += value;
        BafsView.instance.RenderCountBafs();
    }

    private static void AddEggs(int value) 
    {
        BafsModel.instance.multicolorBafs += value;
        BafsView.instance.RenderCountBafs();
    }

    private static void AddMagnet(int value) 
    {
        BafsModel.instance.magnetBafs += value;
        BafsView.instance.RenderCountBafs();
    }

    private static void AddBombs(int value)
    {
        BafsModel.instance.bombBafs += value;
        BafsView.instance.RenderCountBafs();
    }

    public static void AddToken(int value)
    {
        LuckWheelModel.instance.token += value;
        PlayerModel.instance.coins += value;
        PlayerView.instance.RenderCoin();
        ShopView.instance.RenderCoins();
    }
}