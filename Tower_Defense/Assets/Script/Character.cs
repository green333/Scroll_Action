using UnityEngine;
using System.Collections;


[System.Serializable]
class Status
{
    public int hp;        //体力
    public int attack;    //攻撃
    public int defense;   //防御
    public float spd;     //速度
}



public class Character : MonoBehaviour {

    //-----------------------
    //  プレイヤーの状態
    //-----------------------
    protected enum P_State
    {
        MOVE = 0,                 //操作する
        ATTACK,                   //攻撃する
    }

    [SerializeField]
    private P_State p_state;

    [SerializeField]
    Status info;      //ステータス情報

    [SerializeField]
    private new Rigidbody rigidbody;     //Rigidbody2D

    [SerializeField]
    protected Animator animator;          //アニメーション




    //------------------------------------------

    //  初期化

    //------------------------------------------
    void Start()
    {

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
        rigidbody.velocity = new Vector2(info.spd, rigidbody.velocity.y);
    }



    //------------------------------------------

    //  範囲内に入れば動かない

    //------------------------------------------
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            p_state = P_State.ATTACK;
        }
    }


    //------------------------------------------

    //  範囲外に行けば動く

    //------------------------------------------
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            p_state = P_State.MOVE;
        }
    }

}
