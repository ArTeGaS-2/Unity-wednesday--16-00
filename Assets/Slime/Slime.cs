using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public Camera mainCamera; // Посилання на камеру
    private static float cameraDistance = 6f; // Базова висота
    private static float cameraRetreat = -0.01f; // Базовий відступ
    private static float cameraDistanceMod; // Модифікатор висоти
    private static float cameraForwardMod; // Модифікатор відступу

    public float maxSpeed = 10f; // Максимальна швидкість
    public float forceTime = 1.0f; // Час дії інерції
    public float forceMultipier = 100f; // Множник для сили 

    private Rigidbody rb;

    public float animTime = 20f;

    public float divider = 2f; // Множник, або дільник

    public static Vector3 scaleMod; // Модифікатор розміру
    private static Vector3 currentScale; // Поточний розмір
    private static float forwardMod; // Модифікатор розтягування
    private static float sideMod; // Модифікатор стискання

    void Start()
    {
        // Отримуємо доступ до компонента Rigidbody через змінну "rb"
        rb = GetComponent<Rigidbody>();
        // Привязує початковий розмір, до змінної "currentScale" 
        currentScale = transform.localScale;
        // Модифікатор розміру, що буде дорівнювати частині від початкового розміру
        scaleMod = transform.localScale / divider; // 1 / 2

        // Отримуємо корректні розміру множники для анімації
        forwardMod = currentScale.z * 1.3f;
        sideMod = currentScale.x * 0.8f;
    }
    public static void AddSize()
    {
        // Отримуємо "розмір" = "розмір" + "модифікатор"
        currentScale = currentScale + scaleMod;

        // Отримуємо корректні розміру множники для анімації
        forwardMod = currentScale.z * 1.3f;
        sideMod = currentScale.x * 0.8f;
    }
    public static void AddCameraDistance()
    {
        cameraDistanceMod = currentScale.x;
        cameraForwardMod = currentScale.x / 7f;
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
            cameraDistance + cameraDistanceMod,
            transform.position.z + cameraRetreat + cameraForwardMod);
    }
    private void SlimeMoveAnim()
    {
        // Плавно змінюємо розмір слайма
        float forwardScale = Mathf.Lerp(
            transform.localScale.z,
            forwardMod,
            Time.deltaTime / animTime);
        float sideScale = Mathf.Lerp(
            transform.localScale.x,
            sideMod,
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
            currentScale.z,
            (Time.deltaTime / animTime) / 2);
        float sideScale = Mathf.Lerp(
            transform.localScale.x,
            currentScale.x,
            (Time.deltaTime / animTime) / 2);
        // Застосовуємо зміни до localScale
        transform.localScale = new Vector3(
            sideScale,
            transform.localScale.y,
            forwardScale);
    }
}
