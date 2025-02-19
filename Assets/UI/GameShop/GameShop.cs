using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameShop : MonoBehaviour
{
    public GameObject gameShop;

    Renderer slimeRenderer; // Графічний компонент слайма
    private void Start()
    {
        slimeRenderer = Slime.Instance.gameObject.GetComponent<Renderer>();
    }
    public void SetColorRed()
    {
        slimeRenderer.material.color = Color.red; // Колір слайма - червоний
    }
    public void SetColorGreen()
    {
        slimeRenderer.material.color = Color.green; // Колір слайма - зелений
    }
    public void SetColorBlue()
    {
        slimeRenderer.material.color = Color.blue; // Колір слайма - синій
    }
    public void CloseShop()
    {
       gameShop.SetActive(false);
    }
}
