using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerFightCutScene : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector _shipFightingDirector;
    private bool _isSpaceShipFight;
    // Start is called before the first frame update
    void Start()
    {
        _shipFightingDirector.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && _isSpaceShipFight == false)
        {
            _isSpaceShipFight = true;
            _shipFightingDirector.gameObject.SetActive(true);
            _shipFightingDirector.Play();
        }
    }
}
