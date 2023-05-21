using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleController : MonoBehaviour
{
    public int HP = 100;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Get_Damage(int damage)
    {
        HP -= damage;
        if(HP < 0)
        {
            HP = 0;
        }

        if (HP == 0)
            GameOver();

        Debug.Log("Castle HP: "+ HP);
    }

    private void GameOver()
    {
        //TODO
    }
}
