using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarreDeVieMonster : MonoBehaviour
{

    MonsterController mc;
    public Image fond;
    public Image barre;
    // Start is called before the first frame update
    void Start()
    {
        mc = GetComponentInParent<MonsterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mc.Hp != mc.HpMax)
        {
            fond.enabled = true;
            barre.enabled = true;
        }
        barre.fillAmount =  Mathf.Lerp(barre.fillAmount, (float)(mc.HpMax-mc.Hp) / mc.HpMax, 0.1f);
        if (mc.IsDead)
        {
            fond.enabled = false;
            barre.enabled = false;
            enabled = false;
        }
    }
}
