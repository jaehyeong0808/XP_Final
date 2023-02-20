using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class GameManangerScript : MonoBehaviour
{
    public static GameManangerScript instance;
    public static float timeLimit = 100f;//총 게임 시간 
    public static bool wireClear = false;
    public static bool timeGo = true;

    private GameObject QuitBtn;

    private GameObject inventoryPanel;   //인벤토리 패널
    public static bool activeInven = false;       //인벤 패널 활성화 상태
    private GameObject invenBtn;

    //아이템 설정
    public bool getNameTag = false;
    public bool getSaw = false;
    public bool getHandcloth = false;
    public bool getMonsterFoot = false;
    public bool getRipHand = false;
    public bool getFoot01 = false;
    public bool getFoot02 = false;
    public bool getFoot03 = false;
    private GameObject s_nameTag;
    private GameObject s_saw;
    private GameObject s_handcloth;
    private GameObject s_monsterFoot;
    private GameObject s_ripHand;
    private GameObject s_foot01;
    private GameObject s_foot02;
    private GameObject s_foot03;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //씬 로드 될 때마다 실행
        QuitBtn = GameObject.Find("QuitBtn");
        inventoryPanel = GameObject.Find("Inventory");
        invenBtn = GameObject.Find("InvenButton");
        s_nameTag = GameObject.Find("S_NameTag");
        s_saw = GameObject.Find("S_Saw");
        s_handcloth = GameObject.Find("S_Handcloth");
        s_monsterFoot = GameObject.Find("S_MonsterFoot");
        s_ripHand = GameObject.Find("S_RipHand");
        s_foot01 = GameObject.Find("S_Footprint_01");
        s_foot02 = GameObject.Find("S_Footprint_02");
        s_foot03 = GameObject.Find("S_Footprint_03");
        if (inventoryPanel)
            inventoryPanel.SetActive(activeInven);      //인벤 비활성화

        if (invenBtn)
        {
            invenBtn.GetComponent<Button>().onClick.AddListener(getInvenButton);
        }


    }
    void OnEnable()
    {
        //onLoad랑 세트
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this);
        GameManangerScript.timeLimit = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        /* if (activeInven == true)
         {
             QuitBtn.SetActive(false);
         }
         else
         {
             QuitBtn.SetActive(true);
         }*/
        if (timeLimit <= 0)
        {
            SceneManager.LoadScene("gameOverScene");
            Debug.Log("겜 오버");


        }
        //Debug.Log(timeGo);
        if (timeGo)
        {
            timeLimit -= Time.deltaTime;

        }
        else
        {

        }

        //인벤 슬롯 활성화 부분
        if(s_nameTag != null)
        {
            s_nameTag.SetActive(getNameTag);
            s_ripHand.SetActive(getRipHand);
            s_monsterFoot.SetActive(getMonsterFoot);
            s_handcloth.SetActive(getHandcloth);
            s_saw.SetActive(getSaw);
            s_foot01.SetActive(getFoot01);
            s_foot02.SetActive(getFoot02);
            s_foot03.SetActive(getFoot03);
        }
       
    }
    public static void TimeSub(int getTime)
    {
        timeLimit -= getTime;
        MiniGameTimer.timeDuration = 0;
    }
    public static void TimeAdd(int getTime)
    {
        timeLimit += getTime;
        MiniGameTimer.timeDuration = 0;
    }
    public void getInvenButton()
    {
        Debug.Log(activeInven);       // Debug.Log(MainGameManagerScr.timeGo);
        activeInven = !activeInven;     //버튼 누를때 마다 활성 or 비활성
        inventoryPanel.SetActive(activeInven);  // bool값 적용
        GameManangerScript.timeGo = !GameManangerScript.timeGo;
    }
    public void ApplicationQuit()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            //UI에 가려지면 작동 X
            Application.Quit();
            Debug.Log("닫힘");
        }

    }

    void OnDisable()
    {
        //씬 종료시, onload랑 세트
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
