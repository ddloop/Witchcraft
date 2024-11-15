using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDetector : MonoBehaviour
{
    [SerializeField]
    private WitchBehavior witchBehavior;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("MagicTile"))
        {
            witchBehavior.Jump();
        }
    }
}
