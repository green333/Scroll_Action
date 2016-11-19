using UnityEngine;
using System.Collections;


//-----------------------------------------------------------------

//  勇者クラス

//-----------------------------------------------------------------
public class Brave : MonoBehaviour
{
    //-----------------------
    //  プレイヤーの状態
    //-----------------------
    protected enum P_State
    {
        CONTROL = 0,                 //操作する
        TRAKING,                     //プレイヤーを 追尾する
    }


    //-----------------------
    //  プレイヤーの能力
    //-----------------------
    protected enum Ability
    {
        NORMAL = 00000001,         //普通             
        SPEEDER = 00000010,        //スピード重視    
        WEIGHTER = 00000100,       //重さ重視       
        JUMPER = 00001000,         //ジャンプ力       
        SHORTER = 00010000,        //近距離          
        LONGER = 00100000,         //遠距離           
    }

    [SerializeField]
    private Ability ability;       //個々の能力

    [SerializeField]
    protected P_State p_state;     //プレイヤーのステート

    [SerializeField]
    private new Rigidbody2D rigidbody;     //Rigidbody2D

    [SerializeField]
    protected Animator animator;          //アニメーション

    [SerializeField]
    protected GameObject buddy = null;        //仲間

    [SerializeField]
    private float jump;                //ジャンプ力

    [SerializeField]
    private float spd;      //移動速度

    private Vector2 move;     //位置

    private Vector2 tracking;      //追尾(仲間を追尾)

    [SerializeField]
    private bool track_wait;      //追尾停止（待機）

    [SerializeField]
    private string tag_name;        //タグ名

    [SerializeField]
    private new Camera camera;          //カメラ

    private bool jumpflg;        //複数回禁止(ジャンプ)


    //------------------------------------------

    //  初期化

    //------------------------------------------
    void Start()
    {
        camera = Camera.main;   //プレイヤーへターゲットする

        if (Char_Button.char_num == 1)
        {
            p_state = P_State.CONTROL;
        }
        else
        {
            p_state = P_State.TRAKING;
        }
    }

    //------------------------------------------

    //  更新

    //------------------------------------------
    void Update()
    {
        switch (p_state)
        {
            case P_State.CONTROL:      //操作
                Control();
                break;

            case P_State.TRAKING:      //追尾
                if (!track_wait)
                {
                    Traking();
                }
                break;
        }

        Replacement();
        Camera_Target();
    }


    //------------------------------------------

    //  物理挙動がある時

    //------------------------------------------
    void FixedUpdate()
    {

    }

    //------------------------------------------

    //  カメラのターゲット

    //------------------------------------------
    void Camera_Target()
    {
        if (p_state == P_State.CONTROL)
        {
            camera.transform.position = new Vector3(transform.position.x, 4.5f, -5);
        }

    }




    //------------------------------------------

    //  移動

    //------------------------------------------
    public void Control()
    {
        float control = Input.GetAxis("Horizontal");



        if (control != 0)
        {
            rigidbody.velocity = new Vector2(control * spd, rigidbody.velocity.y);
        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }


        if (Input.GetKeyDown(KeyCode.UpArrow) & !jumpflg)
        {
            jumpflg = true;
            //var anime = gameObject.GetComponent<Animator>();
            rigidbody.velocity = new Vector2(0, jump);
        }

    }



    //------------------------------------------

    //  移動追尾

    //------------------------------------------
    public void Traking()
    {
        tracking = buddy.transform.position - transform.position;

        rigidbody.velocity = new Vector2(tracking.x * (spd / 2), rigidbody.velocity.y);
    }



    //------------------------------------------

    //  操作キャラの入れ替え

    //------------------------------------------
    void Replacement()
    {
        if (Input.GetKeyDown(KeyCode.Space) & Char_Button.char_num != 1)
        {
            p_state++;
        }



        if (p_state > P_State.TRAKING)
        {
            p_state = P_State.CONTROL;
        }
    }

    //------------------------------------------

    //  範囲内に入れば動かない

    //------------------------------------------
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == tag_name)
        {
            track_wait = true;
        }

        
    }


    //------------------------------------------

    //  範囲外に行けば動く

    //------------------------------------------
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == tag_name)
        {
            track_wait = false;
        }


    }


    //------------------------------------------

    //  地面に着けば飛べる

    //------------------------------------------
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            jumpflg = false;
        }
    }



}
