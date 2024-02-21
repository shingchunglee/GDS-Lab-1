using UnityEngine;

public class HelicopterCollisionComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("soldier"))
        {
            other.gameObject.GetComponent<SoldierManager>().PickUp();
            return;
        }
        if (other.gameObject.CompareTag("tree"))
        {
            Debug.Log("Collided with tree");
            return;
        }
        if (other.gameObject.CompareTag("hospital"))
        {
            Debug.Log("Collided with hospital");
            return;
        }
    }
}
