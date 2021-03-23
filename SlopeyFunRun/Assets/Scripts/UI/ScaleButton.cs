using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleButton : MonoBehaviour
{
    RectTransform rectTransform;
    // Start is called before the first frame update
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScaleUp()
    {
        rectTransform.localScale = new Vector3(1.1f, 1.1f);
    }

    public void ScaleNormal()
    {
        rectTransform.localScale = new Vector3(1, 1);
    }
}
