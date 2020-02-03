using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MovePlayer : MonoBehaviour
{

    public Camera cam;
    public bool IsMoving = false;

    public MonsterController target;
    private PlayerAnimator animator;
    public float speed = 5f;
    private Vector3 position;
    public Vector3 Position
    {
        get;
        set;
    }
    private PhotonView photonView;
    private PlayerCombat pc;
    

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        photonView = GetComponent<PhotonView>();
        animator = GetComponent<PlayerAnimator>();
        pc = GetComponent<PlayerCombat>();
        if (!photonView.IsMine)
        {
            Destroy(cam);
        }
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetMouseButton(1)) //recupere position ou se deplacer
            {
                GetPosition();
            }
            Move();
        }
    }


    void GetPosition()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Ground")
        {
            target = null;
            pc.Target = null;
            position = hit.point;
        }
        else if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Monster")
        {
            target = hit.transform.GetComponent<MonsterController>();
            pc.Target = target;
            pc.Selected = target;
            transform.LookAt(target.transform);
            position = new Vector3(hit.point.x, hit.transform.position.y, hit.point.z);
        }

    }

    private void Move()
    {
        if (target != null && Vector3.Distance(transform.position, target.transform.position) <= pc.rangeBasic)
        {
            position = transform.position;
            IsMoving = false;
        }
        if(transform.position != position)
        {
            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime / (Vector3.Distance(transform.position, position) / speed));

        if (Vector3.Distance(transform.position, position) > 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.5f);
        }
    }

}
