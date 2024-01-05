using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private Animator anim;
    public AudioSource sourcePlayer;
    public AudioClip clipDie, clipCoin, clipStar;
    private Vector2 direcaoAtual;

    void Start()
    {
        sourcePlayer = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        direcaoAtual = Vector2.zero;
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 novaDirecao = new Vector2(horizontal, vertical).normalized;
        
        if (rb.velocity == Vector2.zero)
        {
            direcaoAtual = novaDirecao;
        }
        
        Vector2 moveVelocity = direcaoAtual * moveSpeed;
        rb.velocity = moveVelocity;    
    }

    IEnumerator Die()
    {
        anim.SetTrigger("dying");
        yield return new WaitForSeconds(1.2f);
        GameManager.instance.GameOver();
        Destroy(gameObject);
    }
    
    
    
    private void OnCollisionEnter2D(Collision2D colPlayer)
    {

        if (colPlayer.gameObject.CompareTag("ENEMY")) 
        {
            sourcePlayer.PlayOneShot(clipDie);
            StartCoroutine("Die");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D colPlayer)
    {

        if (colPlayer.gameObject.CompareTag("Coin"))
        {
            sourcePlayer.PlayOneShot(clipCoin);
        }
        
        if (colPlayer.gameObject.CompareTag("Star"))
        {
            sourcePlayer.PlayOneShot(clipStar);
        }

        if (colPlayer.gameObject.CompareTag("Chegada"))
        {
            int cenaAtual = SceneManager.GetActiveScene().buildIndex;
            int proxCena = cenaAtual + 1;
            
            if (proxCena == SceneManager.sceneCountInBuildSettings)
            {
                proxCena = 0;
            }

            SceneManager.LoadScene(proxCena);
        }
    }
}
