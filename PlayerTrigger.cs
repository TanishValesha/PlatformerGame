using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Object = UnityEngine.Object;

public class PlayerTrigger : MonoBehaviour
{
    public int coinNumber = 0;
    public AudioSource _audio;
    public AudioClip coinSound;

    void Start()
    {
        _audio = GameObject.FindObjectOfType<AudioSource>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            _audio.PlayOneShot(coinSound);
            coinNumber++;
        }
    }
}
