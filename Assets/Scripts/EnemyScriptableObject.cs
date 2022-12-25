using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Configuration", menuName = "ScriptableObject/Enemy Configuration")]
public class EnemyScriptableObject : ScriptableObject
{

    public float enemyHealth = 15;
    public float enemyDamage = 2;
    public float enemySpeed = 2;
    public float enemyScore = 2;
}
