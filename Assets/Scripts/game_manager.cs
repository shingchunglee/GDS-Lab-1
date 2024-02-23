using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int soldiers_picked_up = 0;
    public int soldiers_saved = 0;

    private bool game_over = false;
    private bool win = false;

    private bool showHelp = false;

    private const int SOLDERS_TO_SPAWN = 10;
    private const int TREES_TO_SPAWN = 5;

    [SerializeField]
    private Bounds playableAreaBounds;

    [SerializeField]
    private GameObject helicopter;

    [SerializeField]
    private GameObject soldier_prefab;

    [SerializeField]
    private GameObject tree_prefab;

    [SerializeField]
    private Text rescued_text;

    [SerializeField]
    private Text soldiers_in_helicopter_text;

    [SerializeField]
    private Text help_text;

    [SerializeField]
    private Canvas game_over_canvas;

    [SerializeField]
    private Canvas win_canvas;

    private void Start()
    {
        InitGame();
    }

    private void Update()
    {
        CheckGameWin();
    }

    private void InitGame()
    {
        win_canvas.gameObject.SetActive(false);
        game_over_canvas.gameObject.SetActive(false);

        soldiers_picked_up = 0;
        soldiers_saved = 0;
        ResetHelicopterPosition();
        SpawnSoldiers();
        SpawnTrees();
        UpdateRescuedText();
        UpdateSoldiersInHelicopterText();

        game_over = false;
        win = false;
        Time.timeScale = 1;
    }

    private void ResetHelicopterPosition()
    {
        helicopter.transform.position = new Vector3(-2f, 0, 0);
    }

    private void SpawnSoldiers()
    {
        ClearSoldiers();
        int solders_spawned = 0;
        while (solders_spawned < SOLDERS_TO_SPAWN)
        {
            Vector3 randomPosition = GetRandomPositionWithinBounds(playableAreaBounds);

            // Check for collisions
            if (!IsColliding(randomPosition))
            {
                // Spawn the object at the random position
                _ = Instantiate(soldier_prefab, randomPosition, Quaternion.identity);
                solders_spawned++;
            }
        }
    }

    private void SpawnTrees()
    {
        ClearTrees();
        int trees_spawned = 0;
        while (trees_spawned < TREES_TO_SPAWN)
        {
            Vector3 randomPosition = GetRandomPositionWithinBounds(playableAreaBounds);

            // Check for collisions
            if (!IsColliding(randomPosition))
            {
                // Spawn the object at the random position
                _ = Instantiate(tree_prefab, randomPosition, Quaternion.identity);
                trees_spawned++;
            }
        }
    }

    private void ClearTrees()
    {
        GameObject[] trees = GameObject.FindGameObjectsWithTag("tree");
        foreach (GameObject tree in trees)
        {
            Destroy(tree);
        }
    }

    private bool IsColliding(Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.1f); // Adjust the radius as needed
        Debug.Log(colliders.Length > 0);
        return colliders.Length > 0;
    }

    private Vector3 GetRandomPositionWithinBounds(Bounds bounds)
    {
        float randomX = UnityEngine.Random.Range(bounds.min.x, bounds.max.x);
        float randomY = UnityEngine.Random.Range(bounds.min.y, bounds.max.y);
        return new Vector3(randomX, randomY, 0);
    }

    private void ClearSoldiers()
    {
        GameObject[] soldiers = GameObject.FindGameObjectsWithTag("soldier");
        foreach (GameObject soldier in soldiers)
        {
            Destroy(soldier);
        }
    }

    public void GameOver()
    {
        game_over_canvas.gameObject.SetActive(true);
        game_over = true;
        Time.timeScale = 0;
    }

    public void Reset()
    {
        if (game_over || win)
        {
            InitGame();
        }
    }

    private void CheckGameWin()
    {
        if (game_over || win)
        {
            return;
        }
        if (GameObject.FindWithTag("soldier") == null && soldiers_picked_up == 0)
        {
            win_canvas.gameObject.SetActive(true);
            win = true;
            Time.timeScale = 0;
        }
    }

    public bool IncrementSoldiersPickedUp()
    {
        if (soldiers_picked_up >= 3)
        {
            return false;
        }
        soldiers_picked_up++;
        UpdateSoldiersInHelicopterText();
        return true;
    }

    public bool EmptyHelicopter()
    {
        soldiers_saved += soldiers_picked_up;
        soldiers_picked_up = 0;
        UpdateRescuedText();
        UpdateSoldiersInHelicopterText();
        return true;
    }

    private void UpdateRescuedText()
    {
        rescued_text.text = "Soldiers Rescued: " + soldiers_saved;
    }

    private void UpdateSoldiersInHelicopterText()
    {
        soldiers_in_helicopter_text.text = "Soldiers in Helicopter: " + soldiers_picked_up;
    }

    internal void ToggleHelpMenu()
    {
        if (showHelp == false)
        {
            help_text.text =
                "Press Left and Right arrow keys to tilt, press Up and Down to move forward/backward. Don't hit the trees and rescue all soldiers to win.";
            showHelp = true;
        }
        else
        {
            help_text.text = "Press \"H\" for help";
        }
    }
}
