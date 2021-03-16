using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{
    [SerializeField]
    Animator characterAnimator;
    [SerializeField]
    Animator boardAnimator;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float tilt = Input.GetAxis("Horizontal");
        characterAnimator.SetFloat("Tilt", tilt);
        boardAnimator.SetFloat("Tilt", tilt);
    }
}
