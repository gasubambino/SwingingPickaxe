using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GoldText : MonoBehaviour
{
    private TextMeshProUGUI text;
    public PlayerTrigger playerTrigger;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //int goldCount = playerTrigger.goldCount;
        //string goldCountText = goldCount.ToString();
        text.text = playerTrigger.goldCount.ToString();
    }
}
