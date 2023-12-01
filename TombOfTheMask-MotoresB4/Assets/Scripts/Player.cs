using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Atributos")]
    public float forcaDoMov;
    public int health;

    [Header("Atributos")] 
    public Animator anim;
    public Rigidbody2D rig;

    [Header("Booleanos")] 
    public bool isMovendo;
    
    
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
        //rig.AddForce(new Vector2(forcaDoMov, 0), ForceMode2D.Impulse);
    }
    
    
}
