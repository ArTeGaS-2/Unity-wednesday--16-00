using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microorganism : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Score.Instance.AddScore();
        Slime.Instance.AddSpeedForce();
        Slime.AddSize();
        Slime.AddCameraDistance();
        Destroy(gameObject);
    }
}
