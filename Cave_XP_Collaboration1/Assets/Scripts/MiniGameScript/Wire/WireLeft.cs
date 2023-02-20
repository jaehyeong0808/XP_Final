using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WireLeft : MonoBehaviour
{
    public EWireColor WireColor { get; private set; }

    public bool IsConnected { get; private set; }

    [SerializeField]
    private List<Image> mWireImages;

    [SerializeField] 
    private RectTransform mWireBody;

    [SerializeField]
    private WireRight mConnectedWire;


    private Canvas mGameCanvas;

    // Start is called before the first frame update
    void Start()
    {
        mGameCanvas = FindObjectOfType<Canvas>();
        
    }


    
    public void SetTarget(Vector3 targetPosition,float offset)
    {
        float angle = Vector2.SignedAngle(transform.position + Vector3.right - transform.position, targetPosition - transform.position);
        float distance = (Vector2.Distance(mWireBody.transform.position, targetPosition) + offset);
        mWireBody.localRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        mWireBody.sizeDelta = new Vector2(distance * (1 / mGameCanvas.transform.localScale.x), mWireBody.sizeDelta.y);
    }

    public void ResetTarget()
    {
        mWireBody.localRotation = Quaternion.Euler(Vector3.zero);
        mWireBody.sizeDelta = new Vector2(0f, mWireBody.sizeDelta.y);
    }
    public void SetWireColor(EWireColor wireColor)
    {
        
        WireColor = wireColor;
        Color color = Color.black;
        switch (WireColor)
        {
            case EWireColor.Red:
                color = Color.red;
                break;

            case EWireColor.Green:
                color = Color.green;
                break;

            case EWireColor.Blue:
                color = Color.blue;
                break;

            case EWireColor.Yellow:
                color = Color.yellow;
                break;
        }
        foreach(var image in mWireImages)
        {
            image.color = color;
        }
    
    }
    public void ConnectWire(WireRight rightWire)
    {
        if(mConnectedWire!=null&&mConnectedWire != rightWire)
        {
            mConnectedWire.DisconnectedWire(this);
            mConnectedWire = null;
        }

        mConnectedWire = rightWire;
        if(mConnectedWire.WireColor == WireColor)
        {
            IsConnected = true;
        }
    }
    public void DisconnectWire()
    {
        if(mConnectedWire != null)
        {
            mConnectedWire.DisconnectedWire(this);
            mConnectedWire = null;

        }
        IsConnected = false;
    }

}
