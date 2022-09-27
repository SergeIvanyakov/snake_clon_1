using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    public Material d1;
    public Material d2;
    public Material d3;
    public Material d4;
    public Material d5;
    public Material h1;
    public Material h2;
    public Material h3;

    private void Awake()
    {
       // UpdateMat();
    }

    private void UpdateMat()
    {
        int numberColor = (int)(Random.Range(1, 9) / 1);
        Renderer blockRenderer = GetComponent<Renderer>();
        switch (numberColor)
        {
            case 1: 
                blockRenderer.sharedMaterial = d1;
                break;
            case 2:
                blockRenderer.sharedMaterial = d2;
                break;
            case 3:
                blockRenderer.sharedMaterial = d3;
                break;
            case 4:
                blockRenderer.sharedMaterial = d4;
                break;
            case 5:
                blockRenderer.sharedMaterial = d5;
                break;
            case 6:
                blockRenderer.sharedMaterial = h1;
                break;
            case 7:
                blockRenderer.sharedMaterial = h2;
                break;
            default:
                blockRenderer.sharedMaterial = h3;
                break;
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateMat();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y < -2) Destroy(this.gameObject);
    }
}
