using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    // 1.1. Configuración de Hazards
    public GameObject[] hazards;
    public int hazardCount;
    
    // 1.2. Parámetros de Posicionamiento (Manuales para Y y Offset)
   private float spawnHeightY=0; // Altura fija (Y) para el nivel
    public float zOffset = 2.0f; // El margen extra para spawnear fuera (-2.0f en tu caso)

    // 1.3. Tiempos de Spawning
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private bool stopSpawning = false;
    private float xRange; 
    private float zSpawnPoint; 

    void Start()
    {
        CalcularLimitesDePantalla();
        StartCoroutine(SpawnWaves());
    }

    // 1.4. Lógica de cálculo automático
    void CalcularLimitesDePantalla()
    {
        // Calculamos la distancia desde la cámara hasta el plano de spawn
        float distanceToCamera = Mathf.Abs(Camera.main.transform.position.y - spawnHeightY);

        // Esquina superior derecha del Viewport (1, 1) en coordenadas 0 a 1
        Vector3 viewportCorner = new Vector3(1, 1, distanceToCamera);
        Vector3 worldCorner = Camera.main.ViewportToWorldPoint(viewportCorner);
        
        // Rango X: Borde derecho con un pequeño margen
        xRange = worldCorner.x - 0.5f;

        // Punto Z: Borde superior (worldCorner.z) más el offset solicitado
        zSpawnPoint = worldCorner.z + zOffset;
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (!stopSpawning)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                
                // Aplicamos los valores calculados dinámicamente
                Vector3 spawnPosition = new Vector3(
                    Random.Range(-xRange, xRange), 
                    spawnHeightY, 
                    zSpawnPoint
                );
                
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void StopSpawning()
    {
        stopSpawning = true;
    }
}