using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    // Static instance of ResourceManager which allows it to be accessed by any other script.
    public static ResourceManager Instance { get; private set; }

    // Variable to store resources
    public int WaterResources;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // If there is already an instance of ResourceManager, destroy the new one
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // Make this the singleton instance
            Instance = this;
            // Set this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);
        }
    }
}