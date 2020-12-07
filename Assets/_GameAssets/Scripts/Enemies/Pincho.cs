using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pincho : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerReaction>().JumpBack();
            collision.gameObject.GetComponent<PlayerManager>().RecibirDanyo();
        }
    }
}
