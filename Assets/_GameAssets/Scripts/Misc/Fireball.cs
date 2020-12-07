using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemigoDestruible"))
        {
            Destroy(collision.transform.parent.gameObject);//Ojo a la estructura
        }
        if (collision.CompareTag("Player") == false)
        {
            //Sólo se destruye si no "hacer trigger" contra el player
            Destroy(gameObject);
        }
    }
}
