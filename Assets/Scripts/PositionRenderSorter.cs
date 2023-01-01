using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRenderSorter : MonoBehaviour
{
    private int sortingOrderBase = 5000;
    private Renderer myRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }
    void LateUpdate()
    {

    }
}
