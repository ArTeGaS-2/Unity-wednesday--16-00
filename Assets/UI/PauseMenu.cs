using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance; // ���� ��������� ���� �� ���
    public GameObject pauseMenuObject; // ³��� �����
    private void Awake()
    {
        instance = this; // ����'����� ������� ���� �� �����
        pauseMenuObject.SetActive(false); // �������� ���� �� �������
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) // ���� ��������� ESC
            && pauseMenuObject.activeSelf == false) // �� ���� �� �������
        {
            OpenPauseMenu(); // ³�������� ���� �����
        }
        else if (Input.GetKeyDown(KeyCode.Escape) // ���� ��������� ESC
            && pauseMenuObject.activeSelf == true) // �� ���� �������
        {
            ClosePauseMenu(); // ��������� ���� �����
        }
    }
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
    public void BackToMainMenu()
    {
        Time.timeScale = 1.0f; // ��������� ���
        SceneManager.LoadScene(0); // ����������� ���� (1 � ������ ���� �� ����)
    }
}
