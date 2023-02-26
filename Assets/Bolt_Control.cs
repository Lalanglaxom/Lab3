using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt_Control : MonoBehaviour
{
    public float speed = 10f;

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1 * speed); 
    }

    private void OnCollisionEnter(Collision other) {
        Destroy(this.gameObject);
    }
}
