using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformManager : MonoBehaviour
{
    private const string TAG_ADHERENTE = "Adherente";
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(TAG_ADHERENTE))
        {
            transform.SetParent(collision.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.SetParent(null);
    }
}