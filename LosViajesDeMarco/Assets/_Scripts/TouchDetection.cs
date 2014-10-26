using UnityEngine;
using System.Collections;

/*
 *This class will detect the touch on a gameObject, you can supply 
 * a layer mask to filter the detection, if no mask is supplied 
 * the Default mask will be used
 */
public abstract class TouchDetection : MonoBehaviour {
    public int layerIndex = -1;

    private int layerMask;
	// Use this for initialization
	protected void Start () {
        if (layerIndex == -1)
        {
            layerMask = Physics2D.DefaultRaycastLayers;
        }
        else
        {
            layerMask = 1 << layerIndex;
        }
	}
	
	// Update is called once per frame
    protected void Update()
    {
        if (Input.touchCount >= 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
                Vector2 touchPos = new Vector2(worldPoint.x, worldPoint.y);

                if (transform.collider2D == Physics2D.OverlapPoint(touchPos, layerMask))
                {
                    OnTouch();
                }
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 touchPos = new Vector2(worldPoint.x, worldPoint.y);
            if (transform.collider2D == Physics2D.OverlapPoint(touchPos, layerMask))
            {
                OnTouch();
            }
        }
    }

    protected abstract void OnTouch();
}
