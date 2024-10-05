using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAspectRatio : MonoBehaviour
{
    // Start is called before the first frame update
   /* void Start()
{
    float targetAspect = 16.0f / 9.0f;

    float windowAspect = (float)Screen.width / (float)Screen.height;
    float scaleHeight = windowAspect / targetAspect;
    if (scaleHeight < 1.0f)
    {
        Camera.main.rect = new Rect(0, (1.0f - scaleHeight) / 2.0f, 1.0f, scaleHeight);
    }
    else
    {
        float scaleWidth = 1.0f / scaleHeight;
        Camera.main.rect = new Rect((1.0f - scaleWidth) / 2.0f, 0, scaleWidth, 1.0f);
    }
}*/

    void Update()
    {
        
    }
}
