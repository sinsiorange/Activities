using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController2 : MonoBehaviour
{

    public InputField inputFieldA;
    public InputField inputFieldB;
    public InputField inputFieldC;
    Text messageText;
    bool isPushExecute = false;
    static int gameClear2;
    Click cl;

    GameObject player;
    GameObject goal;
    public GameObject startPlayer;

    GameObject gameController;

    Vector3 startPlayerPos;

    float a;
    float b;
    float c;
    // Use this for initialization
    void Start()
    {


        inputFieldA = GameObject.Find("InputFieldA").GetComponent<InputField>();
        inputFieldB = GameObject.Find("InputFieldB").GetComponent<InputField>();
        inputFieldC = GameObject.Find("InputFieldC").GetComponent<InputField>();

        gameController = GameObject.Find("GameController");

        messageText = GameObject.Find("Message").GetComponent<Text>();
        player = GameObject.Find("Player");
        goal = GameObject.Find("Goal");
        cl = GetComponent<Click>();


        if (ReturnScene.SceneBefore == 3)//説明シーンから戻ってきた場合，保存していた変数を使う．
        {

            startPlayerPos = SaveValue.saveStartPlayerPos;
            player.transform.position = SaveValue.savePlayerPos;
            goal.transform.position = SaveValue.saveGoalPos;
            inputFieldA.text = SaveValue.saveAnswer_a;
            inputFieldB.text = SaveValue.saveAnswer_b;
            inputFieldC.text = SaveValue.saveAnswer_c;
            messageText.text = SaveValue.saveMessage;
            if (SaveValue.existStartPlayer == true)
            {
                Instantiate(startPlayer, SaveValue.saveStartPlayerPos, Quaternion.identity);
                ///ClickスクリプトのstartPlayerPosにStartPlayerPos(=StartPlayer(Clone)の子供)のTextコンポーネントを格納
                GameObject.Find("GameController").GetComponent<Click>().startPlayerPosText = GameObject.Find("StartPlayerPos").GetComponent<Text>();
            }

            if (SaveValue.saveDoShowPlayerPos == true)
            {
               
                GameObject.Find("PlayerPos").GetComponent<Text>().text
             = player.name + 
               "(" + player.transform.position.x.ToString() +
               "," + player.transform.position.y.ToString() +
               "," + player.transform.position.z.ToString() + ")";

                cl.doShowPlayerPos = true;
                Debug.Log("cl.doShowPlayerPos = " + cl.doShowPlayerPos);
            }
            else
            {
                
                player.GetComponentInChildren<Text>().text = "";
                cl.doShowPlayerPos = false;

            }

            if (SaveValue.saveDoShowGoalPos == true)
            {
               
                GameObject.Find("GoalPos").GetComponent<Text>().text
            = goal.name +
              "(" + goal.transform.position.x.ToString() +
              "," + goal.transform.position.y.ToString() +
              "," + goal.transform.position.z.ToString() + ")";
                cl.doShowGoalPos = true;
               
            }
            else
            {
               
               
                goal.GetComponentInChildren<Text>().text = "";

                cl.doShowGoalPos = false;
                
            }
            if (SaveValue.saveDoShowStartPlayerPos == true)
            {

                GameObject.Find("StartPlayer(Clone)").GetComponentInChildren<Text>().text
            = "Start(" + GameObject.Find("StartPlayer(Clone)").transform.position.x.ToString() +
              "," + GameObject.Find("StartPlayer(Clone)").transform.position.y.ToString() +
              "," + GameObject.Find("StartPlayer(Clone)").transform.position.z.ToString() + ")";

                cl.doShowStartPlayerPos = true;
            }
            else
            {

                if (GameObject.Find("StartPlayer(Clone)") != null)
                {
                    GameObject.Find("StartPlayer(Clone)").GetComponentInChildren<Text>().text = "";
                    cl.doShowStartPlayerPos = false;
                }
            }
        }
        else
        {

            RandomPlayerPos();
            RandomGoalPos();
           
        }
            }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) //デバッグ用
        {
            TrueFalseJudgment();
        }
        if (isPushExecute == true)//実行ボタンが押されたかどうかを判定
        {
            Execution();
            isPushExecute = false;
        }
       
    }

    public void PushResetButton()//画面をリセットする。Resetボタンが押されると呼び出される
    {
        //回答欄を初期化
        inputFieldA.text = "";
        inputFieldB.text = "";
        inputFieldC.text = "";

        //playerの位置を初期化
        RandomPlayerPos();

        //goalの位置を初期化
        RandomGoalPos();

       
        //メッセージ欄を初期化
        messageText.text = "";

        //オブジェクトの座標表示を初期化

        cl.ErasePos();

        //StartPlayerの削除
        if (GameObject.Find("StartPlayer(Clone)") != null)
        {
            Destroy(GameObject.Find("StartPlayer(Clone)"));
        }

        //GoalPosの位置を初期化
        GameObject.Find("GoalPos").GetComponent<RectTransform>().localPosition = new Vector3(13, 0, 0);
    }

    public void Execution() //入力結果を実行する
    {
        cl.ErasePos();
        if (TrueFalseJudgment()) //正解かどうか判定
        {
            player.transform.position = startPlayerPos;
            for (int i = 0;i < a;i++)
            {
                player.transform.Translate(b, 0, c);//playerが移動
            }

            if (GameObject.Find("StartPlayer(Clone)") == null)///StartPlayer(Clone)がない場合は/StartPlayer(Clone)を生成
            {
                Instantiate(startPlayer, startPlayerPos, Quaternion.identity);
            }

            ///ClickスクリプトのstartPlayerPosにStartPlayerPos(=StartPlayer(Clone)の子供)のTextコンポーネントを格納
            GameObject.Find("GameController").GetComponent<Click>().startPlayerPosText = GameObject.Find("StartPlayerPos").GetComponent<Text>();

            messageText.text = "正解";
            gameClear2 = 1;
            PlayerPrefs.SetInt("GameClearKey2", 1);//クリアしたらセーブ
        }
        else
        {
            player.transform.position = startPlayerPos;
            for (int i = 0; i < a; i++)
            {
                player.transform.Translate(new Vector3(b, 0, c));//playerが移動
            }

            if (GameObject.Find("StartPlayer(Clone)") == null)///StartPlayer(Clone)がない場合は/StartPlayer(Clone)を生成
            {
                Instantiate(startPlayer, startPlayerPos, Quaternion.identity);
            }


            ///ClickスクリプトのstartPlayerPosにStartPlayerPos(=StartPlayer(Clone)の子供)のTextコンポーネントを格納
            GameObject.Find("GameController").GetComponent<Click>().startPlayerPosText = GameObject.Find("StartPlayerPos").GetComponent<Text>();

            if (float.Parse(inputFieldA.text) <= 1)
            {
                messageText.text = "<color=red>a</color>が1以下です．";
            }
            else
            {
                if (player.transform.position.x == goal.transform.position.x)
                {
                    if (player.transform.position.z != goal.transform.position.z)
                    {
                        messageText.text = "<color=red>z</color>が間違っています";
                    }
                }
                else
                {
                    if (player.transform.position.z == goal.transform.position.z)
                    {
                        messageText.text = "<color=red>x</color>が間違っています";
                    }
                    else
                    {
                        messageText.text = "<color=red>x</color>と<color=red>z</color>が間違っています";
                    }
                }
            }
            
        }
    }

    public void PushExecuteButton() //実行ボタンが押されたら呼び出される
    {
        if (inputFieldA.text != "" && inputFieldB.text != "" && inputFieldC.text != "")//すべての回答欄が入力されたかどうか判定
        {
            isPushExecute = true;
        }

    }

    public static int GameClear2 //gameClear変数のプロパティ
    {
        get { return gameClear2; }
        set { gameClear2 = value; }

    }

    public void PushMenuButton()//メニューボタンが押されたら呼ばれる
    {
        ReturnScene.SceneBefore = 0;
        SceneManager.LoadScene("Menu");
    }

    public void PushExplanationButton()//説明ボタンが押されたら呼ばれる
    {
        //シーン中の情報を保存
        SaveValue.savePlayerPos = player.transform.position;
        SaveValue.saveGoalPos = goal.transform.position;
        SaveValue.saveAnswer_a = inputFieldA.text;
        SaveValue.saveAnswer_b = inputFieldB.text;
        SaveValue.saveAnswer_c = inputFieldC.text;
        SaveValue.saveDoShowPlayerPos = cl.doShowPlayerPos;
        SaveValue.saveDoShowGoalPos = cl.doShowGoalPos;
        SaveValue.saveMessage = messageText.text;
        if (GameObject.Find("StartPlayer(Clone)") != null)
        {
            SaveValue.saveStartPlayerPos = GameObject.Find("StartPlayer(Clone)").transform.position;
            SaveValue.saveDoShowStartPlayerPos = cl.doShowStartPlayerPos;
            SaveValue.existStartPlayer = true;
        }
        else
        {
            SaveValue.existStartPlayer = false;
        }

        ReturnScene.SceneBefore = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Explanation");
    }

    public void RandomPlayerPos()//プレイヤーの位置をランダムに表示
    {
        int rndX = Random.Range(2, 4);
        int rndZ = Random.Range(-1, 2);
        player.transform.position = new Vector3(rndX, 0, rndZ);
        startPlayerPos = player.transform.position;
    }

    public void RandomGoalPos()//ゴールの位置をランダムに表示
    {
        int rndX = Random.Range(3, 5);
        int rndZ = Random.Range(0, 5);
        goal.transform.position = new Vector3(2 + rndX, 0 , 3 + rndZ);
    }

    public bool TrueFalseJudgment()//正誤判定
    {
        a = float.Parse(inputFieldA.text);
        b = float.Parse(inputFieldB.text);
        c = float.Parse(inputFieldC.text);
        if (a <= 1)
        {    
            return false;
        }
        if (goal.transform.position - startPlayerPos == a * new Vector3(b,0,c))
        {          
            return true;           
        }
        else
        {  
            return false;
        }
    }
}

