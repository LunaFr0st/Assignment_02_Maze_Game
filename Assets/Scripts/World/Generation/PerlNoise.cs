using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PerlNoise : MonoBehaviour
{

    public int pixWidth;
    public int pixHeight;
    public float xOrg;
    public float yOrg;
    public float scale = 1.0F;
    public Texture2D noiseTex;
    private Color[] pix;
    private Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        noiseTex = new Texture2D(pixWidth, pixHeight);
        pix = new Color[noiseTex.width * noiseTex.height];
        rend.material.mainTexture = noiseTex;
    }
    void CalcNoise()
    {
        float y = 0.0F;
        while (y < noiseTex.height)
        {
            float x = 0.0F;
            while (x < noiseTex.width)
            {
                float xCoord = xOrg + x / noiseTex.width * scale;
                float yCoord = yOrg + y / noiseTex.height * scale;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                pix[(int)y * noiseTex.width + (int)x] = new Color(sample, sample, sample);
                x++;
            }
            y++;
        }
        noiseTex.SetPixels(pix);
        noiseTex.Apply();
        SaveTexture(noiseTex, "perlynoisey");

    }
    void Update()
    {
        CalcNoise();
    }
    void SaveTexture(Texture2D _texture, string fileName)
    {
        byte[] bytes = noiseTex.EncodeToPNG();
        FileStream fs = File.Open(Application.dataPath + "/Textures/" + fileName + ".png", FileMode.Create);
        BinaryWriter bin = new BinaryWriter(fs);
        bin.Write(bytes);
        fs.Close();
    }

}
