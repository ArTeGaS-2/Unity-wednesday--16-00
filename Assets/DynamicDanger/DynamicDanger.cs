using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DynamicDanger : MonoBehaviour
{
    public float needToGo = 3f; // �������� � ��� ����� 䳺�
    public float objectSpeed = 5f; // �������� ������ / ��'����

    private Rigidbody rb; // ����� ��� ������� �� ����������

    public float anglePerIteration = 90f; // ���� ���� �� ��������

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
        rb = GetComponent<Rigidbody>(); // ����'����� Rigidbody �� ����� "rb"
        StartCoroutine(RotateDynamicDanger());
    }
    private void Update()
    {
        Vector3 forward = transform.up;
        // �������� ��'��� � ��������
        rb.velocity = forward * // �������� - ������(forward)
                      objectSpeed * // ��������
                      Time.deltaTime; // ���������� �������� ����
    }
    private IEnumerator RotateDynamicDanger()
    {
        while (true)
        {
            yield return new WaitForSeconds(needToGo); // �������� � ��������

            // ����� ��������� ���� 
            Vector3 currenEulerAngles = 
                transform.rotation.eulerAngles;
            // ��������� ��� �� ���������� z
            currenEulerAngles.y += anglePerIteration;
            // ������������ ����� ��������� ���������
            transform.rotation = Quaternion.Euler(currenEulerAngles);
        }
    }
}
