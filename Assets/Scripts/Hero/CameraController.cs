using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _hero;
    private Vector3 _position;
    private void Update()
    {
        _position = _hero.position;
        _position.x += 1.5f;
        _position.y += 2f;
        _position.z = -14f;
        transform.position = Vector3.Lerp(transform.position, _position, Time.deltaTime);
    }
}

