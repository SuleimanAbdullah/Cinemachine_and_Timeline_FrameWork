using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(this.gameObject, 5f);
    }
}
