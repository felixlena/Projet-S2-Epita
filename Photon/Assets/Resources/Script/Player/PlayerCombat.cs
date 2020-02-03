using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerCombat : MonoBehaviour
{
    public Camera cam;
    [SerializeField]
    private MonsterController target;
    public MonsterController Target
    {
        get { return target; }
        set { target = value; }
    }
    [SerializeField]
    private MonsterController selected;
    public MonsterController Selected
    {
        get { return selected; }
        set { selected = value; }
    }
    SelectionSort selectionSort;
    private PlayerAnimator pa;
    private MovePlayer mp;
    private PhotonView photonView;
    public PhotonView PhotonView => photonView;
    private bool isDead = false;
    public bool IsDead => isDead;
    [SerializeField]
    private bool ko = false;
    public bool IsKo
    {
        get
        {
            return ko;
        }
        set
        {
            ko = value;
        }
    }
    [SerializeField]
    private int hp;
    [SerializeField]
    private int hpMax = 100;
    public int HpMax => hpMax;
    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            if (value < 0)
            {
                hp = 0;
                IsKo = true;
            }
            else if (value > hpMax)
            {
                hp = hpMax;
            }
            else
            {
                hp = value;
            }
        }
    }


    [SerializeField]
    private int manaMax = 100;
    public int ManaMax => manaMax;
    [SerializeField]
    private int mana;
    public int Mana
    {
        get
        {
            return mana;
        }

        set
        {
            if (value <= 0)
            {
                mana = 0;
            }
            else if (value > manaMax)
            {
                mana = manaMax;
            }
            else
            {
                mana = value;
            }
        }
    }
    [SerializeField]
    private int regenManaSc = 1;

    public float rangeBasic = 1.5f;
    public bool IsAttacking = false;

    [SerializeField]
    private Transform castPoint;
    public Transform CastPoint => castPoint;
    [SerializeField]
    private Transform auraPoint;
    public Transform AuraPoint => auraPoint;

    public GameObject[] sorts;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        mp = GetComponent<MovePlayer>();
        pa = GetComponent<PlayerAnimator>();
        selectionSort= GetComponent<SelectionSort>();
        cam = mp.cam;
        Hp = hpMax;
        Mana = manaMax;
        StartCoroutine(RegenManaCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            Attack();
            GetInput();
        }
    }

    void GetInput()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Select();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            selectionSort.Cast(0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            selectionSort.Cast(1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            selectionSort.Cast(2);
        }
    }

    void Select()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Ground")
        {
            selected = null;
        }
        else if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Monster")
        {
            selected = hit.transform.GetComponent<MonsterController>();
        }

    }

    void Attack()
    {
        if (target != null && target.IsKo)
        {
            target = null;
        }
        if (target != null && rangeBasic >= Vector3.Distance(target.transform.position, transform.position) && !IsAttacking)
        {
            mp.Position = transform.position;
            transform.LookAt(target.transform);
            mp.IsMoving = false;
            IsAttacking = true;
            StartCoroutine(BasicAttack());
        }
        else if (target == null)
        {
            IsAttacking = false;
        }
    }

    IEnumerator BasicAttack()
    {
        yield return new WaitForSeconds(pa.animations["BasicAttack"].length);
        IsAttacking = false;
        if (target != null && Vector3.Distance(transform.position, target.transform.position)<=rangeBasic)
        {
            target.PhotonView.RPC("GetHurt", RpcTarget.All, 10);
        }
        if (IsAttacking)
        {
            StartCoroutine(BasicAttack());
        }
    }

    [PunRPC]
    public void GetHurt(int dommages)
    {
        Hp -= dommages;
    }

    [PunRPC]
    public void UseMana(int manaCost)
    {
        Mana -= manaCost;
    }

    IEnumerator RegenManaCoroutine()
    {
        void RegenMana()
        {
            Mana += regenManaSc;
        }

        while (true)
        {
            yield return new WaitForSeconds(1f);
            RegenMana();
        }
    }


}
