using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDisplays : MonoBehaviour {
    public Camera firstPersonCam;
    public Camera miniMapCam;
    public Camera menuCam;

    void Start() {
      firstPersonCam.enabled = false;
      miniMapCam.enabled = false;
      menuCam.enabled = true;
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Return)) {
          Debug.Log("Changing views");

          if(menuCam.enabled) {
            DisableMenu();
            firstPersonCam.enabled = true;
            miniMapCam.enabled = false;
          }

          else if(firstPersonCam.enabled) {
            firstPersonCam.enabled = false;
            miniMapCam.enabled = true;
            DisableMenu();
          }

          else if(miniMapCam.enabled) {
            EnableMenu();
            firstPersonCam.enabled = false;
            miniMapCam.enabled = false;
          }
          else {
            EnableMenu();
            firstPersonCam.enabled = false;
            miniMapCam.enabled = false;
          }
        }
    }

    void EnableMenu() {
      menuCam.enabled = true;
    }
    void DisableMenu() {
      menuCam.enabled = false;
    }
}
