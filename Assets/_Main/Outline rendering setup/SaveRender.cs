using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveRender : MonoBehaviour
{
    [SerializeField] RenderTexture rt;
    [SerializeField] bool capture;

    Camera captureCamera;
    [SerializeField] int counter;

    private void Awake() {
        captureCamera = Camera.main;
    }

    void Update()
    {
        if (capture && counter < 30)
        {
            SaveTexture();
            counter++;
        }
    }

    public void SaveTexture () {
        byte[] bytes = toTexture2D(rt).EncodeToPNG();
        System.IO.File.WriteAllBytes(@$"C:\Users\Asus\Desktop\Unity Render\Outline_{counter}.png", bytes);
    }

    Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }
}