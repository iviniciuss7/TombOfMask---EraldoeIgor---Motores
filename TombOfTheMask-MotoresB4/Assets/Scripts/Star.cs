using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Star : MonoBehaviour
{
    public int scoreValue;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.UpdateScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
