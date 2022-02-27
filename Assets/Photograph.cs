using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photograph : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ScreenCapture.CaptureScreenshot("path");
        }
    }
}
