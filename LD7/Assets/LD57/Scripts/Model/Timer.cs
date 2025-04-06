using UnityEngine;

public class Timer
{
    private float currentTime = 0f;
    private bool isRunning = false;

    public void UpdateTimer()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime;
        }
    }

    // Запустить таймер
    public void StartTimer()
    {
        isRunning = true;
    }

    // Остановить таймер
    public void StopTimer()
    {
        isRunning = false;
    }

    // Сбросить таймер
    public void ResetTimer()
    {
        currentTime = 0f;
    }

    // Получить текущее время в секундах (целое число)
    public int GetCurrentTime()
    {
        return Mathf.FloorToInt(currentTime);
    }
}