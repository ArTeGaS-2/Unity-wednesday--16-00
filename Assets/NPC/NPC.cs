using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject gameShop; // Посилання на об'єкт магазину

    private void Start()
    {
        gameShop = GetComponent<GameObject>();
    }
    private void OnMouseOver() // Чи знаходиться мишка на об'єкті
    {
        // Перевіряє натискання правої кнопки миші
        if (Input.GetMouseButtonDown(1))
        {
            gameShop.SetActive(true);
        }
    }
}
