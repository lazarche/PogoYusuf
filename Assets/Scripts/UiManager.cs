using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI txtPoint, txtStart;
    [SerializeField] GameObject winBtn, loseBtn;
    public static UiManager instance;
    int money = 0;

    
    void Awake()
    {
        instance = this;
    }

    public void addMoney(int c) {
        money += c;
        txtPoint.text = money +"";
    }
    public int getMoney() {
        return money;
    }

    public void StartLevel() {
        txtStart.gameObject.SetActive(false);
    }

    public void WinLevel() {
        winBtn.SetActive(true);        
    }

    public void LoseLevel() {
        loseBtn.SetActive(true);
    }
    
}
