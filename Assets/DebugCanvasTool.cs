using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class DebugCanvasTool : MonoBehaviour
{
    public MagicTileManager MagicTileManager;

    [SerializeField]
    private SpriteRenderer aimReticle;

    void Update()
    {
        if (Input.mousePresent) 
        {
            // Get mouse position in screen coordinates
            Vector3 screenPosition = Input.mousePosition;

            // Convert screen position to world position
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            worldPosition = new Vector3(Mathf.RoundToInt(worldPosition.x), Mathf.RoundToInt(worldPosition.y), 0);

            aimReticle.transform.position = worldPosition;
        }
        if (Input.GetMouseButtonDown(0)) // 0 is for left click
        {
            // Get mouse position in screen coordinates
            Vector3 screenPosition = Input.mousePosition;

            // Convert screen position to world position
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            worldPosition = new Vector3(Mathf.RoundToInt(worldPosition.x), Mathf.RoundToInt(worldPosition.y), 0);

            Debug.Log("World Position: " + worldPosition);

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    MagicTileManager.SpawnTile(worldPosition + new Vector3(i,j,0), true);
                }
            }

            MagicTileManager.RecalculateTiles();
        }
    }
}
