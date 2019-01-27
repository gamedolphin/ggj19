using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TerrainConfig {
    public float minHeight;
    public float maxHeight;
    public GameObject prefab;
}

public class TerrainGenerator2 : MonoBehaviour
{
    [SerializeField] private List<TerrainConfig> terrainConfig;
    [SerializeField] private List<GameObject> treeList;
    [SerializeField] private Vector2 tileSize;
    [SerializeField] private int xSize;
    [SerializeField] private int ySize;
    [SerializeField] private float scale;
    [SerializeField] private int octaves;
    [SerializeField] private float persistance;
    [SerializeField] private float lacunarity;

    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;


    private int[,] types;

    private float[,] GetNoiseMap(int mapWidth, int mapHeight, float scale) {

        if(scale <= 0) scale = 0.01f;

        float[,] noiseMap = new float[mapWidth, mapHeight];

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        for (int i=0; i < mapHeight; ++i) {
            for (int j=0; j < mapWidth; ++j) {

                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for (int p=0; p < octaves; p++) {
                    float sampleX = i / scale * frequency;
                    float sampleY = j / scale * frequency;
                    float perlinValue = Mathf.PerlinNoise(sampleX + offsetX, sampleY + offsetY)*2 - 1 ;
                    noiseHeight += perlinValue * amplitude;
                    amplitude *= persistance;
                    frequency *= lacunarity;

                    if(noiseHeight > maxNoiseHeight) {
                        maxNoiseHeight = noiseHeight;
                    }
                    else  if(noiseHeight < minNoiseHeight) {
                        minNoiseHeight = noiseHeight;
                    }

                    noiseMap[i,j] = noiseHeight;
                }
            }
        }

        for (int i=0; i < mapHeight; ++i) {
            for (int j=0; j < mapWidth; ++j) {
                noiseMap[i,j] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[i,j]);
            }

        }
        return noiseMap;
    }

    public void GenerateTerrain() {
        int sizeX = xSize;
        int sizeY = ySize;
        var noiseMap = GetNoiseMap(sizeX,sizeY,scale);
        types = new int[sizeX, sizeY];
        var oldContainer = GameObject.Find("Container");
        if(oldContainer != null) {
            GameObject.DestroyImmediate(oldContainer);
        }
        var container = new GameObject("Container");
        for (int i=0; i < sizeX; ++i) {
            for (int j=0; j < sizeY; ++j) {
                var height = noiseMap[i,j];
                GameObject obj = null;
                for (int k=0; k < terrainConfig.Count; ++k) {
                    if(height > terrainConfig[k].minHeight &&
                       height < terrainConfig[k].maxHeight) {
                        obj = terrainConfig[k].prefab;
                        types[i,j] = k;
                        break;
                    }
                }
                if(obj == null) continue;
                var item = Instantiate(obj);
                item.transform.position = new Vector3(i*tileSize.x, 0, j*tileSize.y);
                item.transform.SetParent(container.transform);
            }
        }
        var collider = container.AddComponent<BoxCollider>();
        collider.size = new Vector3(sizeX, 2, sizeY);
        collider.center = new Vector3(sizeX/2, 0, sizeY/2);
    }

    public void PlaceTrees() {
        if(types == null)  return;
        var container = GameObject.Find("Container");
        var treeContainer = GameObject.Find("TreeContainer");
        if(treeContainer == null) {
            treeContainer = new GameObject("TreeContainer");
        }
        else {
            GameObject.DestroyImmediate(treeContainer);
        }
        treeContainer.transform.SetParent(container.transform);
        for (int i=0; i < xSize; ++i) {
            for (int j=0; j < ySize; ++j) {
                if(types[i,j] == 2) {
                    if(Random.Range(0,1f) > 0.1f) continue;
                    var count = Random.Range(0, 2);
                    for (int k=0; k < count; ++k) {
                        var randomTree = treeList[Random.Range(0,treeList.Count-1)];
                        var tree = Instantiate(randomTree);
                        tree.transform.position = new Vector3(i*tileSize.x + Random.Range(-tileSize.x, tileSize.x), 0, j*tileSize.y + Random.Range(-tileSize.y, tileSize.y));
                        tree.transform.rotation = Quaternion.Euler(new Vector3(-90, Random.Range(0, 360), 0)); ;
                        tree.transform.SetParent(treeContainer.transform);
                    }

                }
            }

        }

    }
}
