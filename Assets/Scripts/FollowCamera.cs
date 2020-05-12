using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float minX = 7;
    public float maxX = 100;

    public float minY = 0;
    public float maxY = 100;

    public GameObject target;

    void Update()
    {
        float x = Mathf.Clamp(target.transform.position.x, minX, maxX);
        float y = Mathf.Clamp(target.transform.position.y, minY, maxY);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
