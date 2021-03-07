using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Space]
    [SerializeField]
    Slider slider;

    [Space]
    [SerializeField]
    Text levelProgressText;

    [Space]
    [SerializeField]
    GameObject levelCompletedScreen;

    private float levelProgressPercentage;

    private void Awake()
    {
        levelCompletedScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = GameManager.instance.percentProgress;

        levelProgressPercentage = Mathf.Round(GameManager.instance.percentProgress * 100f);
        levelProgressText.text = levelProgressPercentage + "%";
    }

    public void ActivateLevelCompletedScreen()
    {
        levelCompletedScreen.SetActive(true);
    }
}
