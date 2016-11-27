using UnityEngine;
using System.Collections;

using UnityEngine.UI;


public class Timer : MonoBehaviour {

    [SerializeField]
    private Text timer_text;   //タイマー

    [SerializeField]
    float timer_count;

    bool b_fin;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (!b_fin)
        {
            TimerUpdate();
        }

    }



    void TimerUpdate()
    {
        timer_count -= Time.deltaTime;

        timer_text.text = string.Format("{0:00}:{1:00}", (int)(timer_count / 60), timer_count % 60);

        TimerStop(timer_count);
    }

    void TimerStop(float timer)
    {
        if(timer < 0)
        {
            b_fin = true;
        }
    }

    void TimeOver()
    {

    }

}
