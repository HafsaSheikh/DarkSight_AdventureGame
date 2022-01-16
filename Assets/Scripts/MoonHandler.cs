using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonHandler : MonoBehaviour
{
    [SerializeField] Text moonCount;
    // Start is called before the first frame update
    void Start()
    {
        moonCount.text = PlayerPrefs.GetInt("Piece1").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
