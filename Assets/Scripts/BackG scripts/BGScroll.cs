using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scroll_Speed = 0.4f;
    private MeshRenderer mesh_Renderer;

    void Awake()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();//stvaramo referencu na meshRenderer komponentu
    }
    
    void Update()
    {
        Scroll();//pozivamo scroll
    }
    
    void Scroll()
    {
        
        Vector2 offset = mesh_Renderer.sharedMaterial.GetTextureOffset("_MainTex"); //glavna tekstura
        offset.y += Time.deltaTime * scroll_Speed;  //da se stvori scroll effect

        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
    