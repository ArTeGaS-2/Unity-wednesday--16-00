using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDanger : MonoBehaviour
{
    public float needToGo = 3f; // Затирмка в часі перед дією
    public float enemySpeed = 5f; // Швидкість ворога / об'єкта
    
    private void Start()
    {
        StartCoroutine(rotateEnemy()); // Запускаємо метод обертання
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
    private IEnumerator rotateEnemy()
    {
        // Встановлює затримку перед виконанням наступного рядка коду
        yield return new WaitForSeconds(needToGo);
        // Обертаємо ворога на 90 градусів по осі "y".
        transform.rotation = Quaternion.Euler(
            transform.rotation.x, // x
            90,                   // y
            90);                  // z
    }
    
}
