using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    [SerializeField] private bool isStatic;
    [SerializeField] private float offset = 0f;
    private int sortingOrderBase = 5;
    private Renderer renderer;
    private int sortindOrder;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        renderer.sortingOrder = (int)(sortingOrderBase - transform.position.y + offset);

        if (isStatic)
        {
            Destroy(this);
        }
    }
}
