using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;

public class MagicTileManager : MonoBehaviour
{
    public List<MagicTile> allTiles;
    public List<TileData> tileDatas;

    public Sprite corner;
    public Sprite wall;
    public Sprite connector;
    public Sprite insidetile;

    [SerializeField]
    private GameObject tileReference;

    void Start()
    {
        //Add All scene tiles
        List<MagicTile> sceneTiles = (FindObjectsOfType(typeof(MagicTile)) as MagicTile[]).ToList();
        allTiles.AddRange(sceneTiles);

        // x, 1, x
        // 2, _, 4
        // x, 8, x

        //Fill necessary Data
        tileDatas.Add(new TileData() { id = new List<int> { 3 }, angle = 0, sprite = corner });
        tileDatas.Add(new TileData() { id = new List<int> { 7 }, angle = 0, sprite = wall });
        tileDatas.Add(new TileData() { id = new List<int> {  }, angle = 0, sprite = connector });

        tileDatas.Add(new TileData() { id = new List<int> { 10 }, angle = 90, sprite = corner });
        tileDatas.Add(new TileData() { id = new List<int> { 11 }, angle = 90, sprite = wall });
        tileDatas.Add(new TileData() { id = new List<int> {  }, angle = 90, sprite = connector });

        tileDatas.Add(new TileData() { id = new List<int> { 12 }, angle = 180, sprite = corner });
        tileDatas.Add(new TileData() { id = new List<int> { 14 }, angle = 180, sprite = wall });
        tileDatas.Add(new TileData() { id = new List<int> {  }, angle = 180, sprite = connector });

        tileDatas.Add(new TileData() { id = new List<int> { 5 }, angle = 270, sprite = corner });
        tileDatas.Add(new TileData() { id = new List<int> { 13 }, angle = 270, sprite = wall });
        tileDatas.Add(new TileData() { id = new List<int> {  }, angle = 270, sprite = connector });

        tileDatas.Add(new TileData() { id = new List<int> { 15 }, angle = 0, sprite = insidetile });


        //Initiate
        RecalculateTiles();
    }

    public void SpawnTile(Vector3 spawnPosition, bool debug = false)
    {
        //Check if can spawn tile
        if (debug)
        {
            if (TileExists(spawnPosition, 0, 0))
            {
                Debug.Log("Cant spawn tile, position taken");
                return;
            }
        }

        var newTile = Instantiate(tileReference, spawnPosition, tileReference.transform.rotation, null);
        allTiles.Add(newTile.GetComponent<MagicTile>());
        //RecalculateTiles();
    }

    public void RecalculateTiles()
    {
        foreach (var tile in allTiles)
        {
            int idValue = 0;
            int counterForPower = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if ((i+j)%2 != 0)
                    {
                        if (TileExists(tile.transform.position, -j, i)) idValue += (int)Mathf.Pow(2f, counterForPower);
                        counterForPower++;
                    }
                }
            }

            Debug.Log("Changing Tile: " + tile.name);
            var foundData = FindData(idValue);
            if (foundData.id == null)
                Debug.LogError(tile.transform.position);
            tile.ChangeTile(foundData.angle, foundData.sprite);
        }
    }

    bool TileExists(Vector2 currentPosition, float offsetX, float offsetY)
    {
        foreach (var tile in allTiles)
        {
            Vector3 newPosition = currentPosition + new Vector2(offsetX, offsetY);
            if (tile.transform.position == newPosition)
            {
                return true;
            }
        }

        return false;
    }

    TileData FindData(int _id)
    {
        foreach (var data in tileDatas)
        {
            if (data.id.Contains(_id))
                return data;
        }
        
        Debug.LogError("Tile Data not found: " + _id);
        return new TileData();
    }

    [System.Serializable]
    public struct TileData
    {
        public List<int> id;
        public float angle;
        public Sprite sprite;
    }
}
