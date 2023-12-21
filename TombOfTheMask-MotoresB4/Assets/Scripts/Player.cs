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
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position = transform.position + movement * forcaDoMov * Time.deltaTime;

    }
    
    
}
