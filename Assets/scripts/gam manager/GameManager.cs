using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   public string ButonRestart="Fire2",message="Press 'R' for Restart" ;
    // 1.1. Instancia Estática (Singleton)
    public static GameManager Instance { get; private set; }

    // 1.2. Referencias a otros Managers
    // Debes arrastrar los objetos que contienen estos scripts en el Inspector
    SpawnManager spawnManager;
    UIManager uiManager;

    // 1.3. Estado del Juego
    private bool isGameOver;
    private int score;

    void Awake()
    {
        Singleton();
        ConfigurarDependencias();
        Inicio();
    }

    void ConfigurarDependencias(){
        spawnManager = GameObject.FindObjectOfType<SpawnManager>();
        uiManager = GameObject.FindObjectOfType<UIManager>();
    }

    void Singleton(){
    if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Inicio(){
        isGameOver = false;
        score = 0;
        // Sincronizamos la UI al iniciar
        if (uiManager != null){
            uiManager.UpdateScoreDisplay(score);
        }
    }

    void Update(){
        // Control del reinicio
        if (isGameOver && Input.GetButton(ButonRestart)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // 1.4. Métodos Públicos (Accesibles vía GameManager.Instance)

    public void AddScore(int value)
    {
        if (isGameOver) return;

        score += value;
        
        // Delegamos la actualización visual al UIManager
        if (uiManager != null)
        {
            uiManager.UpdateScoreDisplay(score);
        }
    }

    public void TriggerGameOver(){

        string mensaje="Use buton "+ ButonRestart;

        if (isGameOver) return;

        isGameOver = true;

        // Ordenamos al SpawnManager que detenga las oleadas
        if (spawnManager != null)
        {
            spawnManager.StopSpawning();
        }

        // Ordenamos al UIManager que muestre los mensajes de fin de juego
        if (uiManager != null)
        {
            uiManager.ShowGameOver(mensaje);
        }
    }
}