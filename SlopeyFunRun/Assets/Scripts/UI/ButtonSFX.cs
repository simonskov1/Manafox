using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    [SerializeField]
    AudioSource mySource;
    [SerializeField]
    AudioClip clickSFX;
    [SerializeField]
    AudioClip hoverSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickSound()
    {
        mySource.PlayOneShot(clickSFX);
    }

    public void HoverSound()
    {
        mySource.PlayOneShot(hoverSFX);
    }
}
