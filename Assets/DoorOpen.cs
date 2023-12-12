using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public Transform player;
    private Transform door1;
    private Transform door2;

    private void Start()
    {
        door1 = transform.GetChild(0);
        door2 = transform.GetChild(1);
    }
    private void Update()
    {
        if ((Vector3.Distance(door1.position, player.position) <= 5) | (Vector3.Distance(door2.position, player.position) <= 5))
        {
            anim.SetBool("IsPlayerClose", true);
        } else
        {
            anim.SetBool("IsPlayerClose", false);
        }
    }
}