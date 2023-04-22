using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, speed*5, 0) * Time.deltaTime);
    }
}
