using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldRenderer : MonoBehaviour
{
    public Tilemap groundTilemap;

    public void SetGroundTile(int x, int y, TileBase tile)
    {
        groundTilemap.SetTile(groundTilemap.WorldToCell(new Vector3Int(x, y, 0)), tile);
    }
    public void ClearGroundTilemap()
    {
        groundTilemap.ClearAllTiles();
    }

}
