using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerObj : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
