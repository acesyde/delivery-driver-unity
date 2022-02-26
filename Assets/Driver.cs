using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 1f;
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float slowSpeed = 15f;
    [SerializeField] private float boostSpeed = 30f;
    
    void Start()
    {
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0f,0f,-steerAmount);
        transform.Translate(0,moveAmount,0);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        moveSpeed = slowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Boost"))
        {
            moveSpeed = boostSpeed;
        }
    }
}
