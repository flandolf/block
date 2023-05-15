using System;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    public Transform block;
    public Transform blockPosition;
    public bool inverse;
    private bool _isPressed;
    private Vector3 _blockInitialPosition;

    private void Start()
    {
        _blockInitialPosition = block.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_isPressed)
            {
                _isPressed = true;
                if (inverse)
                {
                    block.position = _blockInitialPosition;
                }
                else
                {
                    block.position = blockPosition.position;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (_isPressed)
            {
                _isPressed = false;
                if (inverse)
                {
                    block.position = blockPosition.position;
                }
                else
                {
                    block.position = _blockInitialPosition;
                }
            }
        }
    }
}