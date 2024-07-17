using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other object is one of the instantiated objects
        if (other.CompareTag("InstantiatedObject"))
        {
            StartCoroutine(DestroyAfterDelay(other.gameObject));
        }
    }

    private IEnumerator DestroyAfterDelay(GameObject obj)
    {
        yield return new WaitForSeconds(5f); // Wait for 1 second
        Destroy(obj);
    }
}
