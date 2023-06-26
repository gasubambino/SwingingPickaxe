using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public int slotSize = 3;
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddDrop(DropObject _drop, int _amount)
    {
        bool hasDrop = false;
        for (int i = 0; i < Container.Count; i++)
        {            
                if (Container[i].drop == _drop)
                {
                    Container[i].amount += _amount;
                    hasDrop = true;
                    break;
                }                               
        }
        if (!hasDrop)
        {
            Container.Add(new InventorySlot(_drop, _amount));
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public DropObject drop;
    public int amount;
    public InventorySlot(DropObject _drop, int _amount)
    {
        drop = _drop;
        amount = _amount;
    }
}