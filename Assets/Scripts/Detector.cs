using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Detector : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> _triggered; 

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<Player>(out Player player))
            _triggered.Invoke(true);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
            _triggered.Invoke(false);
    }
}
