using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public enum InfoType{ exp,level,kill,Time,health}
    public InfoType type;

    Text myText;
    Slider mySlider;

    void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.exp:
            float curExp = GameManager.instance.exp;
            float maxExp = GameManager.instance.nextExp[GameManager.instance.level];
            mySlider.value = curExp / maxExp;
            break;
            case InfoType.level:
            myText.text = string.Format("LV.{0:F0}",GameManager.instance.level);
            break;
            case InfoType.kill:
             myText.text = string.Format("{0:F0}",GameManager.instance.kill);
            break;
            case InfoType.Time:
            float remainTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
            int min = Mathf.FloorToInt(remainTime /60);
            int sec = Mathf.FloorToInt(remainTime % 60);
            myText.text = string.Format("{0:D2}:{1:D2}",min,sec);
            break;
            case InfoType.health:
            float curHealth = GameManager.instance.health;
            float maxHealth = GameManager.instance.maxHealth;
            mySlider.value = curHealth / maxHealth;
            break;
        }
    }

}
