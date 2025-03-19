using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_Move : MonoBehaviour
{
    public static WASD_Move Instance; // Сінглтон

    public Camera mainCamera; // Посилання на камеру
    private static float cameraDistance = 7f; // Дистанція камери

    public float maxSpeed = 10f; // Швидкість руху
    public float rotationSpeed = 10f; // Швидкість обертання

    private Rigidbody rb; // Посилання на фізиний компонент
    public Animator animator; // Посилання на аніматор

    private void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // Отримуємо значення вводу з клавіатури
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"),
            0, Input.GetAxis("Vertical"));

        // Пряме присвоєння швидкості, замість AddForce
        if (moveInput.magnitude > 0.1f) // Уникаємо дрібного коливання
        {
            Vector3 desiredVelocity = moveInput.normalized * maxSpeed;
            rb.velocity = new Vector3(desiredVelocity.x,
                rb.velocity.y, desiredVelocity.z);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
        // Обчислюємо локальний вектор руху відносно поточного повороту
        Vector3 localMovement = transform.InverseTransformDirection(
            moveInput);
        // Передаємо локальні координати в аніматор
        animator.SetFloat("VelocityX", localMovement.x);
        animator.SetFloat("VelocityZ", localMovement.z);
        // Оновлення позиції камери
        mainCamera.transform.position = new Vector3(
            transform.position.x,
            cameraDistance,
            transform.position.z - cameraDistance / 7);
    }
}
