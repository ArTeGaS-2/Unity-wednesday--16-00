using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Чи знаходиться мишка на об'єкті
    private void OnMouseOver()
    {
        // Перевіряє натискання правої кнопки миші
        if (Input.GetMouseButtonDown(1))
        {
            // Пише в консоль підтвердження кліку
            Debug.Log("Клік працює");
        }
    }
}
