using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightItem : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    [SerializeField] Material defaultMaterial;
    [SerializeField] Material highlightMaterial;
    Outline outline;

    private void Awake()
    {
      //  outline = GetComponent<Outline>();
        meshRenderer = GetComponent<MeshRenderer>();
        ApplyDefaultMaterial();
    }

    public void ApplyDefaultMaterial()
    {
       // outline.OutlineMode = Outline.Mode.OutlineHidden;
      //  meshRenderer.material = defaultMaterial;


    }
    public void ApplyHighlightMaterial()
    {
       // outline.OutlineMode = Outline.Mode.OutlineAll;
       // meshRenderer.material = highlightMaterial;
    }

}
