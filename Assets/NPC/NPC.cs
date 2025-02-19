using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject gameShop; // ��������� �� ��'��� ��������

    private void Start()
    {
        gameShop = GetComponent<GameObject>();
        gameShop.SetActive(false);
    }
    private void OnMouseOver() // �� ����������� ����� �� ��'���
    {
        // �������� ���������� ����� ������ ����
        if (Input.GetMouseButtonDown(1))
        {
            gameShop.SetActive(true);
        }
    }
}
