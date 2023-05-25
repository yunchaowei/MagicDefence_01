using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff_Controller : MonoBehaviour
{
    public GameObject Player;
    public GameObject Fireballprefab;
    public Transform Spawn_Point;

    private Vector3 previousPosition;
    private float previousShootTime;
    public float detect_Dis = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveDistance = Mathf.Abs(transform.position.y - previousPosition.y); // 计算玩家在Y轴上的移动距离
        //Debug.Log("moveDistance " + moveDistance);
        if (moveDistance > detect_Dis && Time.time - previousShootTime > 1.0f) // 如果移动距离超过50cm并且距离上一次发射火球的时间超过1秒
        {
            ShootFireball(); // 发射火球
            previousShootTime = Time.time; // 更新上一次发射火球的时间
        }

        previousPosition = transform.position; // 更新上一帧的玩家位置
    }

    private void ShootFireball()
    {
        GameObject Fireball = Instantiate(Fireballprefab, Spawn_Point.position,
       Fireballprefab.transform.rotation);
    }
}
