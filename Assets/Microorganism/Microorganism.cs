using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microorganism : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Slime.AddSize();
        Slime.AddCameraDistance();
        Destroy(gameObject);
    }
}
