 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public WorldRenderer worldRenderer;
    public BlockData blockData;

    public int mapLength = 50;
    public float amplitude = 1;
    public float frequency = 0.01f;

    private void Start()
    {
        GenerateMap1DNoise();
    }
    private float GetNoiseValue(int x, int y)
    {
        return amplitude * Mathf.PerlinNoise(x * frequency, y * frequency);
    }

    public void GenerateMap1DNoise()
    {
        worldRenderer.ClearGroundTilemap();
        for (int x = 0; x < mapLength; x++)
        {
            var noise = GetNoiseValue(x, 1);
            var yCoordinate = Mathf.FloorToInt(noise);
            for (int y = 0; y <= yCoordinate; y++)
            {
                worldRenderer.SetGroundTile(x, y, blockData.dirtTile);
            }
        }
    }
}
