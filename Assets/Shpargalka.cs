using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����� - �������� ��������� �������
public class Shpargalka : MonoBehaviour 
{
    // ֳ�� ����� "int" � ��������� 12.
    // private - ����������� ������� �� ����� age,
    // ��������� ���������� ����� � �������� Unity �� ��. ��������
    private int age = 12;

    // ������� ����� "float" � ��������� 1.58.
    // "f" - ������� �� ��� ����� "float"
    // public - �� ��������� ������ ����� � �������� Unity
    // �� � ����������� ��'���� ������ Shpargalka (� ������ �������)
    public float height = 1.58f;

    // ������ ������(�������) "string" � ��������� '�����'
    // static - �� ��������� �������� �������� � ��� ����������
    public static string name = "�����";

    // ������� ��� ����� "bool".
    // ������ ����� 2 �������� = "true" ��� "false"
    private bool logic = false;

    // ���������� ���� ���, ���� ��������� ��'���� �'���������
    // �� �����. ������� ����� "void" ����� �� ��, �� ���� �����
    // �� ������� ����������� �������� ������ return
    private void Start()
    // Start - ��������� �������
    {
        // List - ������, ������ ���������, ��� ���������� ������
        // �������� ����� ��� ��'����
        List<int> ages = new List<int>(); // ������ ������

        // ������ ���������

        if (logic) // �������� �����
        {
            // ��� ���� ���, ���� ���������� � �������, ���� �����
            // ������� ������ "true"
        }
        else if (!logic) // �������� ���� �����
            // ���� "!" ����� ������ ������� �� ��������
            // �������: ��� logic ����� �������� �� "true"
        {
            // ���
        }
        else // ����������, ���� ����� � ���� �� � ������
        {
            // ���
        }

        // ���������� ���������

        if (1 < 2) { } // < ������ ���
        if (1 > 2) { } // > ������ ���
        if (1 <= 2) { } // <= ������ ��� �������
        if (1 >= 2) { } // >= ������ ��� �������
        if (1 == 2) { } // == �������
        if (1 != 2) { } // != �� �������

        // ���������� ���� �� ������� ����� ����
        if (1 == 2 && 2 == 1) { } // && - ������ "��"
        // ���������� ���� ���� � ���� ����� ����
        if (1 == 2 || 2 == 1) { } // || - ������ "���"
        
        // ������������ ���������� if, else if, else
        switch (age) // �������� ���� ������ �����
        {
            case 12: // ������� "age" � ��������� "12"
                // ���
                break; // �������� ��������� ����
            case 13:
                // ���
                break;
            default: // ����������, ���� ����� � ������� �� ������
                // ���
                break;
        }
    }
    // ���������� ����� ����, ���� ��������� ��'���� ��������
    private void Update()
    // Update - ��������� �������
    {
        
    }

}
