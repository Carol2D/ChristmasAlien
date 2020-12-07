using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaHundibleScript : MonoBehaviour
{
    bool seHaIniciadoBajada = false;
    public bool estaBajando = false;
    public float speed;
    public float tiempoEspera;

    private void Update()
    {
        if (estaBajando)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!seHaIniciadoBajada && collision.gameObject.CompareTag("Player"))
        {
            seHaIniciadoBajada = true;
            Invoke("IniciarDescenso", tiempoEspera);
        }
    }

    private void IniciarDescenso()
    {
        estaBajando = true;
    }
}
