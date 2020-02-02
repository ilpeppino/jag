using UnityEngine;

public class Net : MonoBehaviour
{

    [SerializeField] float pushBackForce = 100f;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody objCollided = other.gameObject.GetComponent<Rigidbody>();
        Debug.Log(objCollided.name + " hit the net");

        var xPos = objCollided.transform.position.x - transform.position.x;
        var zPos = objCollided.transform.position.z - transform.position.z;
        Vector3 offset = new Vector3(xPos, 0f, zPos).normalized;

        //objCollided.AddForce(offset  * Time.deltaTime);
        Debug.Log("Offset : " + offset * pushBackForce * Time.deltaTime);
        objCollided.transform.Translate(offset *pushBackForce * Time.deltaTime);
    }

}
