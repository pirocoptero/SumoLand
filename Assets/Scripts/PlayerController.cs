 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public float powerUpStrength = 5f;
    public int lifeTimePowerUp = 10;
    public GameObject powerUpIndicator;
    public bool hasPowerUp = false;
    GameObject focalPoint;
    Rigidbody playerRb;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float fowardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * fowardInput * speed);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Powerup")){
            hasPowerUp = true;
            powerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDown());
        }
    }

    IEnumerator PowerUpCountDown() {
        yield return new WaitForSeconds(lifeTimePowerUp);        
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enemy") && hasPowerUp) {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 distanceFromEnemy = other.gameObject.transform.position - transform.position;

            enemyRb.AddForce(distanceFromEnemy * powerUpStrength, ForceMode.Impulse);

        }
    }
}
