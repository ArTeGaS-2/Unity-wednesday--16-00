using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public Camera mainCamera; // Посилання на камеру
    public float maxSpeed = 10f; // Максимальна швидкість
    public float forceTime = 1.0f; // Час дії інерції
    public float forceMultipier = 100f; // Множник для сили 

    private Rigidbody rb;

    public float animTime = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // Отримує позицію миші у світових координатах
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 targetPosition = hit.point;

            // Визначаємо напрямок від слимака до точки курсора
            Vector3 direction = (
                targetPosition - transform.position).normalized;
            direction.y = 0;

            // Повертаємо слайма у напрямку курсору
            if (direction.magnitude > 0.1f) // Щоб уникнути дрібного коливання
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(
                    transform.rotation, targetRotation, Time.deltaTime * 5f);
            }

            // Рухаємо персонажа у напрямку курсора
            if (Input.GetMouseButton(0))
            {
                rb.AddForce(direction * forceMultipier * Time.deltaTime,
                    ForceMode.Acceleration);
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

                // Старт анімації
                SlimeMoveAnim();
            }
            else
            {
                // Зупинка анімації
                SlimeStopAnim();
            }
        }
        // Камера слідкує за об'єктом гравця
        mainCamera.transform.position = new Vector3(
            transform.position.x,
            7,
            transform.position.z - 1f);
    }
    private void SlimeMoveAnim()
    {
        // Плавно змінюємо розмір слайма
        float forwardScale = Mathf.Lerp(
            transform.localScale.z,
            1.3f,
            Time.deltaTime / animTime);
        float sideScale = Mathf.Lerp(
            transform.localScale.z,
            0.8f,
            Time.deltaTime / animTime);
        // Застосовуємо зміни до localScale
        transform.localScale = new Vector3(
            sideScale,
            transform.localScale.y,
            forwardScale);
    }
    private void SlimeStopAnim()
    {
        // Плавно змінюємо розмір слайма
        float forwardScale = Mathf.Lerp(
            transform.localScale.z,
            1f,
            Time.deltaTime / animTime);
        float sideScale = Mathf.Lerp(
            transform.localScale.z,
            1f,
            Time.deltaTime / animTime);
        // Застосовуємо зміни до localScale
        transform.localScale = new Vector3(
            sideScale,
            transform.localScale.y,
            forwardScale);
    }
}
