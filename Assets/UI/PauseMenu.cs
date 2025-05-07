using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuObject; // Вікно паузи
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
}
