using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int soldiers_picked_up = 0;
    public int soldiers_saved = 0;

    private bool game_over = false;
    private bool win = false;

    [SerializeField]
    private GameObject helicopter;

    [SerializeField]
    private GameObject soldier_prefab;

    [SerializeField]
    private Text rescued_text;

    [SerializeField]
    private Text soldiers_in_helicopter_text;

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
        Instantiate(soldier_prefab);
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
}
