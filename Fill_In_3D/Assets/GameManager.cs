using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [Space]
    public CubeSpawner cubeSpawner;

    [Space]
    public BaseSpawner baseSpawner;

    [Space]
    public int blockCreated;
    public int blockPlaced;
    public int blockRemaining;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if(this != instance)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        blockCreated = baseSpawner.GetBlockCount();
    }

    // Update is called once per frame
    void Update()
    {
        blockRemaining = blockCreated - blockPlaced;
    }

    public void IncreaseBlockPlaced()
    {
        blockPlaced++;
    }
}
