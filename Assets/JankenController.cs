using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JankenController : MonoBehaviour {

    public GameObject[] player_hp;
    public GameObject[] enemy_hp;
    public GameObject ui;
    public Text rizalt;

    private int count_pl = 0;
    private int count_en = 0;


    //意味はないけど参考に
    private int gu = 0;
    private int cho = 1;
    private int pa = 2;

    //勝敗判定(0引き分け,1負け,2勝ち)
    private int judge=3;

    //3で未入力
    private int playerHand=3;
    private int enemyHand;

    public int playerHP;
    public int enemyHP;

    public Text playerHand_txt;
    public Text enemyHand_txt;
    public Text judgeText;
    

    void Start () {
        
	}
	
	void FixedUpdate () {
        if (playerHand != 3)
        {
            EnemyHand();
            PlayerHandText();
            EnemyHandText();
            Janken();
            playerHand = 3;
            enemyHand = 3;
        }

	}

    //勝ち負けとかの判定
    private void Janken()
    {
        judge = (playerHand - enemyHand + 3) % 3;
        if (judge == 0) { judgeText.text = "引き分け"; }
        else if (judge == 1)
        {
            judgeText.text = "負け";
            CountUp_pl();
        }
        else if (judge == 2)
        {
            judgeText.text = "勝ち";
            CountUp_en();
        }
        else { judgeText.text = ""; }
    }
    //ボタンの入力でプレイヤーの手の値を入れる関数
    public void Gu() { playerHand = 0; }
    public void Choki() { playerHand = 1; }
    public void Pa() { playerHand = 2; }
    //相手の手を決定する
    private void EnemyHand()
    {
        enemyHand = Random.Range(0, 100)%3;
    }

    //手ごとにテキストを変えるとこ(画像に置き換えるとこ)
    private void PlayerHandText()
    {
        if (playerHand == 0)
        {
            playerHand_txt.text = "グー";
        }
        else if (playerHand == 1)
        {
            playerHand_txt.text = "チョキ";
        }
        else if (playerHand == 2)
        {
            playerHand_txt.text = "パー";
        }
        else
        {
            playerHand_txt.text = "?";
        }
    }
    private void EnemyHandText()
    {
        if (enemyHand == 0)
        {
            enemyHand_txt.text = "グー";
        }
        else if (enemyHand == 1)
        {
            enemyHand_txt.text = "チョキ";
        }
        else if (enemyHand == 2)
        {
            enemyHand_txt.text = "パー";
        }
        else
        {
            enemyHand_txt.text = "?";
        }
    }



    private void CountUp_en()
    {
        enemy_hp[count_en].SetActive(false);
        count_en++;

        if (count_en == 3)
        {
            ui.SetActive(true);
            rizalt.text = "勝利！";
        }
    }

    private void CountUp_pl()
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
