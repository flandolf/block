using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPortal : MonoBehaviour
{
    public Transform player;
    public PlayerMovement playerMovement;
    public string effectName;
    public float effectValue;
    public float effectDuration;

    private bool _isEffectActive;

    private float speedBefore;
    private float jumpBefore;
    private Vector3 sizeBefore;
    private void Start()
    {

        speedBefore = playerMovement.moveSpeed;
        jumpBefore = playerMovement.jumpForce;
        sizeBefore = player.localScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_isEffectActive)
        {
            _isEffectActive = true;
            playerMovement.onEffect = true;
            StartCoroutine(ActivateEffect());
        }
    }

    private IEnumerator ActivateEffect()
    {
        switch (effectName)
        {
            case "speed":
                playerMovement.moveSpeed += effectValue;
                break;
            case "jump":
                playerMovement.jumpForce += effectValue;
                break;
            case "size":
                player.localScale += new Vector3(effectValue, effectValue, 0);
                break;
            case "reset":
                playerMovement.moveSpeed = speedBefore;
                playerMovement.jumpForce = jumpBefore;
                player.localScale = sizeBefore;
                break;
        }

        yield return new WaitForSeconds(effectDuration);

        switch (effectName)
        {
            case "speed":
                playerMovement.moveSpeed -= effectValue;
                break;
            case "jump":
                playerMovement.jumpForce -= effectValue;
                break;
            case "size":
                player.localScale -= new Vector3(effectValue, effectValue, 0);
                break;
        }

        _isEffectActive = false;
        playerMovement.onEffect = false;
    }
}