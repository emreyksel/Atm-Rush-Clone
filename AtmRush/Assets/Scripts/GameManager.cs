using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager insance;

    public GameObject finishPanel;
    [HideInInspector] public bool isGameStart = false;
    [HideInInspector] public bool isGameFinish = false;

    private void Awake()
    {
        insance = this;
    }

    private void Update()
    {
        if (isGameFinish)
        {
            Invoke(nameof(FinishPanelActive),2);
        }
    }

    public void FinishPanelActive()
    {
        finishPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
