using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftBar : MonoBehaviour
{
    public float Max;
    public float Cur;
    public Image Mask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fill = Cur / Max;
        Mask.fillAmount = fill;
    }
}
