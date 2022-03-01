using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField] GameObject TopCollider;
    private Animator anim;
    private bool animating;
    private bool open;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        animating = false;
        open = false;
    }
    
    public void ToggleBox()
    {
        if (!animating)
        {
            anim.SetTrigger("Toggle");
            animating = true;
        }
    }

    public void DoneAnimating()
    {
        animating = false;
        if (!open)
        {
            TopCollider.SetActive(false);
        }
        else
        {
            TopCollider.SetActive(true);
        }
        open = !open;
    }

}
