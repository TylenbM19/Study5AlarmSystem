using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof (AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _volumeMultiplayer = 0.001f;
    private AudioSource _audioSource;
    private Coroutine _coroutine;
    private float _minVolume = 0;
    private float _maxVolume = 1f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Setting(bool result)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = result? StartCoroutine(SetVolume(_maxVolume)) : StartCoroutine(SetVolume(_minVolume));
    }

    private IEnumerator SetVolume(float target)
    {
        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _volumeMultiplayer);
            yield return null;
        }
    }
}
