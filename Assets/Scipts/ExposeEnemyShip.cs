using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExposeEnemyShip : MonoBehaviour
{
    [SerializeField]        
    private GameObject _alienEnemyPrefab;
    private AudioSource _source;
    private bool _isSpaceShipExposed;
    // Start is called before the first frame update
    void Start()
    {
        _alienEnemyPrefab.SetActive(false);
        _source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && _isSpaceShipExposed == false)
        {
            _source.Play();
            _alienEnemyPrefab.SetActive(true);
            _isSpaceShipExposed = true;

        }
    }
}
