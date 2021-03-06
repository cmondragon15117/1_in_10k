using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turtlecontrol : MonoBehaviour
{
    Rigidbody rb;
    Transform t;
    public float speed = 25.0f;
    public float rotationSpeed = 90;
    public float force = 700f;
    public Transform splash;
    public AudioClip sound;
    public AudioSource source;
    private float x;
    private float y;
    private Vector3 rotateX;
    private Vector3 rotateY;
    private float health = 120f;
    public Slider healthBar;
    public static bool mouseLocked;
    public static bool lose;

    //private int counter = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
        splash.GetComponent<ParticleSystem>().enableEmission = false;
        rb.useGravity = true;
        healthBar.value = 1;
        mouseLocked = true;
        lose = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shark" || collision.gameObject.tag == "Octopus")
            health -= (Random.Range(15, 30));
        else if (collision.gameObject.tag == "BigShark")
            health -= (Random.Range(30, 40));
        else if (collision.gameObject.tag == "Fish")
        {
            health += (Random.Range(7, 15));
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Trash") {
            health -= (Random.Range(15, 20));
            Destroy(collision.gameObject);
        }
        Debug.Log(health);
    }

    private void OnTriggerEnter(Collider other)
    {
        source.PlayOneShot(sound);
        splash.GetComponent<ParticleSystem>().enableEmission = true;
        StartCoroutine(stop());
    }

    IEnumerator stop()
    {
        yield return new WaitForSeconds(1.0f);
        splash.GetComponent<ParticleSystem>().enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Basic WASD movement
        if (Input.GetKey(KeyCode.W))
            rb.velocity += this.transform.forward * speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.S))
            rb.velocity -= this.transform.forward * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
            t.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.A))
            t.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(t.up * force);
        if(!mouseLocked) {
          //Basic rotation using mouse axis
          y = Input.GetAxis("Mouse X");
          x = Input.GetAxis("Mouse Y");
          //Debug.Log(x + ":" + y);
          rotateX = new Vector3(x, 0, 0);
          rotateY = new Vector3(0, y * -1, 0);

          if(!(x > 180 || x < -180) && !(y > 270 || y < -270)) {
            transform.eulerAngles -= rotateX + rotateY;
          }
          else if(x > 180 || x < -180)
            transform.eulerAngles -= rotateY;
          else if(y > 270 || y < -270)
            transform.eulerAngles -= rotateX;
        }
        health -= 0.008f;

        healthBar.value = (health / 100);

        if(health < 0)
          lose = true;

    }
}
