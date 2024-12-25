using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDanger : MonoBehaviour
{
    public float needToGo = 3f; // Затирмка в часі перед дією
    public float enemySpeed = 5f; // Швидкість ворога / об'єкта

    private float currentAngleY = 90f; // Обертання по Y
    private float currentAngleZ = 90f; // Обертання по Z
    
    private void Start()
    {
        StartCoroutine(RotateEnemy()); // Запускаємо метод обертання
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
    private IEnumerator RotateEnemy()
    {
        while (true)
        {
            // Встановлює затримку перед виконанням наступного рядка коду
            yield return new WaitForSeconds(needToGo);
            // Обертаємо ворога на 90 градусів по осі "y".
            transform.rotation = Quaternion.Euler(
                transform.rotation.x, // x
                currentAngleY,        // y
                currentAngleZ); // z

            currentAngleY += 90;
        }
    }
    private void Update()
    {
        transform.position = new Vector3(
            transform.position.x + enemySpeed * Time.deltaTime,
            transform.position.y ,
            transform.position.z);
    }
}
