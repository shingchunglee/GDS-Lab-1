using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_component : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("soldier"))
        {
            Debug.Log("Collided with soldier");
        }
        if (other.gameObject.CompareTag("tree"))
        {
            Debug.Log("Collided with tree");
        }
    }
}
