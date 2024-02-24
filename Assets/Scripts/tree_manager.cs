using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameController = GameObject.FindWithTag("GameController");
        gameManager = gameController.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update() { }

    public void OnHitTree()
    {
        gameManager.GameOver();
    }

    public void Bombed()
    {
        Destroy(gameObject);
    }
}
