using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public float attackRange = 1f;
    public float attackDamage = 10f;
    public float runSpeed = 2f;
    public float attackDuration = 1f;
    public float attackCooldown = 1f;
    public string dieSoundName;
    public string attackSoundName = "ZombieAttack";
    public string primaryTargetTag = "Tower";
    public string runAnimationName = "ZombieRun";
    public string attackAnimationName = "ZombieAttack";
    public string dieAnimationName = "ZombieDie";
    public string winAnimationName = "ZombieWin";
}
