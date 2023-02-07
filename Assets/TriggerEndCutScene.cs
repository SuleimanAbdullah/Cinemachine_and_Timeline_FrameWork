using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerEndCutScene : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector _endCutSceneDirector;
    // Start is called before the first frame update
    void Start()
    {
        _endCutSceneDirector.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _endCutSceneDirector.gameObject.SetActive(true);
            _endCutSceneDirector.Play();
        }
    }
}
