using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    public GameObject[] attackers;
    private Attacker attackerScript;

    public void Update()
    {
        foreach (GameObject thisAttacker in attackers)
        {
            if(isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
    }

    public void Spawn (GameObject myGO)
    {
        GameObject myAttacker = Instantiate(myGO) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
    }

    bool isTimeToSpawn (GameObject attackerGO)
    {
        attackerScript = attackerGO.GetComponent<Attacker>();
        float spawnDelay = attackerScript.spawnRate;
        float spawnPerSecond = 1 / spawnDelay;

        if (Time.deltaTime > spawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by frame rate!");
        }

        float threshold = spawnPerSecond * Time.deltaTime / 5;

        if(Random.value < threshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}