using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutFruits : MonoBehaviour
{
    //public GameObject fruit; // Reference to the fruit object

    // This method is called when another collider enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered the trigger is tagged as "Player" (or any other tag you want)
        if (other.CompareTag("Player"))
        {
            // Destroy the fruit
            Destroy(gameObject);
        }
    }
}
