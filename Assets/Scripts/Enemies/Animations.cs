using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    void Death() {
        animator.SetBool("Dead", true);
    }

    public void AfterDeathAnimation() {
        Destroy(gameObject);
    }
}
