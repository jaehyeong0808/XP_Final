using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour
{
    public GameObject ex_panel;     //설명 패널
    private bool ex_plainPanel_show = false;    // 설명 패널 비활성화

    // Start is called before the first frame update
    void Start()
    {
        ex_panel.SetActive(ex_plainPanel_show);    // 설명 패널 비활성화
    }


    public void ButtonInput()
    {
        ex_plainPanel_show = !ex_plainPanel_show;   //버튼 누를때 마다 활성 or 비활성
        ex_panel.SetActive(ex_plainPanel_show);     //bool값 적용
    }
}