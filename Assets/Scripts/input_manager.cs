using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private MovementComponent helicopterMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            // TODO: Move heli up
            helicopterMovement.MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            // TODO: Move heli down
            helicopterMovement.MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            // TODO: Move heli left
            helicopterMovement.MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            // TODO: Move heli right
            helicopterMovement.MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            // TODO: Reset game if possible
        }
    }
}
