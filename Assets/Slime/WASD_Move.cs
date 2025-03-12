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
            0,Input.GetAxis("Vertical"));
    }
}
