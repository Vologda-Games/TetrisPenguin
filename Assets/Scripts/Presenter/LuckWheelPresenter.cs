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

            // Случайное время вращения от 2 до 3 секунд
            float randomTime = UnityEngine.Random.Range(0.1f, 0.2f);

            // Максимальный угол для вращения, рассчитанный на основе времени
            float maxAngle = 360f * randomTime;

            // Запуск корутины для вращения колеса
            StartCoroutine(SpinTheWheel(randomTime, maxAngle));
        }
    }

    IEnumerator SpinTheWheel(float time, float maxAngle)
    {
        float timer = 0.0f;
        float startAngle = LuckWheelView.instance.transform.eulerAngles.z;
        maxAngle = maxAngle - startAngle;

        float initialSpeed = 720f;  // Начальная скорость вращения

        while (timer < time)
        {
            float speedFactor = Mathf.Lerp(1f, 0f, timer / time);
            float currentRotationSpeed = initialSpeed * speedFactor;

            // Обновляем текущий угол вращения
            startAngle += currentRotationSpeed * Time.deltaTime;
            startAngle %= 360;  // Ограничиваем угол в пределах 0-360 градусов

            LuckWheelView.instance.transform.eulerAngles = new Vector3(0.0f, 0.0f, startAngle);
            LuckWheelView.instance.SetArrowPosition(startAngle);

            timer += Time.deltaTime;
            yield return null;
        }

        // Устанавливаем финальный угол после остановки
        float finalAngle = startAngle % 360f;
        LuckWheelView.instance.transform.eulerAngles = new Vector3(0.0f, 0.0f, finalAngle);
        LuckWheelView.instance.SetArrowPosition(finalAngle);

        LuckWheelView.instance.ShowSpinningStatus(false);
        spinning = false;

        // Находим сектор по финальному углу
        float anglePerItem = 360f / LuckWheelView.instance.sectors.Length;

        // Вместо корректировки угла, просто делим на угол сектора
        int winningItem = Mathf.FloorToInt(finalAngle / anglePerItem);

        // Убедимся, что индекс находится в пределах допустимого диапазона
        if (winningItem >= LuckWheelView.instance.sectors.Length)
        {
            winningItem = 0;
        }

        // Получаем приз по найденному сектору
        string winningPrize = LuckWheelModel.instance.GetPrize(winningItem);
        Debug.Log("Выпал приз: " + winningPrize);

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