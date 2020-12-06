using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool useVJoystick;
    
    public enum Estado { Menu, Pause, Playing, GameOver}

    private const int TIME_TO_RELOAD = 2;

    [Header("ESTADO DEL JUEGO")]
    //Estado
    public Estado estado = Estado.Menu;

    [Header("CONFIGURACION")]
    //Configuracion
    public bool soundOn = true;
    public bool musicOn = true;

    [Header("ESTADO")]
    //Estado del juego
    public int puntuacion;
    public int numeroVidasMaximo;
    public int numeroVidas;

    [Header("INVENTARIO")]
    //Inventario
    public bool hasKey = false;

    [Header("POWERS UP")]
    //PowerUp
    //-->Super Velocidad
    public float superSpeedValue;
    public bool superSpeed = false;
    //-->Super Salto
    public float superJumpValue;
    public bool superJump = false;
    //-->Modo Divino
    public float godModeTime;
    public bool godMode = false;

    [Header("CONFIGURACION UI")]
    //UI
    public GameObject prefabImagenVida;
    private GameObject panelVidas;
    private Text txtPuntuacion;
    private GameObject txtGameOver;
    private GameObject mobileControls;
    private GameObject menuPanel;

    //PLAYER
    private GameObject player;
    //INFO CONTINUE GAME
    public static bool continueGame = false;
    private void Awake()
    {
        //Obtención de referencias
        panelVidas = GameObject.Find("PanelCorazones");
        txtPuntuacion = GameObject.Find("TxtScore").GetComponent<Text>();
        txtGameOver = GameObject.Find("TextGameOver");
        txtGameOver.SetActive(false);
        menuPanel = GameObject.Find("PanelMenu");
        menuPanel.SetActive(false);
        mobileControls = GameObject.Find("MobileControls");

        player = GameObject.Find("Player");
        puntuacion = 0;
        if (continueGame) RecuperarEstado();
        txtPuntuacion.text = puntuacion.ToString();
        numeroVidas = numeroVidasMaximo;
        
        GetComponent<UIManager>().CrearVidasUI(numeroVidas, prefabImagenVida, panelVidas);
        if (UseVJoystick())
        {
            mobileControls.SetActive(true);
        } else
        {
            mobileControls.SetActive(false);
        }
    }

    private void Start()
    {
        //STATUS
        if (GameStatusManager.Instance.GetNumeroVidas() > 0)
        {
            numeroVidas = GameStatusManager.Instance.GetNumeroVidas();
            GetComponent<UIManager>().CrearVidasUI(numeroVidas, prefabImagenVida, panelVidas);
            puntuacion = GameStatusManager.Instance.GetPuntuacion();
            txtPuntuacion.text = puntuacion.ToString();
        }
        //FIN DE STATUS

    }
    public void QuitarVida()
    {
        if (godMode) return;
        numeroVidas--;
        GameStatusManager.Instance.SetNumeroVidas(numeroVidas);//STATUS DEL JUEGO
        GetComponent<UIManager>().CrearVidasUI(numeroVidas, prefabImagenVida, panelVidas);
        if (numeroVidas == 0)
        {
            //GameOver
            txtGameOver.SetActive(true);
            menuPanel.SetActive(true);
            player.SetActive(false);
            Invoke(nameof(LoadCoverScene), TIME_TO_RELOAD);
        }
    }
    public void RecogerLlave()
    {
        hasKey = true;
        GetComponent<UIManager>().ActivarLlaveUI();
    }
    public void IncrementarPuntuacion(int puntos)
    {
        puntuacion += puntos;
        GameStatusManager.Instance.SetPuntuacion(puntuacion);//STATUS DEL JUEGO
        txtPuntuacion.text = puntuacion.ToString();
    }
    public void GuardarEstado()
    {
        //Guardamos la puntuacion, si tenemos llave o no.
        PlayerPrefs.SetInt("Score", puntuacion);
        int key = hasKey ? 1 : 0;
        PlayerPrefs.SetInt("HasKey", key);
        PlayerPrefs.SetString("SceneName", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetFloat("x", player.transform.position.x);
        PlayerPrefs.SetFloat("y", player.transform.position.y);
        PlayerPrefs.Save();
    }
    public void RecuperarEstado()
    {
        continueGame = false;
        if (PlayerPrefs.HasKey("Score"))
        {
            puntuacion = PlayerPrefs.GetInt("Score");
            if (PlayerPrefs.GetInt("HasKey") == 1)
            {
                RecogerLlave();
            }
            player.transform.position = new Vector2(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"));
        }
    }
    private void LoadCoverScene()
    {
        SceneManager.LoadScene("CoverScene");
    }
    private bool UseVJoystick()
    {
        bool mobilePlatfomr =
            ((Application.platform == RuntimePlatform.Android)
            ||
            (Application.platform == RuntimePlatform.IPhonePlayer));
        if (mobilePlatfomr)
        {
            //En un dispositivo movil
            useVJoystick = true;
        }
        else if (Application.platform != RuntimePlatform.WindowsEditor) 
        {
            //En el resto
            useVJoystick = false;
        }
        //En el Editor de Unity
        return useVJoystick;
    }
}
