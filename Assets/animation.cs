using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class animation : MonoBehaviour
{
    public Animator animator;
    public ThirdPersonController ct;
    public bool moving;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ct = GetComponent<ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
