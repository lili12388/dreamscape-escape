using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Notify the player that they picked up the key
            Debug.Log("Key picked up!");
            Destroy(gameObject); // Destroy the key object
        }
    }
}