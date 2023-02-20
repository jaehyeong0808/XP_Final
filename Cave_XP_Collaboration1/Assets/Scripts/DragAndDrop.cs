using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Vector2 DefaultPos;
    public static Vector2 EmptyPos;
    public GameObject EmptyObj;
    public int emptyNum;
    public string AlpName;

    private bool onImage=false;

    // Start is called before the first frame update
    void Start()
    {
        AlpName = this.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        DefaultPos = this.transform.position;
        Debug.Log("클릭");
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position;
        this.transform.position = currentPos;
        

    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (onImage == true)
        {
            EmptyPos = EmptyObj.transform.position;
            this.transform.position = EmptyPos;
        }
        else if(onImage == false)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = DefaultPos;
        }
        

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Empty")
        {
            EmptyObj = collision.gameObject;
            Debug.Log("충돌");
            onImage = true;
            string emptyName =collision.gameObject.name;
            int emptyNum = int.Parse(emptyName.Substring(5, 1));
            AnagramScr.clearWord[emptyNum] = AlpName;
        }
        

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Empty")
        {
            Debug.Log("충돌해재");
            onImage = false;
            EmptyObj = null;
        }
    }
}
