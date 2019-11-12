using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public PlayerControlle player;
    public int joyasLaberinto;

    //Paneles del GUI
    public GameObject panelFin;
    public GameObject panelReset;

    //Textos del GUI
    public Text textoJoyasMano;
    public Text textoEnergia;
    public Text final;
   

    //Botones
    //Boton para volver a entrar en el laberinto
    public Button resetBut;
    Button botonRes;
    //Boton para salir del juego y volver al nivel "MenúPrincipal"
    public Button salirNivel;
    Button salirNiv;
    //Botones del menú
    public Button inicio;
    Button inicioJuego;
    public Button creditosBut;
    Button creditoBut;

    // Use this for initialization
    void Start() {
        instance = this;
        panelFin.SetActive(false);
        panelReset.SetActive(false);
        botonRes = resetBut.GetComponent<Button>();
        salirNiv = salirNivel.GetComponent<Button>();
        inicioJuego = inicio.GetComponent<Button>();
        player = GetComponent<PlayerControlle>();
    }

    // Update is called once per frame
    void Update() {
        UpdateGUI();
    }

    //Actualiza el GUI cada vez que es llamado
    void UpdateGUI() {
        textoJoyasMano.text = "JOYAS RESTANTES:" + joyasLaberinto;
        textoEnergia.text = "ENERGÍA: " + player.energia;
    }

    //Se activa cuando el jugador sale del laberinto
    public void Salida() {
        //Desactivamos el playercontroller
        player.enabled = !player.enabled;
        //Comprobamos el número de joyas que lleva el jugador
        if (player.joyasMano > 0)
            joyasLaberinto -= player.joyasMano;
        
        //Si las joyas del laberinto son 0, activamos el panel que termina el juego
        if (joyasLaberinto == 0)
        {
            panelFin.SetActive (true);
            salirNiv.onClick.AddListener(CargaMenu);
        }

        //Si no, activamos el panel que nos permite reiniciar
        else
            EntramosOtraVez();
    }

    //Método que controla cuando entramos de nuevo en el laberinto
    void EntramosOtraVez() {
        panelReset.SetActive (true);
        botonRes.onClick.AddListener(player.Reset);
    }

    //Activa el control del jugador
    public void ActivaJugador()
    {
        Debug.Log("Activado");
        if (player.enabled == false)
            player.enabled = !player.enabled;
    }
    
    //Cuando nos chocamos con el fantasma
    public void Muerte()
    {
        player.enabled = !player.enabled;
        panelFin.SetActive(true);
        final.text = "¡HAS PERDIDO!";
        salirNiv.onClick.AddListener(CargaMenu);
    }

    public void CargaMenu() {
        Application.LoadLevel("Menu");
    }

    public void CargaJuego() {
        Application.LoadLevel("Nivel1");
    }

}
