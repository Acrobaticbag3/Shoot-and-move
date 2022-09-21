using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    float speed = 2f;
    float sprint = 8f;

    public GameObject Bullet;
    public float BulletSpeed = 100f;
    private bool _isShooting;
    void Start() {
        
    }

    void Update() {
        _isShooting |= Input.GetMouseButtonDown(0);

        if(Input.GetKey(KeyCode.W)) {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)){
            transform.position += transform.forward * sprint * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S)) {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D)) {
            transform.Rotate(0, 0.5f, 0);
        }
        if(Input.GetKey(KeyCode.A)) {
            transform.Rotate(0, -0.5f, 0);
        }
    }

    void FixedUpdate() {

    if (_isShooting) {

        GameObject newBullet = Instantiate(Bullet,
            this.transform.position + new Vector3(1, 0, 0),
            this.transform.rotation);

            Rigidbody BulletRB =
            newBullet.GetComponent<Rigidbody>();

            BulletRB.velocity = this.transform.forward *
            BulletSpeed;
        }
        _isShooting = false;
    }
}
