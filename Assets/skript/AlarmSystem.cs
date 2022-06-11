using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> _reached; 

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<Player>(out Player player))
            _reached.Invoke(true);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
            _reached.Invoke(false);
    }
}
