using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenButton : MonoBehaviour
{
    public GameObject inventoryPanel;   //인벤토리 패널
    bool activeInven;       //인벤 패널 활성화 상태

    private void Start()
    {
        
        inventoryPanel.SetActive(activeInven);      //인벤 비활성화
    }
    void Update()
    {
        
    }

    public void getButton()
    {
        Debug.Log("클릭");
        Debug.Log(GameManangerScript.timeGo);
        activeInven = !activeInven;     //버튼 누를때 마다 활성 or 비활성
        inventoryPanel.SetActive(activeInven);      // bool값 적용
        GameManangerScript.timeGo = !GameManangerScript.timeGo;
        
    }
}
