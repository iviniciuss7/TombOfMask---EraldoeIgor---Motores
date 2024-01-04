using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Indicador : MonoBehaviour
{
    public AudioSource coletaInd;

    private void Start()
    {
        coletaInd = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine("Coletar");
        }
    }

    IEnumerator Coletar()
    {
        coletaInd.Play();
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
