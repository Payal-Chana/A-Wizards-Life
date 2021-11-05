using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Vector3 minScale;
    public Vector3 maxScale;
    public bool repeatable;
    public float speed = 2f;
    public float Duration= 5f;
    
    IEnumerator Start()
    {
        minScale = transform.localScale;
        while (repeatable){
            yield return RepeatLerp(minScale, maxScale, Duration);
            yield return RepeatLerp(maxScale, minScale, Duration);

        }
    }
    public IEnumerator RepeatLerp( Vector3 a, Vector3 b, float time)
    {
        float i = 0f;
        float rate = (1.0f / time)* speed;
        while (i < 1.0f)
        {
            i = i + Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
   

   
}
