using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private MovementComponent helicopterMovement;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    public float WAIT_TIME = 0.3f;

    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.R))
        {
            gameManager.Reset();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            gameManager.ToggleHelpMenu();
        }
        if (timer > WAIT_TIME)
        {
            timer = 0f;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                helicopterMovement.ThrustForward();
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                helicopterMovement.ThrustBackward();
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                helicopterMovement.RotateLeft();
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                helicopterMovement.RotateRight();
            }
        }
    }
}
