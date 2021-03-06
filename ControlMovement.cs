using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ControlMovement : MonoBehaviour 
{

    private Touch oldTouch1;
    private Touch oldTouch2;

    void Start()
    {

    }

    
    void Update() {
    
        if ( Input.touchCount <= 0 ) {
            return;
        }
        if (1 == Input.touchCount ) {
            Touch touch = Input.GetTouch (0);
            Vector2 deltaPos = touch.deltaPosition;
            transform.Rotate(Vector3.down  * deltaPos.x , Space.World);     
            transform.Rotate(Vector3.right * deltaPos.y , Space.World);    
        }    

        Touch newTouch1 = Input.GetTouch (0);    
        Touch newTouch2 = Input.GetTouch (1);    

        if( newTouch2.phase == TouchPhase.Began ){    
            oldTouch2 = newTouch2;    
            oldTouch1 = newTouch1;    
            return;    
        }    

        float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);    
        float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);    

        float offset = newDistance - oldDistance;  

        float scaleFactor = offset / 100f;
        Vector3 localScale = transform.localScale;    
        Vector3 scale = new Vector3(localScale.x + scaleFactor,    
                                    localScale.y + scaleFactor,     
                                    localScale.z + scaleFactor);    
    
        if (scale.x > 0.1f && scale.y > 0.1f && scale.z > 0.1f) {    
            transform.localScale = scale;    
        }    
  
        oldTouch1 = newTouch1;    
        oldTouch2 = newTouch2;    
    }
}
