using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleHUD : MonoBehaviour
{
   
    public Text nameText;
    public Text levelText;
    public Slider hpSlider;
    public Image ElementIcon;

    public void SetHUD(Unit unit){
        nameText.text = unit.unitName;
        levelText.text = "Lvl " + unit.unitLevel;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

    public void setHP(int hp){
        hpSlider.value = hp;
    }


}
