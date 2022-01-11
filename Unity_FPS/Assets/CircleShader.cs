using UnityEngine;
 
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CircleShader : MonoBehaviour
{
    [SerializeField]
    public float intencity = 0.5f;
 
    [SerializeField]
    private Material _material { get; set; }
 
    private void OnEnable()
    {
        if (_material == null)
        {
            Shader _shader = Shader.Find("Custom/CircleShader");
            _material = new Material(_shader)
            {
                hideFlags = HideFlags.DontSave
            };
        }
    }
 
    void OnDisable()
    {
        DestroyImmediate(_material);
    }
 
    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        _material.SetFloat("_Intencity", intencity);
        Graphics.Blit(source, destination, _material, 0);
    }
}