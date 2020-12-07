using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReaction : MonoBehaviour
{

    public float fuerzaHorizontal;
    public float fuerzaVertical;

    private Rigidbody2D rb2d;
    private int direccion;
    private bool canJump = true;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    public void JumpBack()
    {
        if (!canJump) return;//Si no puedes saltar, no sigas.
        if (GameObject.Find("GameManager").GetComponent<GameManager>().godMode) return;//Si está en modo dios, no sigas.

        Vector2 direccionSalto = new Vector2(fuerzaHorizontal * direccion, fuerzaVertical);
        GetComponent<PlayerMover>().IniciarDespido();
        //GetComponent<Rigidbody2D>().AddForce(direccionSalto, ForceMode2D.Impulse);//Depende de la masa (que depende del movimiento)
        GetComponent<Rigidbody2D>().velocity = direccionSalto;//No depende de nada
        canJump = false;
        Invoke("RestaurarEstado", 0.2f);
    }
    private void FixedUpdate()
    {
        if (rb2d.velocity.x > 0)
        {
            direccion = -1;
        } else
        {
            direccion = 1;
        }
    }

    private void RestaurarEstado()
    {
        canJump = true;
    }

}
