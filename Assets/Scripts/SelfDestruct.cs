using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float seconds;

    void Start()
    {
        Destroy(gameObject, seconds);   
    }
}
