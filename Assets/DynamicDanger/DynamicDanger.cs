using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DynamicDanger : MonoBehaviour
{
    public float needToGo = 3f; // Затирмка в часі перед дією
    public float objectSpeed = 5f; // Швидкість ворога / об'єкта

    private Rigidbody rb; // Змінна для доступу до компоненту

    public float anglePerIteration = 90f; // Зміна кута за ітерацію

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") ||
            other.gameObject.CompareTag("Slime"))
        {
            SceneManager.LoadScene(1);
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Прив'язуємо Rigidbody до змінної "rb"
        StartCoroutine(RotateDynamicDanger());
    }
    private void Update()
    {
        Vector3 forward = transform.up;
        // Прискоює об'єкт у напрямку
        rb.velocity = forward * // Напрямок - вперед(forward)
                      objectSpeed * // Швидкість
                      Time.deltaTime; // Узгодження ігрового часу
    }
    private IEnumerator RotateDynamicDanger()
    {
        while (true)
        {
            yield return new WaitForSeconds(needToGo); // затримка у секундах

            // Змінна поточного кута 
            Vector3 currenEulerAngles = 
                transform.rotation.eulerAngles;
            // Додавання змін до координати z
            currenEulerAngles.y += anglePerIteration;
            // Встановлення нових координат обертання
            transform.rotation = Quaternion.Euler(currenEulerAngles);
        }
    }
}
