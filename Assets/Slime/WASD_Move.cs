using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_Move : MonoBehaviour
{
    public static WASD_Move Instance; // ѳ������

    public Camera mainCamera; // ��������� �� ������
    private static float cameraDistance = 7f; // ��������� ������

    public float maxSpeed = 10f; // �������� ����
    public float rotationSpeed = 10f; // �������� ���������

    private Rigidbody rb; // ��������� �� ������� ���������
    public Animator animator; // ��������� �� �������

    private void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // �������� �������� ����� � ���������
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"),
            0,Input.GetAxis("Vertical"));
    }
}
