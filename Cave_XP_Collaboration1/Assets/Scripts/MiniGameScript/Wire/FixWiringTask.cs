using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum EWireColor
{
    None = -1,
    Red,
    Blue,
    Green,
    Yellow,

}

public class FixWiringTask : MonoBehaviour
{
    [SerializeField]
    private List<WireLeft> mLeftWires;

    [SerializeField]
    private List<WireRight> mRightWires;

    private WireLeft mSelectedWire;

    private void OnEnable()
    {
        List<int> numberPool = new List<int>();
        for (int i = 0; i < 4; i++)
        {
            numberPool.Add(i);
        }
        int index = 0;
        while(numberPool.Count != 0)
        {
            var number = numberPool.Max();
            mLeftWires[index++].SetWireColor((EWireColor)number);
            numberPool.Remove(number);
        }
        for (int i = 0; i < 4; i++)
        {
            numberPool.Add(i);
        }
        index = 0;
        while (numberPool.Count != 0)
        {
            var number = numberPool.Min();
            mRightWires[index++].SetWireColor((EWireColor)number);
            numberPool.Remove(number);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.right, 1f);
            if (hit.collider != null)
            {
                var left = hit.collider.GetComponentInParent<WireLeft>();
                if (left != null)
                {
                    mSelectedWire = left;

                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (mSelectedWire != null)
            {
                RaycastHit2D[] hits = Physics2D.RaycastAll(Input.mousePosition, Vector2.right, 1f);
                foreach (var hit in hits)
                {
                    if (hit.collider != null)
                    {
                        var right = hit.collider.GetComponentInParent<WireRight>();
                        if (right != null)
                        {
                            mSelectedWire.SetTarget(hit.transform.position, -50f);
                            mSelectedWire.ConnectWire(right);
                            right.ConnectWire(mSelectedWire);
                            mSelectedWire = null;
                            CheckCompleteTask();
                            return;
                        }
                    }
                }

                mSelectedWire.ResetTarget();
                mSelectedWire.DisconnectWire();
                mSelectedWire = null;
                CheckCompleteTask();
            }
        }

        if (mSelectedWire != null)
        {
            mSelectedWire.SetTarget(Input.mousePosition, -15f);

        }
    }
    public void CheckCompleteTask()
    {
        bool isAllComplete = true;
        foreach(var wire in mLeftWires)
        {
            if (!wire.IsConnected)
            {
                isAllComplete = false;
                break;
            }  
        
        }
        if (isAllComplete)
        {
            Debug.Log("clear");
            GameManangerScript.TimeAdd((int)MiniGameTimer.timeDuration);
            GameManangerScript.wireClear = true;
        }

    }
}
