using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float speed = 5f;

    public GameObject bullet;
    public Transform boltPos;

    private float shotTimer = 0;

    public GameObject player_explosion;

    private void FixedUpdate() {
        
        // Move rigidbody
        var hoz = Input.GetAxis("Horizontal");
        var ver = Input.GetAxis("Vertical");

        GetComponent<Rigidbody>().velocity = new Vector3(hoz,0,ver) * speed;

        // Clamp play zone
        var pos = transform.position;
        pos.x =  Mathf.Clamp(transform.position.x, -4.76f, 4.76f);
        pos.z =  Mathf.Clamp(transform.position.z, -7.32f, 7.16f);
        transform.position = pos;

        // Rotate player
        Quaternion rotation = Quaternion.Euler(0, 0, -hoz * 30);
        transform.rotation = rotation;
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Space) && shotTimer <= 0) {
            Instantiate(bullet, boltPos.position, boltPos.rotation);
            shotTimer = 0.5f;
        }
        
        if(shotTimer > 0) {
            shotTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision other) {
            Instantiate(player_explosion, transform.position, transform.rotation);
            this.gameObject.SetActive(false);
    }

}