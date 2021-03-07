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

    private int counter;

    private void Start()
    {
        blockCount = GameManager.instance.baseSpawner.GetBlockCount();

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if(counter <= blockCount)
                {
                    GameObject baseBlock = Instantiate(blockPrefab, transform);
                    Vector3 position = new Vector3(i * offset * 2f, 1 + j * offset * 2f, 0f);
                    baseBlock.transform.localPosition = position;
                    counter++;
                }
            }
        }
    }
}
