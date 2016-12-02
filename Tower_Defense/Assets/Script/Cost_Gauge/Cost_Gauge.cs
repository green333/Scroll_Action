using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Cost_Gauge : MonoBehaviour {

    [SerializeField]
    private GameObject character;   //キャラクター

    [SerializeField]
    private int cost;               //必要コスト

    [SerializeField]
    private Image unpossible_image;   //使用不可時の画像

    [SerializeField]
    private float possible_speed;     //使用可能になる時間


    [SerializeField]
    private GameObject home;


    enum B_State
    {
        AVAILABLE = 0,   //使用可能
        UNAVAILABLE,     //使用不可
    }


    private B_State b_state;


    void Start () {

    }
	
	void Update () {
	
        switch(b_state)
        {
            case B_State.AVAILABLE:
                Possible();
                break;

            case B_State.UNAVAILABLE:
                UnPossible();
                break;
        }



    }


    //------------------------------

    //  ボタン使用可能

    //------------------------------
    void Possible()
    {
        unpossible_image.fillAmount = 0;
    }


    //------------------------------

    //  ボタン使用不可能

    //------------------------------
    void UnPossible()
    {
        unpossible_image.fillAmount += possible_speed * Time.deltaTime;

        if(unpossible_image.fillAmount == 1)
        {
            b_state = B_State.AVAILABLE;
        }
        
    }



    public void OnClick()
    {
        if (b_state == B_State.AVAILABLE)
        {
            Instantiate(character, new Vector3(home.transform.position.x, 0.5f, home.transform.position.z), Quaternion.identity);
            b_state = B_State.UNAVAILABLE;
        }
    }

}
