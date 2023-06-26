using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HotbarSlots : MonoBehaviour
{
    public InventoryObject hotbarInventory;
    public float slotSpacing;

    public Dictionary<InventorySlot,GameObject> dropsDisplayed = new Dictionary<InventorySlot,GameObject>();
    void Start()
    {
        CreateDisplay();
    }

    
    void Update()
    {
        UpdateDisplay();
        for (int i = 0; i < hotbarInventory.Container.Count; i++)
        {
            if (hotbarInventory.Container[i].amount >= hotbarInventory.slotSize)
            {
                print("cu enorme");
            }
        }
    }

    public void CreateDisplay()
    {
        for(int i = 0; i < hotbarInventory.Container.Count; i++)
        {
            var obj = Instantiate(hotbarInventory.Container[i].drop.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = new Vector3 ((-119+i *slotSpacing),-150f,0f);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = hotbarInventory.Container[i].amount.ToString();
            var image = obj.gameObject.transform.GetChild(1);
            image.GetComponent<Image>().sprite = hotbarInventory.Container[i].drop.hotbarSprite;
            dropsDisplayed.Add(hotbarInventory.Container[i], obj);
        }
    }

    public void UpdateDisplay()
    {
        for (int i = 0;i<hotbarInventory.Container.Count;i++)
        {
            if (dropsDisplayed.ContainsKey(hotbarInventory.Container[i]))
            {
                dropsDisplayed[hotbarInventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = hotbarInventory.Container[i].amount.ToString();
            }
            else
            {
                var obj = Instantiate(hotbarInventory.Container[i].drop.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = new Vector3((-119 + i * slotSpacing), -150f, 0f);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = hotbarInventory.Container[i].amount.ToString();
                var image = obj.gameObject.transform.GetChild(1);
                image.GetComponent<Image>().sprite = hotbarInventory.Container[i].drop.hotbarSprite;
                dropsDisplayed.Add(hotbarInventory.Container[i], obj);
            }
        }
    }
}


