using UnityEngine;
using System.Collections;




public class Character : BaseCharacter {



    [SerializeField]
    private P_State p_state;

    [SerializeField]
    Status info;      //ステータス情報

    [SerializeField]
    private new Rigidbody rigidbody;     //Rigidbody

    [SerializeField]
    private NavMeshAgent agent;

    //private Transform[] points;

    private int now_point;

    //------------------------------------------

    //  初期化

    //------------------------------------------
    void Start()
    {
        //GameObject enemy_home = GameObject.Find("enemy_home");
        //agent.destination = enemy_home.transform.position;
        //agent.SetDestination(enemy_home.transform.position);
    }



    //------------------------------------------

    //  更新

    //------------------------------------------
    void Update()
    {
        switch (p_state)
        {
            case P_State.MOVE:
                Move();
                break;

            case P_State.ATTACK:
                Attack();
                break;

            case P_State.DAMAGE:
                break;

            case P_State.DEAD:
                Dead();
                break;
        }

    }


    //------------------------------------------

    //  物理挙動がある時

    //------------------------------------------
    void FixedUpdate()
    {

    }



    //------------------------------------------

    //  移動

    //------------------------------------------
    public void Move()
    {

        if(agent.remainingDistance < 0.5f)
        {
            NextPoint();
        }
        //rigidbody.velocity = new Vector2(info.spd, rigidbody.velocity.y);
    }


    //------------------------------------------

    //  次の目標ポイントへ移動

    //------------------------------------------
    void NextPoint()
    {
        GameObject points = GameObject.Find("Cube_" + now_point.ToString());

        agent.SetDestination(points.transform.position);

        now_point++;
    }

    //------------------------------------------

    //  攻撃

    //------------------------------------------
    void Attack()
    {
        rigidbody.velocity = Vector3.zero;
    }

    //------------------------------------------

    //  ダメージ

    //------------------------------------------
    void Damage()
    {

    }

    //------------------------------------------

    //  死亡

    //------------------------------------------
    void Dead()
    {

    }

    //------------------------------------------

    //  範囲内に入れば動かない

    //------------------------------------------
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy_Home" || other.gameObject.tag == "Enemy") 
        {
            p_state = P_State.ATTACK;
        }
    }


    //------------------------------------------

    //  範囲外に行けば動く

    //------------------------------------------
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            p_state = P_State.MOVE;
        }
    }




}
