using System;
using System.Collections;
using UnityEngine;
public class LuckWheelPresenter : MonoBehaviour
{
    public static LuckWheelPresenter instance;

    private bool spinning = false;
    private float anglePerItem;

    void Start() 
    {
        anglePerItem = LuckWheelModel.instance.GetAnglePerItem();
    }

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

    public void OnSpinButtonPressed() 
    {
        if (!spinning) 
        {
            spinning = true;
            LuckWheelView.instance.ShowSpinningStatus(true);

            float randomTime = UnityEngine.Random.Range(2, 5);
            int itemNumber = UnityEngine.Random.Range(0, LuckWheelModel.instance.prizeCount);

            float maxAngle = 360f * randomTime + itemNumber * anglePerItem;

            StartCoroutine(SpinTheWheel(5f * randomTime, maxAngle, itemNumber));
        }
    }

    IEnumerator SpinTheWheel(float time, float maxAngle, int itemNumber)
    {
        float timer = 0.0f;
        float startAngle = LuckWheelView.instance.transform.eulerAngles.z;

        maxAngle = maxAngle - startAngle;

        while (timer < time)
        {
            float angle = Mathf.Lerp(0, maxAngle, timer / time);
            LuckWheelView.instance.transform.eulerAngles = new Vector3(0.0f, 0.0f, angle + startAngle);

            // Обновляем позицию стрелки
            LuckWheelView.instance.SetArrowPosition(angle + startAngle);

            timer += Time.deltaTime;
            yield return null;
        }

        LuckWheelView.instance.transform.eulerAngles = new Vector3(0.0f, 0.0f, maxAngle + startAngle);
        LuckWheelView.instance.SetArrowPosition(maxAngle + startAngle);  // Обновляем стрелку после остановки

        LuckWheelView.instance.ShowSpinningStatus(false);

        spinning = false;

         // Вычисляем сектор, на который указывает стрелка
        int winningItem = Mathf.FloorToInt(((maxAngle + startAngle) % 360) / anglePerItem);

        // Получаем название цвета сектора
        string winningColorName = LuckWheelModel.instance.GetPrize(winningItem);

        // Выводим название цвета, на который указала стрелка
        Debug.Log("Выпал цвет: " + winningColorName);
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