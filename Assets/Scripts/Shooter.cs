using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile;
    public Transform spawnLocation;

    private GameObject projectileParent;
    private Animator animator;
    private AttackerSpawner myLaneSpawner;

    private void Start()
    {
        animator = GetComponent<Animator>();

        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            //Debug.Log("No parent, spawning Projectiles parent");
            projectileParent = new GameObject("Projectiles");
        }

        SetLaneSpanwer();
    }

    private void Update()
    {
        if (CheckForAttacker()) {
            animator.SetBool("isAttacking", true);
        } else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpanwer()
    {
        AttackerSpawner[] spawnerArray = GameObject.FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawnerArray)
        {
            if(spawner.transform.position.y == this.transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }
        }

        Debug.LogError(name + " can't find spawner in lane");
    }

    private bool CheckForAttacker()
    {
        // Exit if no attackers in lane
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        foreach(Transform attacker in myLaneSpawner.transform)
        {
            if (attacker.position.x > this.transform.position.x)
            {
                return true;
            }
        }

        return false;
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, spawnLocation);
        newProjectile.transform.parent = projectileParent.transform;
    }
}
