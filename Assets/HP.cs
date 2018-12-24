using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour {

    public GameObject[] player_hp;
    public GameObject[] enemy_hp;
    public GameObject ui;
    public Text rizalt;

    private int count_pl = 0;
    private int count_en = 0;


    void Start ()
    {
		
	}
    void Update ()
    {
        
    }

    public void CountUp_en()
    {
        enemy_hp[count_en].SetActive(false);
        count_en++;
        
        if (count_en == 3)
        {
            ui.SetActive(true);
            rizalt.text = "勝利！";
        }
    }

    public void CountUp_pl()
    {
        player_hp[count_pl].SetActive(false);
        count_pl++;
        
        if (count_pl == 3)
        {
            ui.SetActive(true);
            rizalt.text = "敗北！";
        }
    }
    
}
