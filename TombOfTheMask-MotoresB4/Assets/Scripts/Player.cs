using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Atributos")]
    public float forcaDoMov;
    public int health;

    [Header("Componentes")] 
    private Animator anim;
    private Rigidbody2D rig;

    [Header("Booleanos")] 
    public bool isMove;
    
    
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

    private void MovePlayer()
    {
        
    }

    IEnumerator SlideMovePLayer()
    {
        if (!isMove){
            if (Input.GetKey(KeyCode.D))
            {
                rig.velocity = new Vector2(forcaDoMov, 0f);
                isMove = true;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rig.velocity = new Vector2(-forcaDoMov, 0f);
                isMove = true;
            }
        
            else if (Input.GetKey(KeyCode.W))
            {
                rig.velocity = new Vector2(0f, forcaDoMov);
                isMove = true;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rig.velocity = new Vector2(0f, -forcaDoMov);
                isMove = true;
            }
        }
    }
    
    
    private void OnCollisionEnter2D(Collision2D colPlayer)
    {
        if (colPlayer.gameObject.CompareTag("Wall"))
        {
            isMove = false;
        }
    }
    
}
