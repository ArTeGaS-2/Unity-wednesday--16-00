using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectilePrefab; // Шаблон проджектайлу
    public float projectileSpeed = 10f; // Швидкість руху проджектайлу

    // Вказуємо точку, з якої буде створюватися проджектайл(Перед персонажем)
    public Transform spawnPoint;
    public void ShootProjectileForward()
    {
        // Напрямок обираємо за орієнтацією персонажа.
        Vector3 direction = transform.forward;
        // Встановлюємо обертання для преджектайлу у напрямку руху
        Quaternion projectileRotation = Quaternion.LookRotation(direction);
        // Створення проджектайлу з заданою позицією та обертанням
        GameObject projectile = Instantiate(projectilePrefab,
            spawnPoint.position,
            projectileRotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null) { rb.velocity = direction * projectileSpeed; }
        Destroy(projectile, 10f);
    }
}

