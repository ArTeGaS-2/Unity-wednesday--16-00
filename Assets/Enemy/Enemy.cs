using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    private Transform target; // ֳ�� ������ (������� ������)
    private NavMeshAgent agent; // ��������� ������ AI Navigation
    private void Start()
    {
        // ��������� ��������� ������ �� ���� � �������� �������
        target = GameObject.Find("Slime").GetComponent<Transform>();
        // �������� ��������� NavMeshAgent � ��'���� ������
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        // ��������, �� ���� ���������/ �������� ���� (�������)
        if (target != null)
        {
            // ���������� ���� ��� ��'���� ������
            agent.SetDestination(target.position);
        }
    }
    IEnumerator StopMoving()
    {
        // ������� ������ 
        agent.isStopped = true;
        // ���� 3 �������
        yield return new WaitForSeconds(3f);
        // ������� ��� ������
        agent.isStopped = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StopMoving());
        }
    }
}
