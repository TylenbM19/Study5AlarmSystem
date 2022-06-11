using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundControl : MonoBehaviour
{
    public float volumeMultiplayer = 0.001f;
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

        if (result == true)
            _coroutine = StartCoroutine(SetVolume(_maxVolume));
        else
            _coroutine = StartCoroutine(SetVolume(_minVolume));
    }

    private IEnumerator SetVolume(float target)
    {
        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, volumeMultiplayer);
            yield return null;
        }
    }
}
