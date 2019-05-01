using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Finish : MonoBehaviour
{
    Rigidbody rb;
    public Camera firstPersonCam;
    public Camera miniMapCam;
    public Camera introCam;
    public Camera exitCam;
    public Canvas introCanvas;
    public Canvas exitCanvas;
    public GameObject turtle;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      if(Turtlecontrol.lose) {
        EndGame();
        loseText.enabled = true;
        winText.enabled = false;
      }
    }
    private void OnTriggerEnter(Collider other) {
      Debug.Log("turtle had reached its destination");

    }
    private void OnCollisionEnter(Collision collision) {
      if(collision.gameObject.tag == "Turtle" || collision.gameObject == turtle) {
        Debug.Log("turtle had reached its destination");
        EndGame();
        winText.enabled = true;
        loseText.enabled = false;
      }
    }

    public void EndGame() {
      firstPersonCam.enabled = false;
      miniMapCam.enabled = false;
      introCam.enabled = false;
      introCanvas.enabled = false;
      exitCam.enabled = true;
      exitCanvas.enabled = true;
    }
}
