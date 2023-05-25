using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall_Controller : MonoBehaviour
{
    private bool hasHitEnemy = false;
    public float speed = 1.0f; // 定义物体前进的速度
    public int damage = 50;
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

    private void OnTriggerEnter(Collider other)
    {
        if (hasHitEnemy) return;
        Debug.Log("On Enemy Enter");
        if (other.tag == "Enemy")
        {
            hasHitEnemy = true;
            GameObject obj = other.gameObject;
            obj.GetComponent<Enemy>().Get_Damage(damage);
            Destroy(gameObject);
        }
    }
}
