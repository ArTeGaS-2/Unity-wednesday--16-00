using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuObject; // ³��� �����
    public void OpenPauseMenu()
    {
        pauseMenuObject.SetActive(true); // ��������� ���� �����
        Time.timeScale = 0.0f; // ������� ���� � ��
    }
    public void ClosePauseMenu()
    {
        pauseMenuObject.SetActive(false); // �����������
        Time.timeScale = 1.0f; // ���������� ����
    }
}
