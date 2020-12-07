using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAngryBird : MonoBehaviour
{
    public float forceScale;
    public Transform posicionInicial;
    private bool isPlayerSelected = false;

    private void Update()
    {
        if (Input.touchCount > 0)//Input.touchCount -->Indica cuantos punteros (dedos) hay sobre la pantalla
        {
            Touch t = Input.GetTouch(0);//Nos proporciona la info del primer puntero que se posa en la pantalla
            Vector3 np = Camera.main.ScreenToWorldPoint(t.position);
            switch (t.phase)
            {
                case TouchPhase.Began:
                    if (ComprobarPulsacionObjetoByName(t, transform.name))
                    {
                        GetComponent<Rigidbody2D>().isKinematic = true;
                        isPlayerSelected = true;
                    }
                    break;
                case TouchPhase.Ended:
                    if (isPlayerSelected)
                    {
                        Lanzar();
                        isPlayerSelected = false;
                    }
                    break;
                case TouchPhase.Moved:
                    if (isPlayerSelected)
                    {
                        np = new Vector3(np.x, np.y, 0);//Corregir la z
                        transform.position = np;
                    }
                    break;
            }
        }
    }

    void Lanzar()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
        Vector2 direction = posicionInicial.position - transform.position;
        GetComponent<Rigidbody2D>().AddForce(direction * forceScale);
    }

    private bool ComprobarPulsacionObjetoByName(Touch _t, string _name)
    {
        bool estaPulsado = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(getWorldPosition(_t), 0.1f);
        foreach(Collider2D col in colliders)
        {
            if (col.transform.name == _name)
            {
                estaPulsado = true;
                break;
            }
        }
        return estaPulsado;
    }

    private Vector3 getWorldPosition(Touch _t)
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(_t.position.x, _t.position.y, 0));
    }


    /*
    private void OnMouseDrag()
    {
        //Conversión de las coordenadas de la pantalla a las coordenadas del mundo
        Vector3 np = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        np = new Vector3(np.x, np.y, 0);//Corregir la z
        transform.position = np;
    }

    private void OnMouseUp()
    {
        Lanzar();
    }
    */
}
