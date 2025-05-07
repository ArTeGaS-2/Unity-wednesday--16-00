using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public static Slime Instance;

    public Camera mainCamera; // ��������� �� ������
    private static float cameraDistance = 7f; // ������ ������
    private static float cameraDistanceMod; // ����������� ������
    public float multiplier = 0.02f;

    public float maxSpeed = 10f; // ����������� ��������
    public float forceMultipier = 100f; // ������� ��� ���� 
    public float forceMod = 15f;

    private Rigidbody rb;

    public float animTime = 20f;

    public float divider = 2f; // �������, ��� ������

    public static Vector3 scaleMod; // ����������� ������
    private static Vector3 currentScale; // �������� �����
    private static float forwardMod; // ����������� ������������
    private static float sideMod; // ����������� ���������

    private Projectile projectileScript; // ������ ������������

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        projectileScript = GetComponent<Projectile>();
        // �������� ������ �� ���������� Rigidbody ����� ����� "rb"
        rb = GetComponent<Rigidbody>();
        // ������� ���������� �����, �� ����� "currentScale" 
        currentScale = transform.localScale;
        // ����������� ������, �� ���� ���������� ������ �� ����������� ������
        scaleMod = transform.localScale / divider; // 1 / 2

        // �������� �������� ������ �������� ��� �������
        forwardMod = currentScale.z * 1.3f;
        sideMod = currentScale.x * 0.8f;

        cameraDistanceMod = multiplier;
    }
    public void AddSpeedForce()
    {
        forceMultipier += forceMod;
    }

    public static void AddSize()
    {
        // �������� "�����" = "�����" + "�����������"
        currentScale = currentScale + scaleMod;

        // �������� �������� ������ �������� ��� �������
        forwardMod = currentScale.z * 1.3f;
        sideMod = currentScale.x * 0.8f;
    }
    public static void AddCameraDistance()
    {
        cameraDistance = cameraDistance + cameraDistanceMod;
    }
    void Update()
    {
        // ������ ������� ���� � ������� �����������
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 targetPosition = hit.point;

            // ��������� �������� �� ������� �� ����� �������
            Vector3 direction = (
                targetPosition - transform.position).normalized;
            direction.y = 0;

            // ��������� ������ � �������� �������
            if (direction.magnitude > 0.1f) // ��� �������� ������� ���������
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(
                    transform.rotation, targetRotation, Time.deltaTime * 5f);
            }

            // ������ ��������� � �������� �������
            if (Input.GetMouseButton(0))
            {
                rb.AddForce(direction * forceMultipier * Time.deltaTime,
                    ForceMode.Acceleration);
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

                // ����� �������
                SlimeMoveAnim();
            }
            else
            {
                // ������� �������
                SlimeStopAnim();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            projectileScript.ShootProjectileForward();
        }

        // ������ ����� �� ��'����� ������
        mainCamera.transform.position = new Vector3(
            transform.position.x,
            cameraDistance,
            transform.position.z + -cameraDistance / 7);
    }
    private void SlimeMoveAnim()
    {
        // ������ ������� ����� ������
        float forwardScale = Mathf.Lerp(
            transform.localScale.z,
            forwardMod,
            Time.deltaTime / animTime);
        float sideScale = Mathf.Lerp(
            transform.localScale.x,
            sideMod,
            Time.deltaTime / animTime);
        // ����������� ���� �� localScale
        transform.localScale = new Vector3(
            sideScale,
            transform.localScale.y,
            forwardScale);
    }
    private void SlimeStopAnim()
    {
        // ������ ������� ����� ������
        float forwardScale = Mathf.Lerp(
            transform.localScale.z,
            currentScale.z,
            (Time.deltaTime / animTime) / 2);
        float sideScale = Mathf.Lerp(
            transform.localScale.x,
            currentScale.x,
            (Time.deltaTime / animTime) / 2);
        // ����������� ���� �� localScale
        transform.localScale = new Vector3(
            sideScale,
            transform.localScale.y,
            forwardScale);
    }
}
