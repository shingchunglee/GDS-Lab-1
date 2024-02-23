using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    [SerializeField]
    private float ACCELERATION;

    private float velocity;

    [SerializeField]
    private float TERMINAL_VELOCITY;

    [SerializeField]
    private float MAX_ROTATION;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * velocity;
        velocity *= .98f;
        if (Mathf.Abs(velocity) < 0.005f)
        {
            velocity = 0;
        }
    }

    public void ThrustForward()
    {
        if (Mathf.Abs(velocity) < TERMINAL_VELOCITY)
        {
            velocity = ACCELERATION * Time.deltaTime;
        }
    }

    public void ThrustBackward()
    {
        if (Mathf.Abs(velocity) > -TERMINAL_VELOCITY)
        {
            velocity = -ACCELERATION * Time.deltaTime;
        }
    }

    public void RotateLeft()
    {
        if (transform.rotation.z < MAX_ROTATION)
        {
            transform.Rotate(0, 0, 15);
        }
    }

    public void RotateRight()
    {
        if (transform.rotation.z > -MAX_ROTATION)
        {
            transform.Rotate(0, 0, -15);
        }
    }

    /* public void MoveUp() */
    /* { */
    /*     gameObject.transform.position += new Vector3(0, velocity, 0); */
    /* } */
    /**/
    /* public void MoveDown() */
    /* { */
    /*     gameObject.transform.position += new Vector3(0, -velocity, 0); */
    /* } */
    /**/
    /* public void MoveLeft() */
    /* { */
    /*     gameObject.transform.position += new Vector3(-velocity, 0, 0); */
    /* } */
    /**/
    /* public void MoveRight() */
    /* { */
    /*     gameObject.transform.position += new Vector3(velocity, 0, 0); */
    /* } */
}
