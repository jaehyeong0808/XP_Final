using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnagramScr : MonoBehaviour
{
    public static string[] clearWord= new string[6]; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string tempWord = clearWord[0] + clearWord[1] + clearWord[2] + clearWord[3] + clearWord[4] + clearWord[5];

        //Debug.Log(clearWord[0]+ clearWord[1]+ clearWord[2]+ clearWord[3]+ clearWord[4]+ clearWord[5]);
        if (tempWord == "LOVEME")
        {
            Debug.Log("gameclear");
        }
    }
}
