using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    private Transform target; // Ціль ворога (персонає гравця)
    private NavMeshAgent agent; // Компонент агента AI Navigation
    private void Start()
    {
        if (GameObject.Find("Slime") != null)
        {
            // Знаходимо персонажа гравця по назві і отримуємо позицію
            target = GameObject.Find("Slime").GetComponent<Transform>();
        }
        if (GameObject.Find("Player") != null)
        {
            // Знаходимо персонажа гравця по назві і отримуємо позицію
            target = GameObject.Find("Player").GetComponent<Transform>();
        }
        // Отримуємо компонент NavMeshAgent з об'єкту ворога
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        // Перевіряє, чи була визначена/ знайдена ціль (гравець)
        if (target != null)
        {
            // Встановлює ціль для об'єкта агента
            agent.SetDestination(target.position);
        }
    }
    IEnumerator StopMoving()
    {
        // Зупиняє ворога 
        agent.isStopped = true;
        // Чекає 3 секунди
        yield return new WaitForSeconds(3f);
        // Повертає рух ворогу
        agent.isStopped = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
