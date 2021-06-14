using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAI : MonoBehaviour
{
    public float speed;
    void Start()
    {
        transform.Rotate(0, 0, -90);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }
}
