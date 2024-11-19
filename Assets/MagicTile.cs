using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTile : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float timeToLive;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeTile(float _angle, Sprite sprite)
    {
        try
        {
            transform.eulerAngles = new Vector3(0, 0, _angle);
            spriteRenderer.sprite = sprite;
        }
        catch (Exception e)
        {
            Debug.LogError("Error: " + e);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.name == "JumpDetector")
        {
            Debug.Log("WHAT");
        }        
    }

    private void OnDestroy()
    {
        FindAnyObjectByType<MagicTileManager>().allTiles.Remove(this);
    }
}
