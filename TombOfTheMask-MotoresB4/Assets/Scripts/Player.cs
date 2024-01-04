using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Animations;
public class Player : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;

    private Vector2 direcaoAtual;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direcaoAtual = Vector2.zero;
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 novaDirecao = new Vector2(horizontalInput, verticalInput).normalized;
        
        if (rb.velocity == Vector2.zero)
        {
            direcaoAtual = novaDirecao;
        }
        
        Vector2 moveVelocity = direcaoAtual * moveSpeed;
        rb.velocity = moveVelocity;
    }
    
    
    
    private void OnCollisionEnter2D(Collision2D colPlayer)
    {

        if (colPlayer.gameObject.CompareTag("Enemy")) 
        {
            
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D colPlayer)
    {
        if (colPlayer.gameObject.CompareTag("Indicador"))
        {
            
        }
        
        if (colPlayer.gameObject.CompareTag("Coin"))
        {
            
        }
        
        if (colPlayer.gameObject.CompareTag("Star"))
        {
            
        }
    }
}
