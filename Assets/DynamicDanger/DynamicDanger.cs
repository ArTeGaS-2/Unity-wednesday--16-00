using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDanger : MonoBehaviour
{
    public float needToGo = 3f; // Затирмка в часі перед дією
    public float objectSpeed = 5f; // Швидкість ворога / об'єкта

    private Rigidbody rb; // Змінна для доступу до компоненту

    private float currentAngleMod = 0f; // Поточний модифікатор напрямку
    public float anglePerIteration = 90f; // Зміна кута за ітерацію

    private void OnTriggerEnter(Collider other) // Перевіряє зіткнення
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject); // Знищує об'єкт з яким зіткнувся
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Прив'язуємо Rigidbody до змінної "rb"
        StartCoroutine(RotateDynamicDanger());
    }
    private void Update()
    {
        // Прискоює об'єкт у напрямку
        rb.velocity = Vector3.left * // Напрямок - вперед(forward)
                      objectSpeed * // Швидкість
                      Time.deltaTime; // Узгодження ігрового часу
    }
    private IEnumerator RotateDynamicDanger()
    {
        while (true)
        {
            yield return new WaitForSeconds(needToGo); // затримка у секундах
            // Зміна поточного кута
            
            Vector3 currenEulerAngles = transform.rotation.eulerAngles;

            currenEulerAngles.z += currentAngleMod;

            transform.rotation = Quaternion.Euler(currenEulerAngles);

            currentAngleMod += anglePerIteration; // Зміна значення модифікатора
        }
    }
}
