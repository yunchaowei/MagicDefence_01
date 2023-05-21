using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall_Controller : MonoBehaviour
{
    public float speed = 1.0f; // 定义物体前进的速度

    private Transform objectTransform;
    void Start()
    {
        objectTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // 在X轴上移动物体
        objectTransform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
