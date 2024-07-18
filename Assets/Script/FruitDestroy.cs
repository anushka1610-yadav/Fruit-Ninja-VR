using UnityEngine;
using System.Collections;

public class FruitDestroy : MonoBehaviour
{
    public GameObject apple;
    public GameObject coconut;
    public GameObject banana;
    public GameObject greenApple;

    private Animator animator; // Assign the Animator component in the Inspector
    public float destroyDelay = 2f; // Time to wait before destroying the fruit
    public float moveSpeed = 0.01f; // Speed at which the objects will move downwards
    private GameObject fruitSelected;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the other object is one of the instantiated objects
        if (other.CompareTag("fruit-apple"))
        {
            fruitSelected = apple;
            StartCoroutine(AnimateAndDestroyFruit(other.gameObject));
        }
        else if (other.CompareTag("fruit-banana"))
        {
            fruitSelected = banana;
            StartCoroutine(AnimateAndDestroyFruit(other.gameObject));
        }
        else if (other.CompareTag("fruit-coconut"))
        {
            fruitSelected = coconut;
            StartCoroutine(AnimateAndDestroyFruit(other.gameObject));
        }
        else if (other.CompareTag("fruit-greenApple"))
        {
            fruitSelected = greenApple;
            StartCoroutine(AnimateAndDestroyFruit(other.gameObject));
        }
    }

    private IEnumerator AnimateAndDestroyFruit(GameObject obj)
    {
        //        // Optionally, add some physics to the halves
        //        Rigidbody rb1 = half1.GetComponent<Rigidbody>();
        //        Rigidbody rb2 = half2.GetComponent<Rigidbody>();

        //        if (rb1 != null && rb2 != null)
        //        {
        //            rb1.AddForce(Vector3.left * 2, ForceMode.Impulse);
        //            rb2.AddForce(Vector3.right * 2, ForceMode.Impulse);
        //        }

        Debug.Log(obj.name);
        //if(obj.name == "apple_whole(Clone)")
        //{
        //    fruitSelected = apple;
        //}
        //else if (obj.name == "Coconut_whole(Clone)")
        //{
        //    fruitSelected = coconut;
        //}
        //else if (obj.name == "Banana_whole(Clone)")
        //{
        //    fruitSelected = banana;
        //}
        //else if (obj.name == "GreenApple_whole(Clone)")
        //{
        //    fruitSelected = greenApple;
        //}
        // Get the position and rotation of the original object
        Vector3 position = obj.transform.position;
        Quaternion rotation = obj.transform.rotation;

        // Deactivate the original object
        obj.SetActive(false);

        // Instantiate the two halves at the same position with a slight offset
        GameObject fruit = Instantiate(fruitSelected, position + new Vector3(0.01f, 0, 0), rotation);
        animator = fruit.GetComponent<Animator>();

        // Play the animation for splitting and falling
        animator.SetTrigger("Split");

        // Wait for the animation to complete
        yield return new WaitForSeconds(destroyDelay);

        // Move the object down
        //Vector3 endPosition = new Vector3(obj.transform.position.x, 0.2f, obj.transform.position.z); // End position on the plane
        //while (obj.transform.position.y > endPosition.y)
        //{
        //    obj.transform.position = Vector3.MoveTowards(obj.transform.position, endPosition, moveSpeed);
        //    yield return null;
        //}

        //// Wait for the specified delay before destroying the object
        //yield return new WaitForSeconds(destroyDelay);

        // Destroy the fruit object
        Destroy(fruit);
    }
}


//using UnityEngine;
//using System.Collections;

//public class FruitDestroy : MonoBehaviour
//{
//    public GameObject fruitHalf1; // Assign the first half prefab in the Inspector
//    public GameObject fruitHalf2; // Assign the second half prefab in the Inspector
//    public float destroyDelay = 2f; // Time to wait before destroying the halves
//    public float moveSpeed = 0.01f; // Speed at which the objects will move downwards

//    private void OnTriggerEnter(Collider other)
//    {
//        // Check if the other object is one of the instantiated objects
//        if (other.CompareTag("InstantiatedObject"))
//        {
//            StartCoroutine(CutFruit(other.gameObject));
//        }
//    }

//    private IEnumerator CutFruit(GameObject obj)
//    {
//        Debug.Log(obj.name);
//        // Get the position and rotation of the original object
//        Vector3 position = obj.transform.position;
//        Quaternion rotation = obj.transform.rotation;

//        // Deactivate the original object
//        obj.SetActive(false);

//        // Instantiate the two halves at the same position with a slight offset
//        GameObject half1 = Instantiate(fruitHalf1, position + new Vector3(0.5f, 0, 0), rotation);
//        GameObject half2 = Instantiate(fruitHalf2, position - new Vector3(0.5f, 0, 0), rotation);

//        // Optionally, add some physics to the halves
//        Rigidbody rb1 = half1.GetComponent<Rigidbody>();
//        Rigidbody rb2 = half2.GetComponent<Rigidbody>();

//        if (rb1 != null && rb2 != null)
//        {
//            rb1.AddForce(Vector3.left * 2, ForceMode.Impulse);
//            rb2.AddForce(Vector3.right * 2, ForceMode.Impulse);
//        }

//        // Move down
//        Vector3 endPosition1 = new Vector3(half1.transform.position.x, (float)0.2, half1.transform.position.z); // End position on the plane
//        Vector3 endPosition2 = new Vector3(half2.transform.position.x, (float)0.2, half2.transform.position.z); // End position on the plane
//        while (half1.transform.position.y > endPosition1.y && half2.transform.position.y > endPosition2.y)
//        {
//            //instantiatedObject.transform.position = Vector3.MoveTowards(instantiatedObject.transform.position, endPosition, moveSpeed);
//            half1.transform.position = Vector3.MoveTowards(half1.transform.position, endPosition1, moveSpeed);
//            half2.transform.position = Vector3.MoveTowards(half2.transform.position, endPosition2, moveSpeed);
//            yield return null;
//        }

//        // Wait for the specified delay
//        yield return new WaitForSeconds(destroyDelay);

//        // Destroy the halves
//        Destroy(half1);
//        Destroy(half2);

//        // Optionally, destroy the original object (if it was not just deactivated)
//        Destroy(obj);
//    }
//}





//using UnityEngine;
//using System.Collections;

//public class FruitDestroy : MonoBehaviour
//{
//    private void OnTriggerEnter(Collider other)
//    {
//        // Check if the other object is one of the instantiated objects
//        if (other.CompareTag("InstantiatedObject"))
//        {
//            StartCoroutine(DestroyAfterDelay(other.gameObject));
//        }
//    }

//    private IEnumerator DestroyAfterDelay(GameObject obj)
//    {
//        yield return null; // Wait for 1 second
//        Destroy(obj);
//    }
//}
