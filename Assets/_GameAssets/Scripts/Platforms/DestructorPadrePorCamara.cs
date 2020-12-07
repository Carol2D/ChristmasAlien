using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructorPadrePorCamara : MonoBehaviour
{
    PlataformaHundibleScript phs;
    private void Awake()
    {
        phs = GetComponentInParent<PlataformaHundibleScript>();
    }
    private void OnBecameInvisible()
    {
        if (phs.estaBajando)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
