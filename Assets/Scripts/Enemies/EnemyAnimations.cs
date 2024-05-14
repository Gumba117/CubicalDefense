using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{

    private bool isHitten = false;
    private Animator enemyAnimator;

    private void OnEnable()
    {
        enemyAnimator = GetComponent<Animator>();
    }
    public void EnemyHitAnim()
    {
        if (!isHitten)
        {
            enemyAnimator.SetTrigger("enemyHit");
        }
    }
    public void WaitForHitAnim()
    {
        isHitten = true;
    }
    public void ResetHitAnim()
    {
        isHitten = false;
    }
}
