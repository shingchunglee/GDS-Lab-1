using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class input_manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            // TODO: Move heli up
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            // TODO: Move heli down
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            // TODO: Move heli left
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            // TODO: Move heli right
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            // TODO: Reset game if possible
        }
    }
}
