using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public GameObject currentPlayer; // La instancia actual del jugador
    public GameObject[] playerPrefabs; // Agrega un array para almacenar los prefabs de los jugadores
    public Transform playerSpawnPoint; // Agrega una referencia al objeto "PlayerSpawnPoint"

    private void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName != "Menu" && currentSceneName != "Shop" && currentSceneName != "LevelSelect")
        {
            LoadSelectedPlayer();
        }
        
    }

    public void LoadSelectedPlayer()
    {
        int selectedIndex = PlayerPrefs.GetInt("selectedPrefabIndex", 0);
        GameObject[] existingPlayers = GameObject.FindGameObjectsWithTag("Player");

        if (existingPlayers.Length == 2)
        {
            // Elimina ambos jugadores y crea uno nuevo
            foreach (GameObject player in existingPlayers)
            {
                Destroy(player);
            }
            ChangePlayer(selectedIndex);
        }
        else if (existingPlayers.Length == 1)
        {
            for (int i = 0; i < playerPrefabs.Length; i++)
            {
                if (existingPlayers[0].name.StartsWith(playerPrefabs[i].name) && selectedIndex != i)
                {
                    ChangePlayer(selectedIndex);
                    return;
                }
            }
        }
        else
        {
            ChangePlayer(selectedIndex);
        }
    }

    public void ChangePlayer(int index)
    {
        // Si el índice está fuera del rango del array de prefabs, no hacer nada
        if (index < 0 || index >= playerPrefabs.Length)
        {
            Debug.LogWarning("El índice del jugador seleccionado está fuera del rango.");
            return;
        }

        // Destruir el jugador actual si existe
        if (currentPlayer != null)
        {
            Destroy(currentPlayer);
        }

        // Crear una nueva instancia del jugador seleccionado en la posición del objeto "PlayerSpawnPoint" y asignarla a currentPlayer
        currentPlayer = Instantiate(playerPrefabs[index], playerSpawnPoint.position, Quaternion.identity);
        DontDestroyOnLoad(currentPlayer); // Asegurar que el jugador no sea destruido al cargar nuevas escenas
    }
}
