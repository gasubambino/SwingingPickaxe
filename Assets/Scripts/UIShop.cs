using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShop : MonoBehaviour
{
    public PlayerTrigger playerTrigger;
    public Item1 item1;
    private Transform container;
    private Transform shopItemTemplate;

    bool shopOpen = false;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.transform.Find("shopItemTemplate");
        container.gameObject.SetActive(false);
        shopItemTemplate.GetComponent<Button_UI>().ClickFunc = () =>
        {
            TryBuyItem();
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)&&shopOpen==false)
        {
            container.gameObject.SetActive(true);
            shopOpen = true;
        }else if (Input.GetKeyDown(KeyCode.Tab) && shopOpen == true)
        {
            container.gameObject.SetActive(false);
            shopOpen = false;
        }
    }
    private void TryBuyItem()
    {
        if (GameManager.Instance.playerGoldCount >= item1.price)
        {
            GameManager.Instance.playerGoldCount -= item1.price;
            //oreInfo.oreDrop += 4;
            item1.price += 20;
        }
        else
        {

        }
    }
}
