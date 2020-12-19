using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRenderController : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private RectTransform itemRect;
    private Camera mainCamera;
    private bool visible;

    private void Start()
    {
        itemRect = gameObject.GetComponent<RectTransform>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (itemRect.IsVisibleFrom(mainCamera))
            panel.SetActive(true);
        else
            panel.SetActive(false);
    }
}
