using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    public Transform checkpoint;

    public void OnTriggerEnter(Collider other)
    {
        other.transform.position = checkpoint.position;
    }
}
