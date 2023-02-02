using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHelmet : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up * 3 * Time.deltaTime);
    }
}
