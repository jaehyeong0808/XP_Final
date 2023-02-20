using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class MemoryMain : MonoBehaviour
{
    private int WhenStart=1;
    //private int deletTime = 2;

    [SerializeField]
    private List<Button> SelectBtn;

    private string GoalString = "";
    private string TextIn;
    private bool TextTest=true;
   
    private GameObject deActObj;
    private GameObject ActObj;
    // Start is called before the first frame update
    void Start()

    
    {
        allBtnSetFalse();

        

        Debug.Log("2번함수");
        ShowSpot2(2);
        InvokeRepeating("HideSpot2", 1f, 1f);
        Invoke("CancleInvokeHide", 6f);
        //Debug.Log(WhenStart);


    }
    
    // Update is called once per frame
    void Update()
    {
        if (WhenStart == 2)
        {
            ShowSpot2(5);
            
        }
        if (WhenStart == 3)
        {
            ShowSpot2(4);
            
        }
        if (WhenStart == 4)
        {
            ShowSpot2(6);
            
        }
        if (WhenStart == 5)
        {
            ShowSpot2(3);
            allBtnSetTrue();



        }
        int GoalStringint = GoalString.Length;
        if (GoalStringint == 5)
        {
            if (GoalString == "25463")
            {
                Debug.Log("game clear");
                GameManangerScript.TimeAdd((int)MiniGameTimer.timeDuration);
                
            }
            else
            {
                Debug.Log("game over");
                GameManangerScript.TimeSub((int)MiniGameTimer.timeDuration);
            }
        }
        //Debug.Log(GoalString);
        
    }
    public void onClickGame()
    {
        Debug.Log("hi");
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        TextIn = clickObject.GetComponentInChildren<Text>().text;
        Debug.Log(clickObject.name + "," + clickObject.GetComponentInChildren<Text>().text);
        
        if (TextTest == true)
        {
            GoalString += TextIn;
            TextTest = false;
        }
        TextTest = true;
        


    }
    private void ShowSpot2(int BtnNum)
    {
        deActObj = GameObject.Find("Game Button"+BtnNum).transform.Find("Image"+BtnNum).gameObject;
        deActObj.SetActive(true);

    }
    private void HideSpot2()
    {
        ActObj = GameObject.FindWithTag("BtnActive1");
        ActObj.SetActive(false);
        WhenStart ++;
        Debug.Log("hide실행");
    }
    private void CancleInvokeHide()
    {
        
        CancelInvoke("HideSpot2");
    }
    private void allBtnSetFalse()
    {
        for (int temp = 0; temp < 9; temp++)
            SelectBtn[temp].interactable = false;
    }
    private void allBtnSetTrue()
    {
        for (int temp = 0; temp < 9; temp++)
            SelectBtn[temp].interactable = true;
    }
}
