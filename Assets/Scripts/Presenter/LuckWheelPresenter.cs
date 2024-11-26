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

    private List<int> prizes;

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
        StartCoroutine(ScaleButton());
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
        // PlayerPrefs.SetInt("isUpScale", 0);
        // PlayerPrefs.SetInt("WheelSpunToday", 1);
        LuckWheelModel.instance.isUpScale = 0;
        LuckWheelModel.instance.wheelSpunToday = 1;
        ShowBtnMoney();
    }

    public void setWin()
    {
        int randomSector = UnityEngine.Random.Range(0, prizes.Count);
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
        switch (randomSectors) 
        {
            case 0: // 100 монет
                //AddToken(300);
                PlayerPresenter.instance.AddCoin(300);
                break;
            case 1: // боксерских перчатки
                AddBoks(2);
                break; 
            case 2: // торнадо
                AddTornadoes(2);
                break;
            case 3: // 200 монет
                //AddToken(550);
                PlayerPresenter.instance.AddCoin(550);
                break;
            case 4: // яйцо
                AddEggs(2);
                break;
            case 5: // магнит
                AddMagnet(2);
                break;
            case 6: // 300 монет
                //AddToken(900);
                PlayerPresenter.instance.AddCoin(900);
                break;
            case 7: // бомба
                AddBombs(2);
                break;
            default:
                break;
        }
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

    public static void ClickOnButtonForMoney(int value) 
    {
            PlayerPresenter.instance.ReduceCoin(value);
            //PlayerPrefs.SetInt("WheelSpunToday", 0);
            LuckWheelModel.instance.wheelSpunToday = 0;
            //if (PlayerPrefs.GetInt("WheelSpunToday") == 0) 
            if (LuckWheelModel.instance.wheelSpunToday == 0)
            {
                Debug.Log("WheelSpunToday= "+ 0);
            }
    }


    public static void AddToken(int value)
    {
        PlayerModel.instance.coins += value;
        PlayerView.instance.RenderCoin();
    }

    public void OnClickBtnMoney() 
    {
        if (PlayerModel.instance.coins >= 750) 
        {
            StartCoroutine(DownScale());
        }
    }

    IEnumerator DownScale() 
    {
        float time = 0f;
        float duration = 0.2f;
        Vector3 currentScale = LuckWheelView.instance.btnForMoney.localScale;
        Vector3 targetScale = Vector3.zero;
        
        while(time < duration) 
        {
            time += Time.deltaTime;
            float progress = time/duration;
            LuckWheelView.instance.btnForMoney.localScale = Vector3.Lerp(currentScale, targetScale, progress);
            yield return null;
        }
        LuckWheelView.instance.request_For_Money.SetActive(false);
        ClickOnButtonForMoney(750);
    }

    public void ShowBtnMoney() 
    {
        LuckWheelView.instance.request_For_Money.SetActive(true);
        //if (PlayerPrefs.GetInt("isUpScale") == 1) 
        if (LuckWheelModel.instance.isUpScale == 1)
        {
            StartCoroutine(UpAndDownRotation());
        }
        else 
        {
            StartCoroutine(UpScale());
        }
        //PlayerPrefs.SetInt("isUpScale", 1);
        LuckWheelModel.instance.isUpScale = 1;
    }

    IEnumerator UpScale() 
    {
        if (wheel == null)
            {
                yield break; // Завершаем корутину, если объект уже уничтожен
            }
        float time = 0f;
        float duration = 0.2f;
        Vector3 initialScale = Vector3.zero;
        Vector3 targetScale = new Vector3(1f,1f,1f);
        
        while(time < duration) 
        {
            if (wheel == null)
            {
                yield break; // Завершаем корутину, если объект уже уничтожен
            }
            time += Time.deltaTime;
            float progress = time/duration;
            LuckWheelView.instance.btnForMoney.localScale = Vector3.Lerp(initialScale, targetScale, progress);
            yield return null;
        }
        LuckWheelView.instance.btnForMoney.localScale = targetScale;
    }

    IEnumerator UpAndDownRotation() 
    {
        if (wheel == null)
        {
            yield break; // Завершаем корутину, если объект уже уничтожен
        }

        LuckWheelView.instance.AnimationRotation(true); // возращает true к view
        float time = 0f;
        float duration = 0.2f;
        Vector3 initialScale = Vector3.zero;
        Vector3 targetScale = new Vector3(0f, 0f, 4f);
        
        while(time < duration) 
        {
            if (wheel == null)
            {
                yield break; // Завершаем корутину, если объект уже уничтожен
            }

            time += Time.deltaTime;
            float progress = time/duration;
            LuckWheelView.instance.btnForMoney.eulerAngles = Vector3.Lerp(initialScale, targetScale, progress);
            yield return null;
        }
        initialScale = targetScale;
        targetScale = new Vector3(0f, 0f, -4f);
        duration = 0.4f;
        time = 0f;
        while(time < duration) 
        {
            if (wheel == null)
            {
                yield break; // Завершаем корутину, если объект уже уничтожен
            }
            time += Time.deltaTime;
            float progress = time/duration;
            LuckWheelView.instance.btnForMoney.eulerAngles = Vector3.Lerp(initialScale, targetScale, progress);
            yield return null;
        }
        initialScale = targetScale;
        targetScale = new Vector3(0f, 0f, 3f);
        duration = 0.4f;
        time = 0f;
        
        while(time < duration) 
        {
            if (wheel == null)
            {
                yield break; // Завершаем корутину, если объект уже уничтожен
            }
            time += Time.deltaTime;
            float progress = time/duration;
            LuckWheelView.instance.btnForMoney.eulerAngles = Vector3.Lerp(initialScale, targetScale, progress);
            yield return null;
        }
        initialScale = targetScale;
        targetScale = new Vector3(0f, 0f, 0f);
        duration = 0.2f;
        time = 0f;
        while(time < duration) 
        {
            if (wheel == null)
            {
                yield break; // Завершаем корутину, если объект уже уничтожен
            }
            time += Time.deltaTime;
            float progress = time/duration;
            LuckWheelView.instance.btnForMoney.eulerAngles = Vector3.Lerp(initialScale, targetScale, progress);
            yield return null;
        }
        LuckWheelView.instance.AnimationRotation(false);
    }

    IEnumerator ScaleButton() 
    {
        float time = 0;
        float duration = 0.2f;

        Vector3 currentScale = LuckWheelView.instance.spinButton.localScale;
        Vector3 futureScale = new Vector3(0.8f,0.8f,0.8f);

        while(time < duration) 
        {
            time += Time.deltaTime;
            float progress = time/duration;
            LuckWheelView.instance.spinButton.localScale = Vector3.Lerp(currentScale, futureScale, progress);
            yield return null;

        }
        LuckWheelView.instance.spinButton.localScale = futureScale;

        time = 0;
        
        while(time < duration) 
        {
            time += Time.deltaTime;
            float progress = time/duration;
            LuckWheelView.instance.spinButton.localScale = Vector3.Lerp(futureScale, currentScale, progress);
            yield return null;
        }
        LuckWheelView.instance.spinButton.localScale = currentScale;
    }
}