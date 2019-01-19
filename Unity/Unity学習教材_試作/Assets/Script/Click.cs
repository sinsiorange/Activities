using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class Click : MonoBehaviour {
    

   public Text playerPosText;
   public Text goalPosText;
   public Text startPlayerPosText;
    

    public  bool doShowPlayerPos;
    public  bool doShowGoalPos;
    public bool doShowStartPlayerPos;

    public int currentGoalPos; /// 1:右　2:左　3:上　4:下
    

	// Use this for initialization
	void Start () {
        playerPosText = GameObject.Find("PlayerPos").GetComponent<Text>();
        goalPosText = GameObject.Find("GoalPos").GetComponent<Text>();   
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckOverlap();


        if (Input.GetMouseButtonDown(0))//マウスをクリックしたかどうか判定
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))//物体をクリックしたかどうか判定
            {               
                ShowGameObjectPos(hit,"Player",ref doShowPlayerPos,playerPosText);
                ShowGameObjectPos(hit, "Goal", ref doShowGoalPos, goalPosText);
                ShowGameObjectPos(hit, "StartPlayer(Clone)", ref doShowStartPlayerPos, startPlayerPosText);
               
            }
        }
       
    }

    string GameObjectPosition(GameObject gameObject)
    {
        if (gameObject.name == "Player" || gameObject.name == "Goal")
        {
            return gameObject.name + " (" + gameObject.transform.position.x.ToString() +
               "," + gameObject.transform.position.y.ToString() +
               "," + gameObject.transform.position.z.ToString() + ")";
        }
        else
        {
            return "Start" + " (" + gameObject.transform.position.x.ToString() +
              "," + gameObject.transform.position.y.ToString() +
              "," + gameObject.transform.position.z.ToString() + ")";
        }
        
    }

    void ShowGameObjectPos(RaycastHit hit,string gameObjectName,ref bool doShowGameObjectPos,Text gameObjectPos)
    {
        if (hit.collider.gameObject.name == gameObjectName)
        {
            if (doShowGameObjectPos == false)
            {
                
                gameObjectPos.text = GameObjectPosition(hit.collider.gameObject);
          
                doShowGameObjectPos = true;
                
                
            }
            else
            {
                gameObjectPos.text = "";
                doShowGameObjectPos = false;
            }
        }
        
    }

    public void ErasePos()
    {
        playerPosText.text = "";
        goalPosText.text = "";
        
        if (startPlayerPosText != null)
        {
            startPlayerPosText.text = "";
        }
        doShowPlayerPos = false;
        doShowGoalPos = false;
        doShowStartPlayerPos = false;
    }

    public void CheckOverlap()
    {
        Vector3 playerPosViewPortPos = Camera.main.WorldToViewportPoint(GameObject.Find("PlayerPos").transform.position);
        Vector3 goalPosViewPortPos = Camera.main.WorldToViewportPoint(GameObject.Find("GoalPos").transform.position);
        Vector3 goalViewPortPos = Camera.main.WorldToViewportPoint(GameObject.Find("Goal").transform.position);
        playerPosViewPortPos.z = 0;
        Ray ray = Camera.main.ViewportPointToRay(playerPosViewPortPos);///カメラからplayerにrayを飛ばす．
        int layerMask = 1 << LayerMask.NameToLayer("GoalPos");
        
        float distance = 100; 
        float duration = 3;
        /*
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, duration, false); ]
        */
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) 
        {
            Debug.Log("hit");
            Vector3 right = new Vector3(goalViewPortPos.x + 2, goalViewPortPos.y, 0);
            Vector3 left = new Vector3(goalViewPortPos.x - 2, goalViewPortPos.y, 0);
            Vector3 up = new Vector3(goalViewPortPos.x, goalViewPortPos.y + 2, 0);
            Vector3 down = new Vector3(goalViewPortPos.x, goalViewPortPos.y - 2, 0);
            List<Vector3> directions = new List<Vector3>() { left, up, down, right };  ///それぞれの座標をリストに格納
            directions = directions.OrderBy(i => Guid.NewGuid()).ToList(); ///ランダムにソート
            foreach (var direction in directions)
            {
                Ray directionRay = Camera.main.ViewportPointToRay(direction);///goalViewPortPosの右左上下にdirectionRayを飛ばす．
                RaycastHit directionHit;
                int directionLayerMask = ~(1 << LayerMask.NameToLayer("GoalPos"))| ~(1 << LayerMask.NameToLayer("Floor")); ///GoalPosとFloorを除いたlayerMaskを定義
                if (Physics.Raycast(directionRay, out directionHit, Mathf.Infinity, directionLayerMask))　///GoalPosやFloor以外と衝突したら
                {
                    Debug.Log("hoge");
                    continue;
                }
                else　///GoalPosや床以外と衝突しなかったら
                {
                    Debug.Log("huga");
                  
                    GameObject goalPos = GameObject.Find("GoalPos");
                  
                    if (direction == right)
                    {
                      
                        goalPos.GetComponent<RectTransform>().localPosition = new Vector3(12 ,0 ,0);
                        currentGoalPos = 1;
                    }
                    else if (direction == left)
                    {
                       
                        goalPos.GetComponent<RectTransform>().localPosition = new Vector3(-12, 0, 0);
                        currentGoalPos = 2;
                    }
                    else if (direction == up)
                    {
                      
                        goalPos.GetComponent<RectTransform>().localPosition = new Vector3(0, 6, 0);
                        currentGoalPos = 3;
                    }
                    else
                    {
           
                        goalPos.GetComponent<RectTransform>().localPosition = new Vector3(0, -6, 0);
                        currentGoalPos = 4;
                    }
                    break;
                }
            }



           
        }
       
    }
}
