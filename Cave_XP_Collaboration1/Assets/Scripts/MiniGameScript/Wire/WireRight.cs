using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WireRight : MonoBehaviour
{
    public EWireColor WireColor { get; private set; }

    public bool IsConnected { get; private set; }

    [SerializeField]
    private List<Image> mWireImages;

    private List<WireLeft> mConnectedWires = new List<WireLeft>();

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
        foreach (var image in mWireImages)
        {
            image.color = color;
        }
    }

    public void ConnectWire(WireLeft leftwire)
    {
        if (mConnectedWires.Contains(leftwire))
        {
            return;
        }
        mConnectedWires.Add(leftwire);
        if(mConnectedWires.Count ==1 && leftwire.WireColor == WireColor)
        {
            IsConnected = true;
            Debug.Log("¿¬°á2ÀßµÊ");
        }
        else
        {
            IsConnected = false;
            Debug.Log("¿¬°á2ÀßµÊ");
        }

    }
    public void DisconnectedWire(WireLeft leftWire)
    {
        mConnectedWires.Remove(leftWire);

        if (mConnectedWires.Count == 1 && mConnectedWires[0].WireColor == WireColor)
        {
            IsConnected = true;
            Debug.Log("¿¬°á1ÀßµÊ");
        }
        else
        {
            IsConnected = false;
            Debug.Log("¿¬°á1¾ÈµÊ");
        }
    }

}

