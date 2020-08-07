using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Screenshotter : MonoBehaviour {
    private RenderTexture _renderTexture;

    void Update() {
        // Here we take screenshots when the player hits the S key, but it could
        // just as well have been a button click, time elapsing, or some other
        // condition.
        if (Input.GetKeyDown(KeyCode.S)) {
            TakeScreenshot();
        }
    }

    public void TakeScreenshot() {
        ScreenCapture.CaptureScreenshot($"Screenshots/screenshot_{Time.time}.png");

        Debug.Log("Screenshot saved.");
    }
}