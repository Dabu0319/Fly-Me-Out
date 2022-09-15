using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class AwakeScreenEffect : MonoBehaviour
{

    private bool opening =true;
    [Range(0f, 1f)]
    [Tooltip("苏醒进度")]
    public float progress;

    [Range(0f, .3f)]
    [Tooltip("弧度")]
    public float archHeight;

    public Shader shader;

    [SerializeField]
    Material material;
    Material Material   
    {
        get
        {
            if (material == null)
            {
                material = new Material(shader);
                material.hideFlags = HideFlags.DontSave;
            }
            return material;
        }
    }

    void OnDisable()
    {
        if (material)
        {
            DestroyImmediate(material);
        }
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Material.SetFloat("_Progress", progress);
        Material.SetFloat("_ArchHeight", archHeight);
        Graphics.Blit(src, dest, material);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (progress > 1f || archHeight > 0.3f)
            {
                opening = false;
                return;
            }
            else
            {
                progress += 0.001f;
                archHeight += 0.0005f;
            }
        }
        else if (opening)
        {
            if (progress <= 0f || archHeight <= 0f)
            {
                return;
            }
            else
            {
                progress -= 0.001f;
                archHeight -= 0.0005f;
            }
        } else
        {
            if (progress < 1f)
            {
                progress += 0.001f;
            }
            if (archHeight < 3f)
            {
                archHeight += 0.0005f;
            }
        }
    }
}