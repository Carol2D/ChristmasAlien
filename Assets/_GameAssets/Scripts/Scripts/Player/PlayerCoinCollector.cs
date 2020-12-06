using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinCollector : MonoBehaviour
{
    private PlayerSoundManager psm;
    private void Awake()
    {
        psm = GetComponent<PlayerSoundManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            psm.PlayAudioCoin();
            Destroy(collision.transform.parent.gameObject);
            int puntos = collision.gameObject.GetComponentInParent<Coin>().puntos;
            //Play sound!!!
            GameObject.Find("GameManager").GetComponent<GameManager>().IncrementarPuntuacion(puntos);
        }
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.transform.parent.gameObject);
            int puntos = collision.gameObject.GetComponentInParent<Coin>().puntos;
            //Play sound!!!
            GameObject.Find("GameManager").GetComponent<GameManager>().IncrementarPuntuacion(puntos);
        }
    }*/
}
