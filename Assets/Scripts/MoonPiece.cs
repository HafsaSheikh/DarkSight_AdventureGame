using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonPiece : MonoBehaviour
{
    Enemy1 enemy1;
    [SerializeField]GameObject moonPiece;
    void Start()
    {
        enemy1 = GetComponentInChildren<Enemy1>(); 
    }

    void Update()
    {
        if(enemy1.dead==true && moonPiece.gameObject !=null)
        {
            //Debug.Log("enemy1.dead called");
            moonPiece.gameObject.SetActive(true);
            //Debug.Log("MoonActive");
        }
    }
}
