using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameObject[] objectsToInstantiate; // Array to hold different prefabs to instantiate
    public Vector3[] points; // Array to hold the possible points
    public float moveSpeed = 0.01f; // Speed at which the objects will move downwards
    public float randomInterval = 1f;

    void Start()
    {
        if (points.Length > 0 && objectsToInstantiate.Length > 0)
        {
            StartCoroutine(InstantiateRandomly());
        }
        else
        {
            Debug.LogError("Please assign at least one point and one object in the inspector.");
        }
    }

    IEnumerator InstantiateRandomly()
    {
        while (true)
        {
            Vector3 randomPoint = points[Random.Range(0, points.Length)]; // Random point from the array
            GameObject randomObject = objectsToInstantiate[Random.Range(0, objectsToInstantiate.Length)]; // Random object from the array
            StartCoroutine(InstantiateAndMove(randomObject, randomPoint));
            yield return new WaitForSeconds(randomInterval);
        }
    }

    IEnumerator InstantiateAndMove(GameObject objectToInstantiate, Vector3 targetPosition)
    {
        Vector3 startPosition = new Vector3(targetPosition.x, 1, targetPosition.z); // Start position below the plane
        GameObject instantiatedObject = Instantiate(objectToInstantiate, startPosition, Quaternion.identity);

        // Ensure the object has a collider and a kinematic rigidbody
        if (instantiatedObject.GetComponent<Collider>() == null)
        {
            instantiatedObject.AddComponent<BoxCollider>(); // Add a BoxCollider if none exists
        }
        if (instantiatedObject.GetComponent<Rigidbody>() == null)
        {
            Rigidbody rb = instantiatedObject.AddComponent<Rigidbody>();
            rb.isKinematic = true; // Make it kinematic so it only moves through the script
        }

        // Move up to the specified height
        while (instantiatedObject.transform.position.y < targetPosition.y)
        {
            instantiatedObject.transform.position = Vector3.MoveTowards(instantiatedObject.transform.position, targetPosition, moveSpeed);
            yield return null;
        }

        instantiatedObject.transform.position = targetPosition; // Ensure it reaches the target position
        //yield return new WaitForSeconds(2f); // Wait for 2 seconds

        // Move down
        Vector3 endPosition = new Vector3(targetPosition.x, (float)0.2, targetPosition.z); // End position on the plane
        while (instantiatedObject != null && instantiatedObject.transform.position.y > endPosition.y)
        {
            instantiatedObject.transform.position = Vector3.MoveTowards(instantiatedObject.transform.position, endPosition, moveSpeed);
            yield return null;
        }
        if(instantiatedObject != null)
        {
            instantiatedObject.transform.position = endPosition; // Ensure it reaches the end position
            yield return new WaitForSeconds(0.5f);
            Destroy(instantiatedObject); // Destroy the object after 1 second
        }

    }
}





//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GameScript : MonoBehaviour
//{
//    public GameObject[] objectsToInstantiate; // Array to hold different prefabs to instantiate
//    public Vector3[] points; // Array to hold the possible points
//    public float moveSpeed = 0.01f; // Speed at which the objects will move downwards
//    public float randomInterval = 1f;

//    void Start()
//    {
//        if (points.Length > 0 && objectsToInstantiate.Length > 0)
//        {
//            StartCoroutine(InstantiateRandomly());
//        }
//        else
//        {
//            Debug.LogError("Please assign at least one point and one object in the inspector.");
//        }
//    }

//    IEnumerator InstantiateRandomly()
//    {
//        while (true)
//        {
//            Vector3 randomPoint = points[Random.Range(0, points.Length)]; // Random point from the array
//            GameObject randomObject = objectsToInstantiate[Random.Range(0, objectsToInstantiate.Length)]; // Random object from the array
//            StartCoroutine(InstantiateAndMove(randomObject, randomPoint));
//            yield return new WaitForSeconds(randomInterval);
//        }
//    }

//    IEnumerator InstantiateAndMove(GameObject objectToInstantiate, Vector3 targetPosition)
//    {
//        Vector3 startPosition = new Vector3(targetPosition.x, 1, targetPosition.z); // Start position below the plane
//        GameObject instantiatedObject = Instantiate(objectToInstantiate, startPosition, Quaternion.identity);

//        // Move up to the specified height
//        while (instantiatedObject.transform.position.y < targetPosition.y)
//        {
//            instantiatedObject.transform.position = Vector3.MoveTowards(instantiatedObject.transform.position, targetPosition, moveSpeed);
//            yield return null;
//        }

//        instantiatedObject.transform.position = targetPosition; // Ensure it reaches the target position
//        yield return new WaitForSeconds(2f); // Wait for 2 seconds

//        // Move down
//        Vector3 endPosition = new Vector3(targetPosition.x, 0, targetPosition.z); // End position below the plane
//        while (instantiatedObject.transform.position.y > endPosition.y)
//        {
//            instantiatedObject.transform.position = Vector3.MoveTowards(instantiatedObject.transform.position, endPosition, moveSpeed);
//            yield return null;
//        }

//        Destroy(instantiatedObject); // Destroy the object when it reaches the end position
//    }
//}