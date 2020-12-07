using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidbody;
    float offset = 0;
    Renderer r;
    Material m;
    void Start()
    {
        r = GetComponent<Renderer>();
        m = r.material;
    }

    void Update()
    {
        offset += Time.deltaTime * rigidbody.velocity.x * speed;
        m.SetTextureOffset("_MainTex", new Vector2(offset, 0) );
        r.material = m;
    }
}