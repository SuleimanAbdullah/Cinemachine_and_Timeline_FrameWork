using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExposeEnemyShip : MonoBehaviour
{
    [SerializeField]        
    private GameObject _alienEnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        _alienEnemyPrefab.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _alienEnemyPrefab.SetActive(true);
        }
    }
}
