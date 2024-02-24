using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_manager : MonoBehaviour
{
    [SerializeField]
    private Sprite explosionSprite;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private AudioManager audioManager;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject gameController = GameObject.FindWithTag("GameController");
        audioManager = gameController.GetComponent<AudioManager>();
        _ = StartCoroutine(CountdownBomb());
    }

    private IEnumerator CountdownBomb()
    {
        yield return new WaitForSeconds(2f);
        _ = StartCoroutine(FlashSprite(5, 0.1f));
        yield return new WaitForSeconds(1f);
        audioManager.PlayExplosion();
        spriteRenderer.sprite = explosionSprite;
        transform.localScale = new Vector3(1.5f, 1.5f, 1f);

        yield return new WaitForSeconds(1f);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, 0.3f); // Adjust the radius as needed
        CheckCollidiers(colliders);
        Destroy(gameObject);
    }

    private IEnumerator FlashSprite(int numTimes, float delay)
    {
        for (int loop = 0; loop < numTimes; loop++)
        {
            spriteRenderer.color = new Color(
                spriteRenderer.color.r,
                spriteRenderer.color.g,
                spriteRenderer.color.b,
                0.5f
            );

            // delay specified amount
            yield return new WaitForSeconds(delay);

            // cycle through all sprites
            spriteRenderer.color = new Color(
                spriteRenderer.color.r,
                spriteRenderer.color.g,
                spriteRenderer.color.b,
                1
            );

            // delay specified amount
            yield return new WaitForSeconds(delay);
        }
    }

    private void CheckCollidiers(Collider2D[] collidiers)
    {
        foreach (Collider2D collider in collidiers)
        {
            if (collider.gameObject.CompareTag("tree"))
            {
                collider.GetComponent<TreeManager>().Bombed();
            }
            if (collider.CompareTag("soldier"))
            {
                collider.GetComponent<SoldierManager>().Bombed();
            }
        }
    }
}
