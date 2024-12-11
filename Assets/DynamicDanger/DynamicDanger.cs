using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDanger : MonoBehaviour
{
    public float needToGo = 10;

    private void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
