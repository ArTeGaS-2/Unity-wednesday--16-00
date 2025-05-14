using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance; // Один екземпляр вікна на гру
    public GameObject pauseMenuObject; // Вікно паузи
    private void Awake()
    {
        instance = this; // Прив'язуємо існуюче вікно до змінної
        pauseMenuObject.SetActive(false); // Вимикаємо вікно на початку
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Якщо натиснуто ESC
        {
            OpenPauseMenu(); // Відкриваємо меню паузи
        }
    }
    public void OpenPauseMenu()
    {
        pauseMenuObject.SetActive(true); // Активація меню паузи
        Time.timeScale = 0.0f; // Зупинка часу у грі
    }
    public void ClosePauseMenu()
    {
        pauseMenuObject.SetActive(false); // Декативація
        Time.timeScale = 1.0f; // Поновлення часу
    }
    public void BackToMainMenu()
    {
        Time.timeScale = 1.0f; // Повертаємо час
        SceneManager.LoadScene(0); // Завантажуємо меню (1 в дужках якщо не меню)
    }
}
