using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMonsterHp : MonoBehaviour
{

    PlayerCombat pc;
    public UnityEngine.UI.Image barre;
    MonsterController actual;
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponentInParent<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.Selected != null && pc.Selected == actual)
        {
            barre.fillAmount = Mathf.Lerp(barre.fillAmount, (float)(pc.Selected.HpMax-pc.Selected.Hp) / pc.Selected.HpMax, 0.1f);
        }
        else if(pc.Selected != null)
        {
            actual = pc.Selected;
            barre.fillAmount = (float)(pc.Selected.HpMax - pc.Selected.Hp)/ pc.Selected.HpMax;

        }
    }
}
