using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatusManager : MonoBehaviour
{
    [SerializeField]
    private int numeroVidas;
    [SerializeField]
    private int puntuacion;

    private static GameStatusManager _instance;
    public static GameStatusManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public int GetNumeroVidas()
    {
        return numeroVidas;
    }
    public void SetNumeroVidas(int value)
    {
        numeroVidas = value;
    }
    public int GetPuntuacion()
    {
        return puntuacion;
    }
    public void SetPuntuacion(int value)
    {
        puntuacion = value;
    }

    
}
