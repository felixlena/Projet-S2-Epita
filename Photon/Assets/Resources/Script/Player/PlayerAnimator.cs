using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerAnimator : MonoBehaviour
{

    public Dictionary<string, AnimationClip> animations = new Dictionary<string, AnimationClip>();

    private PhotonView photonView;
    private Animator animator;
    private MovePlayer mp;
    private PlayerCombat pc;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        animator = GetComponent<Animator>();
        mp = GetComponent<MovePlayer>();
        pc = GetComponent<PlayerCombat>();

        InitDico();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            animator.SetBool("IsMoving", mp.IsMoving);
            animator.SetBool("IsAttacking", pc.IsAttacking);
        }
    }

    public void Lunch(string ani)
    {
        animator.SetTrigger(ani);
    }

    public void InitDico()
    {
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;    //Get Animator controller
        for (int i = 0; i < ac.animationClips.Length; i++)                 //For all animations
        {
            Debug.Log(ac.animationClips[i].name);
            animations.Add(ac.animationClips[i].name, ac.animationClips[i]);

        }
    }
}
