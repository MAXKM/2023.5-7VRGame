using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Material Gcolor;

    [SerializeField] Mesh Gmesh;
    //ŽG‹›‚ÌMeshRenderer
    private MeshRenderer meshRenderer;

    //ŽG‹›‚ÌMeshfilter
    private MeshFilter meshFilter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SScale(int GloveLevel)
    {
        switch (GloveLevel)
        {
            case 1:
                transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                break;
            case 2:
                transform.localScale = new Vector3(0.21f, 0.21f, 0.21f);
                break;
            case 3:
                transform.localScale = new Vector3(0.22f, 0.22f, 0.22f);
                break;
            case 4:
                transform.localScale = new Vector3(0.23f, 0.23f, 0.23f);
                break;
            case 5:
                transform.localScale = new Vector3(0.23f, 0.23f, 0.23f);    //‰¼
                meshRenderer = GetComponent<MeshRenderer>();
                meshFilter = GetComponent<MeshFilter>();
                meshRenderer.material = Gcolor;
                meshFilter.mesh = Gmesh;
                break;

        }
    }
}
