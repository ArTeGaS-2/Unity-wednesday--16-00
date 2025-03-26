using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microorganism : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

        }
        if (other.gameObject.CompareTag("Slime"))
        {
            Slime.Instance.AddSpeedForce();
            Slime.AddSize();
            Slime.AddCameraDistance();
        }
        Score.Instance.AddScore();
        Destroy(gameObject);
    }
}
