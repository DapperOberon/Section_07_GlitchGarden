using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Piggy : MonoBehaviour
{

    private Attacker attackerScript;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        attackerScript = gameObject.GetComponent<Attacker>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (!obj.GetComponent<Defender>())
        {
            return;
        }

        animator.SetBool("isAttacking", true);
        attackerScript.Attack(obj);
    }
}
