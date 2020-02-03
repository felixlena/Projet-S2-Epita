using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarreMana : MonoBehaviour
{

    PlayerCombat pc;
    public UnityEngine.UI.Image barre;
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponentInParent<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (barre != null)
        {
            barre.fillAmount =Mathf.Lerp(barre.fillAmount, (float)(pc.Mana) / pc.ManaMax, 0.1f);
        }
    }
}
