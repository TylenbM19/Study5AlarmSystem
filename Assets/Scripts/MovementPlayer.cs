using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed = 2;

    private Transform[] _points;
    private int _currentPoint = 0;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _path.GetChild(i).transform;
        }
    }
    private void Update()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if(transform.position == target.position)
        {
            _currentPoint++;

            if(_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
