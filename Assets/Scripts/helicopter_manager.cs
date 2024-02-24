using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterManager : MonoBehaviour
{
    [SerializeField]
    private GameObject bombPrefab;

    public void SpawnBomb()
    {
        if (GameObject.FindWithTag("bomb") == null)
        {
            _ = Instantiate(bombPrefab, gameObject.transform.position, Quaternion.identity);
        }
    }
}
