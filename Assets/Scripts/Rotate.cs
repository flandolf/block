using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Transform _transform;
    private float _rotationSpeed = 100f;
    void Start()
    {
        _transform = GetComponent<Transform>();
    }
    
    void Update()
    {
        _transform.Rotate(Vector3.forward * (_rotationSpeed * Time.deltaTime));
    }
}
