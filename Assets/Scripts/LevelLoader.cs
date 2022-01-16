using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
  public void NextScene()
    {
        SceneManager.LoadScene(1);
    }
    public void PrototypeScene()
    {
        SceneManager.LoadScene(2);
    }
}
