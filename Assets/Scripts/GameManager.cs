using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject successPanel;


    private void Start()
    {
        Time.timeScale = 1;
    }
    public void StartGame() // yh algscreen bnani hai
    { startPanel.SetActive(false); }
    public void GameOver()
    {
        StartCoroutine("GameEnd");
        
    }
    public void Success()
    {
        successPanel.SetActive(true);
    }

    IEnumerator GameEnd()
    {
        yield return new WaitForSeconds(2.5f);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    { SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
    }
    public void MaiinMenu()
    {
        SceneManager.LoadScene(0);

    }




}
