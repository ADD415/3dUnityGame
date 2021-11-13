using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{

    [Header("Pausing")]
    public bool paused;
    public Slider fovSlider;
    public Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        // When game is paused use a slider to change the fov of the camera.
        fovSlider.gameObject.SetActive(false);
        paused = false; 
        cam.fieldOfView = fovSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        // If player presses pause key and paused is false
        if (Input.GetKeyDown(KeyCode.P) && !paused)
        {
            Time.timeScale = 0; // Set time.timescale to 0
            paused = !paused; // Flip the pause bool
           
            
            Cursor.lockState = CursorLockMode.None; // Cursor control
            fovSlider.gameObject.SetActive(true); // Activate slider
            return; // Return from script
        }

        // If player presses pause key and paused is true
        if (Input.GetKeyDown(KeyCode.P) && paused)
        {
            Time.timeScale = 1; // Set time.timescale to 1
            paused = !paused; // Flip the pause bool

            
            fovSlider.gameObject.SetActive(false); // Silder cannot be accessed
            Cursor.lockState = CursorLockMode.Locked; // Removes cursor control
            
        }
        
        cam.fieldOfView = fovSlider.value; // Assigns the cameras fov to that of the value of the slider.
    }
}
