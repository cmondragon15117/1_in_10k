using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDisplays : MonoBehaviour
{
    //public Camera firstPersonCam;
    //public Camera miniMapCam;
    public int activeDisplay;

    void Start()
    {
      RenderSettings.fogColor = Camera.main.backgroundColor;
      RenderSettings.fogDensity = 0.01f;
        //RenderSettings.fog = true;
        //firstPersonCam.enabled = true;
        //miniMapCam.enabled = false;
        Display.displays[0].Activate();
        activeDisplay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)) {

            //Debug.Log("Changing views");
            //if(firstPersonCam.enabled) {
            //  firstPersonCam.enabled = false;
            //  miniMapCam.enabled = true;
            //  ChangeFog();
            //}
            //else { //means firstPersonCam is disabled
            //  firstPersonCam.enabled = true;
            //  miniMapCam.enabled = false;
            //  ChangeFog();
            //}

            if (activeDisplay == 0)
            {
                Display.displays[1].Activate();
                activeDisplay = 1;
            }
            if (activeDisplay == 1)
            {
                Display.displays[2].Activate();
                activeDisplay = 2;
            }
            if (activeDisplay == 2)
            {
                Display.displays[0].Activate();
                activeDisplay = 0;
            }
        }
    }

    void ChangeFog() {
      // if(RenderSettings.fog)
      //   RenderSettings.fog = false;
      // else
      //   RenderSettings.fog = true;
    }
}
