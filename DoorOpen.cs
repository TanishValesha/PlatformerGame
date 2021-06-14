using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public SpriteRenderer spriteRenderer, spriteRenderer2;
    public Sprite doorOpen, switchOn;
    public AudioSource sound;
    public AudioClip doorSound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sound.PlayOneShot(doorSound);
            spriteRenderer.sprite = doorOpen;
            spriteRenderer2.sprite = switchOn;
        }
    }
}
