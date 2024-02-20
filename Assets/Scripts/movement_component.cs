using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    [SerializeField]
    private float VELOCITY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveUp()
    {
        gameObject.transform.position += new Vector3(0, VELOCITY, 0);
    }
    
    public void MoveDown()
    {
        gameObject.transform.position += new Vector3(0, -VELOCITY, 0);
    }

    public void MoveLeft()
    {
        gameObject.transform.position += new Vector3(-VELOCITY, 0, 0);
        Debug.Log(-VELOCITY);
    }

    public void MoveRight()
    {
        gameObject.transform.position += new Vector3(VELOCITY, 0, 0);
    }
}
