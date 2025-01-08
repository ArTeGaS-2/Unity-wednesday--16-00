using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDanger : MonoBehaviour
{
    public float needToGo = 3f; // Затирмка в часі перед дією
    public float objectSpeed = 5f; // Швидкість ворога / об'єкта

    private Rigidbody rb; // Змінна для доступу до компоненту
    private void OnTriggerEnter(Collider other) // Перевіряє зіткнення
    {
        Destroy(other.gameObject); // Знищує об'єкт з яким зіткнувся
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Прив'язуємо Rigidbody до змінної "rb"
    }
    private void Update()
    {
        // Прискоює об'єкт у напрямку
        rb.velocity = Vector3.forward * // Напрямок - вперед(forward)
                      objectSpeed * // Швидкість
                      Time.deltaTime; // Узгодження ігрового часу
    }
}
