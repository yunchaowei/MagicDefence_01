using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour {
    
    public Transform shootElement;
    public GameObject bullet;
    public GameObject Enemybug;
    public float Speed; 
    public int Creature_Damage = 10;
    // 
    public Transform[] waypoints;
    int curWaypointIndex = 0;
    public float previous_Speed;
    public Animator anim;
    public EnemyHp Enemy_Hp;
    public Transform target;
    public GameObject EnemyTarget;
    public int HP = 100;
    public bool IsAvailable = true;
    public float CooldownDuration = 30000.0f;
    private float next_AttackTiem = 0f;
    void Start()
    {            
        anim = GetComponent<Animator>();
        Enemy_Hp = Enemybug.GetComponent<EnemyHp>();
        previous_Speed = Speed;
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter");
        if (other.tag == "Castle")
        {
            Speed = 0;
            EnemyTarget = other.gameObject;
            target = other.gameObject.transform;
            Vector3 targetPosition = new Vector3(EnemyTarget.transform.position.x, transform.position.y, EnemyTarget.transform.position.z);            
            transform.LookAt(targetPosition);
            anim.SetBool("RUN", false);
            Hit();
        }
    }

    private void Hit()
    {
        if(Time.time > next_AttackTiem)
        {
            anim.SetBool("Attack", true);
            GetDamage();
            next_AttackTiem = Time.time + CooldownDuration;
            Debug.Log("next_AttackTiem  " + next_AttackTiem);
        }else
            anim.SetBool("Attack", false);
    }


    // Attack
    void Shooting()
    {
        //if (EnemyTarget)
       // {           
            GameObject с = GameObject.Instantiate(bullet, shootElement.position, Quaternion.identity) as GameObject;
        //с.GetComponent<Enemy_Hit>().Creature_Damage = 10;
        // }  
    }
    void GetDamage ()
    {        
        EnemyTarget.GetComponent<CastleController>().Get_Damage(Creature_Damage);
    }

    public void Get_Damage(int damage)
    {
        HP -= damage;
        if (HP < 0)
        {
            HP = 0;
        }

        Debug.Log("Enemy HP: " + HP);

        if (HP == 0)
            Destroy(gameObject);

    }


    void Update () 
	{

        
        //Debug.Log("Animator  " + anim);


        // MOVING

        if (curWaypointIndex < waypoints.Length){
	transform.position = Vector3.MoveTowards(transform.position,waypoints[curWaypointIndex].position,Time.deltaTime*Speed);

            //if (!EnemyTarget)
            //{
            //    transform.LookAt(waypoints[curWaypointIndex].position);
            //}
            transform.LookAt(waypoints[curWaypointIndex].position);

            if (Vector3.Distance(transform.position,waypoints[curWaypointIndex].position) < 0.5f)
	{
		curWaypointIndex++;
	}    
	}          

        else
        {
            anim.SetBool("Victory", true);  // Victory
        }

        // DEATH

        if (Enemy_Hp.EnemyHP <= 0)
        {
            Speed = 0;
            Destroy(gameObject, 5f);
            anim.SetBool("Death", true);            
        }

        // Attack to Run
                

        if (EnemyTarget)        {

          
            //if (EnemyTarget.CompareTag("Castle_Destroyed")) // get it from BuildingHp
            //{
            //    anim.SetBool("Attack", false);
            //    anim.SetBool("RUN", true);
            //    Speed = previous_Speed;               
            //    EnemyTarget = null;                
            //}
        }


    }
       
   
}

