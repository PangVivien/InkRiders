using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateUI : MonoBehaviour
{
    private Animator animator;
    private Image image;

    void Start()
    {
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();

        if (animator != null)
        {
            animator.SetTrigger("Play"); 
        }
    }
}
