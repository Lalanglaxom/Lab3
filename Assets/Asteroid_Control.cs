using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Control : MonoBehaviour
{
    public float speed = 2f;
    public GameObject asteroid_explosion;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.value,Random.value,Random.value);
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void FixedUpdate() {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1 * speed);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "Bolt(Clone)") {
            gameManager.score += 1;
            Instantiate(asteroid_explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);
    }
}