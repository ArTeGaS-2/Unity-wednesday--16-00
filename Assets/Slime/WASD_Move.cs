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
    public Animator animator; // ��������� �� ��������

    private Projectile projectile;
    private void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
        projectile = GetComponent<Projectile>();
    }
    private void Update()
    {
        // �������� �������� ����� � ���������
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"),
            0, Input.GetAxis("Vertical"));

        // ����� ��������� ��������, ������ AddForce
        if (moveInput.magnitude > 0.1f) // ������� ������� ���������
        {
            Vector3 desiredVelocity = moveInput.normalized * maxSpeed;
            rb.velocity = new Vector3(desiredVelocity.x,
                rb.velocity.y, desiredVelocity.z);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
        // ���������� ��������� ������ ���� ������� ��������� ��������
        Vector3 localMovement = transform.InverseTransformDirection(
            moveInput);
        // �������� �������� ���������� � ��������
        animator.SetFloat("VelocityX", localMovement.x);
        animator.SetFloat("VelocityZ", localMovement.z);

        // ��������� ����� � �������� ����
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);
        if (plane.Raycast(ray, out float rayDistance))
        {
            Vector3 worldMousePosition = ray.GetPoint(rayDistance);
            Vector3 directionToMouse = worldMousePosition -
                transform.position;
            directionToMouse.y = 0;

            if (directionToMouse.sqrMagnitude > 0.001f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(
                    directionToMouse);
                transform.rotation = Quaternion.Lerp(
                    transform.rotation, targetRotation,
                    Time.deltaTime * rotationSpeed);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            projectile.ShootProjectileForward();
        }

        // ��������� ������� ������
        mainCamera.transform.position = new Vector3(
            transform.position.x,
            cameraDistance,
            transform.position.z - cameraDistance / 7);
    }
}
