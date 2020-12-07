using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header("Prefab del proyectil")]
    public GameObject prefabProjectile;
    [Header("Punto de lanzamiento")]
    public Transform spawnPoint;
    [Header("Fuerza vertical")]
    [Range(0,1000)]
    public float verticalForce;
    [Header("Fuerza horizontal")]
    [Range(0, 1000)]
    public float horizontalForce;
    [Header("Tiempo entre disparos (ms)")]
    [Range(0, 2000)]
    public float timeBetweenFire;
    
    /// <summary>
    /// Determina si se puede disparar o no.
    /// </summary>
    private bool canFire = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Fire();
        }
    }

    public void Fire()
    {
        if (canFire)
        {
            float direction = spawnPoint.transform.parent.transform.localScale.x;
            GameObject projectile = Instantiate(prefabProjectile, spawnPoint.position, spawnPoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalForce * direction, verticalForce));
            canFire = false;
            Invoke(nameof(RestoreFire), timeBetweenFire);
            GetComponentInParent<PlayerSoundManager>().PlayAudioFire();
        }
    }

    void RestoreFire()
    {
        canFire = true;
    }
}
