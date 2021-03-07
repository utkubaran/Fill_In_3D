using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawner : MonoBehaviour
{
    [Space]
    [SerializeField]
    private Sprite pixelArtSprite;

    [Space]
    [SerializeField]
    private GameObject blockPrefab;

    [Space]
    [SerializeField]
    private float offset = 0.32f;

    [System.NonSerialized]
    public int blockCount = 0;

    Texture2D image;

    Vector3 blockPos = Vector3.zero;

    private void Awake()
    {
        image = pixelArtSprite.texture;
        SpawnBlocks();
    }

    private void SpawnBlocks()
    {
        for (int x = 0; x < image.width; x++)
        {
            for (int y = 0; y < image.height; y++)
            {
                Color color = image.GetPixel(x, y);

                if (color.a == 0)
                {
                    continue;
                }

                blockPos = new Vector3(offset * (x - image.width * 0.5f), -offset * 0.5f + 0.005f, offset * (y - image.height * 0.5f));
                GameObject baseObject = Instantiate(blockPrefab, transform);
                baseObject.transform.localPosition = blockPos;

                baseObject.GetComponent<BaseBlock>().color = color;

                // blockObject.GetComponent<Renderer>().material.color = color;

                blockCount++;
            }
        }
    }

    public int GetBlockCount()
    {
        return blockCount;
    }
}
