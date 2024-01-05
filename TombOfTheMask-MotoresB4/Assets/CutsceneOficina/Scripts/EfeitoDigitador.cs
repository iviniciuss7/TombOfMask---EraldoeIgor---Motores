using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EfeitoDigitador : MonoBehaviour
{
    private TextMeshProUGUI compTexto;
    private AudioSource _audioSource;
    private string mensagemOriginal;
    public bool imprimindo;
    public float tempoLetras = 0.08f;
    

    private void Awake()
    {
        TryGetComponent(out compTexto);
        TryGetComponent(out _audioSource);
        mensagemOriginal = compTexto.text;
        compTexto.text = "";
    }
    
    private void OnEnable()
    {
        ImprimirMensagem(mensagemOriginal);
    }

    private void OnDisable()
    {
        compTexto.text = mensagemOriginal;
        StopAllCoroutines();
    }

    

    public void ImprimirMensagem(string mensagem)
    {
        if (gameObject.activeInHierarchy)
        {
            if (imprimindo) return;
            imprimindo = true;  
            StartCoroutine(LetraPorLetra(mensagem));
        }
        
        
    }

    IEnumerator LetraPorLetra(string mensagem)
    {
        string msg = "";
        foreach (var letra in mensagem)
        {
            msg += letra;
            compTexto.text = msg;
            _audioSource.Play();
            yield return new WaitForSeconds(tempoLetras);
            
            
        }

        imprimindo = false;
        StopAllCoroutines();
    }
    
    public void Limpar()
    {
        compTexto.text = "";
    }
}
