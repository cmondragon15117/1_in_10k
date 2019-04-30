using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderChange : MonoBehaviour
{
    public GameObject renderScreen;

    public void ScreenFade()
    {

        renderScreen.GetComponent<Animation>().Play("CrossFade");
    }
  
}
