using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloorDetector : MonoBehaviour
{
    private PlayerSoundManager psm;
    private void Awake()
    {
        psm = GetComponentInParent<PlayerSoundManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "TilemapSuperior")
        {
            psm.PlayAudioLanding();
        }
    }
}
