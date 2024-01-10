using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightItem : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    [SerializeField] Material defaultMaterial;
    [SerializeField] Material highlightMaterial;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void ApplyDefaultMaterial()
    {
        meshRenderer.material = defaultMaterial;

    }
    public void ApplyHighlightMaterial()
    {
        meshRenderer.material = highlightMaterial;
    }

}
