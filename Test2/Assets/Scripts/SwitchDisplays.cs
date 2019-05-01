using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchDisplays : MonoBehaviour {
    public Camera firstPersonCam;
    public Camera miniMapCam;
    public Camera introCam;
    public Camera exitCam;
    public Canvas introCanvas;
    public Canvas exitCanvas;

    void Start() {
      firstPersonCam.enabled = false;
      miniMapCam.enabled = false;
      introCam.enabled = true;
      exitCam.enabled = false;
      exitCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Return)) {
          Debug.Log("Changing views");

          if(introCam.enabled) {
            DisableMenu();
            firstPersonCam.enabled = true;
            miniMapCam.enabled = false;
            Turtlecontrol.mouseLocked = false;
          }

          else if(firstPersonCam.enabled) {
            firstPersonCam.enabled = false;
            miniMapCam.enabled = true;
            DisableMenu();
            Turtlecontrol.mouseLocked = true;
          }

          else if(miniMapCam.enabled) {
            EnableMenu();
            firstPersonCam.enabled = false;
            miniMapCam.enabled = false;
            Turtlecontrol.mouseLocked = true;
          }
          else {
            EnableMenu();
            firstPersonCam.enabled = false;
            miniMapCam.enabled = false;
          }
        }
    }

    void EnableMenu() {
      introCam.enabled = true;
      introCanvas.enabled = true;
    }
    void DisableMenu() {
      introCam.enabled = false;
      introCanvas.enabled = false;
    }
}
