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

    // ��������� ������
    public void StartTimer()
    {
        isRunning = true;
    }

    // ���������� ������
    public void StopTimer()
    {
        isRunning = false;
    }

    // �������� ������
    public void ResetTimer()
    {
        currentTime = 0f;
    }

    // �������� ������� ����� � �������� (����� �����)
    public int GetCurrentTime()
    {
        return Mathf.FloorToInt(currentTime);
    }
}