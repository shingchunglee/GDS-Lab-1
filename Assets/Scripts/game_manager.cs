using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int soldiers_picked_up = 0;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public bool IncrementSoldiersPickedUp()
    {
        if (soldiers_picked_up >= 3)
        {
            return false;
        }
        soldiers_picked_up++;
        return true;
    }
}
