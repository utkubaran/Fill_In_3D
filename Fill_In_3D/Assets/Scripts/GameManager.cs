using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [Space]
    public CubeSpawner cubeSpawner;

    [Space]
    public BaseSpawner baseSpawner;

    [Space]
    [SerializeField] UIController uIController;

    [Space]
    [System.NonSerialized]
    public float percentProgress;

    private int blockCreated;
    private int blockPlaced;
    private int currentSceneIndex;

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

        blockCreated = 0;
        blockPlaced = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        blockCreated = baseSpawner.GetBlockCount();
    }

    // Update is called once per frame
    void Update()
    {
        percentProgress = (float)blockPlaced / (float)blockCreated;
        HandleLevelProgress();
    }

    public void HandleLevelProgress()
    {
        if(blockPlaced == blockCreated)
        {
            uIController.ActivateLevelCompletedScreen();
            Invoke("LoadNextLevel", 3f);
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void IncreaseBlockPlaced()
    {
        blockPlaced++;
    }
}
