using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{

    enum Direcoes
    {
       Cima, Baixo, Direita, Esquerda 
    }
    [Header("Atributos")]
    public float forcaDoMov;
    public int health;
    private Direcoes movimento;

    [Header("Componentes")] 
    private Animator anim;
    private Rigidbody2D rig;

    [Header("Booleanos")] 
    private bool isMove;
    private bool podeMover;
    
    
    void Start()
    { 
        TryGetComponent(out anim);
        TryGetComponent(out rig);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void FixedUpdate()
    {
        switch (movimento)
        {
            case Direcoes.Cima:
                rig.velocity = new Vector2(0f, forcaDoMov);
                break;
            
            case Direcoes.Baixo:
                rig.velocity = new Vector2(0f, -forcaDoMov);
                break;
            case Direcoes.Direita:
                rig.velocity = new Vector2(forcaDoMov, 0f);
                break;
            case Direcoes.Esquerda:
                rig.velocity = new Vector2(-forcaDoMov, 0f);
                break;
        }
    }

    private void MovePlayer()
    {
        if (isMove)
        {
            if(Physics2D.Raycast(transform.position, Vector2.left))
            {
                podeMover = true;
            }

            else
            {
                podeMover = false; 
            }
        }

        if (podeMover)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                rig.constraints = RigidbodyConstraints2D.FreezePositionY;
                isMove = true;
            
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    movimento = Direcoes.Direita;
                    podeMover = false;
                }
                else
                {
                    movimento = Direcoes.Esquerda;
                    podeMover = false;
                }
            }
        
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                rig.constraints = RigidbodyConstraints2D.FreezePositionX;
                isMove = true;
            
                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    movimento = Direcoes.Cima;
                }
                else
                {
                    movimento = Direcoes.Baixo;
                }
            }
        }
    }
    
    
    
    private void OnCollisionEnter2D(Collision2D colPlayer)
    {
        if (colPlayer.gameObject.CompareTag("Wall"))
        {
            
        }
        
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
