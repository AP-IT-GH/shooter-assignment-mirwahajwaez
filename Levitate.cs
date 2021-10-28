using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitate : MonoBehaviour
{
    public float yAxis = 10f;
    public float rotateSpeed = 10f;
    void Update()
    {
        transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * yAxis * Time.deltaTime);
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
