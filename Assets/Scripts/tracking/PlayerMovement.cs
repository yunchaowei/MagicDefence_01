using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int playerIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPosition(Vector3 pos)
    {
        //swith playerIndex
        //transform.position = pos;
        Vector3 new_Pos;
        switch (playerIndex)
        {
            case 1:
                new_Pos = new Vector3(Mathf.Clamp(pos.x, 0, 50), pos.y, pos.z);
                break;
            case 2:
                new_Pos = new Vector3(Mathf.Clamp(pos.x, 50, 100), pos.y, pos.z);
                break;
            default:
                new_Pos = pos;
                break;
        }

        transform.position = new_Pos;
    }
}
