using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectilePrefab; // ������ ������������
    public float projectileSpeed = 10f; // �������� ���� ������������

    // ������� �����, � ��� ���� ������������ �����������(����� ����������)
    public Transform spawnPoint;
    public void ShootProjectileForward()
    {
        // �������� ������� �� ��������� ���������.
        Vector3 direction = transform.forward;
        // ������������ ��������� ��� ������������ � �������� ����
        Quaternion projectileRotation = Quaternion.LookRotation(direction);
        // ��������� ������������ � ������� �������� �� ����������
        GameObject projectile = Instantiate(projectilePrefab,
            spawnPoint.position,
            projectileRotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null) { rb.velocity = direction * projectileSpeed; }
        Destroy(projectile, 10f);
    }
}

