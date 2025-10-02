using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CapsuleCollider))]
public class Portail : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // The name of the scene to load
    [SerializeField] private KeyCode activationKey = KeyCode.E; // Key to activate the portal

    private bool playerInRange = false;

    private void Start()
    {
        // Ensure the Capsule Collider is set as a trigger
        CapsuleCollider capsuleCollider = GetComponent<CapsuleCollider>();
        capsuleCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the portal's trigger zone
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the portal's trigger zone
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        // Check if the player is in range and presses the activation key
        if (playerInRange && Input.GetKeyDown(activationKey))
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        // Load the specified scene
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene to load is not set in the inspector!");
        }
    }
}