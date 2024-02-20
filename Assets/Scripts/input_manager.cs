using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private MovementComponent helicopterMovement;

    [SerializeField]
    public float WAIT_TIME = 0.3f;

    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > WAIT_TIME)
        {
            
            timer = 0f;
            if (Input.GetKey(KeyCode.UpArrow)) {
                // TODO: Move heli up
                helicopterMovement.MoveUp();
            }
            if (Input.GetKey(KeyCode.DownArrow)) {
                // TODO: Move heli down
                helicopterMovement.MoveDown();
            }
            if (Input.GetKey(KeyCode.LeftArrow)) {
                // TODO: Move heli left
                helicopterMovement.MoveLeft();
            }
            if (Input.GetKey(KeyCode.RightArrow)) {
                // TODO: Move heli right
                helicopterMovement.MoveRight();
            }
            if (Input.GetKeyDown(KeyCode.R)) {
                // TODO: Reset game if possible
            }
        }
    }
}
