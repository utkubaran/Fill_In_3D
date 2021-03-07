using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [Space]
    [SerializeField]
    private GameObject blockPrefab;

    [Space]
    [SerializeField]
    private float offset = 0.32f;

    [System.NonSerialized]
    public int blockCount = 0;

    public int counter;

    private void Start()
    {
        blockCount = GameManager.instance.baseSpawner.GetBlockCount();

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (counter < blockCount)
                    {
                        GameObject baseBlock = Instantiate(blockPrefab, transform);
                        Vector3 position = new Vector3(i * offset * 2f, 1 + j * offset * 2f, k * offset * 2f);
                        baseBlock.transform.localPosition = position;

                        counter++;
                    }
                }
            }
        }
    }
}
