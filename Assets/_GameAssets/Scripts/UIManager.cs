using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Image imagenLlave;

    private void Awake()
    {
        imagenLlave = GameObject.Find("ImageKeyOn").GetComponent<Image>();
    }

    /// <summary>
    /// Crea las imagenes de los corazones en la UI del juego
    /// </summary>
    public void CrearVidasUI(int numeroVidas, GameObject prefabImagenVida, GameObject panelVidas)
    {
        LimpiarPanelVidas(panelVidas);
        for (int i = 0; i < numeroVidas; i++)
        {
            GameObject nuevaImagenVida = Instantiate(prefabImagenVida, transform.position, transform.rotation);
            nuevaImagenVida.transform.SetParent(panelVidas.transform);
            nuevaImagenVida.transform.localScale = Vector3.one;
        }
    }

    private void LimpiarPanelVidas(GameObject panelVidas)
    {
        foreach (Transform child in panelVidas.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void ActivarLlaveUI()
    {
        imagenLlave.enabled = true;
    }
   
}
