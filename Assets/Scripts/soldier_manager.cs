using UnityEngine;

public class SoldierManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void PickUp()
    {
        if (gameManager.IncrementSoldiersPickedUp())
        {
            audioManager.PlayPickUpSound();
            Destroy(gameObject);
        }
    }
}
