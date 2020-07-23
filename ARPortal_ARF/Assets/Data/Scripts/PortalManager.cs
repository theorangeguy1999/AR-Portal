using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PortalManager : MonoBehaviour
{
    public GameObject MCam;
    public GameObject Sponza;

    private Material[] SponzaMat;

    // Start is called before the first frame update
    void Start()
    {
        SponzaMat = Sponza.GetComponent<Renderer>().sharedMaterials;
    }

    // Update is called once per frame
    void OnTriggerStay(Collider collider)
    {

        Debug.Log("Collision");
        Vector3 CamPosinPSpace = transform.InverseTransformPoint(MCam.transform.position);

        if(CamPosinPSpace.y < 0.5f)
        {
           for(int i = 0 ; i<SponzaMat.Length; i++)
           {
               Debug.Log("value set");
               SponzaMat[i].SetInt("_StencilComp",(int)CompareFunction.Always);
           } 
        }
        else
        {
            for(int i = 0 ; i<SponzaMat.Length; i++)
           {
                Debug.Log("value unset");
               SponzaMat[i].SetInt("_StencilComp",(int)CompareFunction.Equal);
           } 

        }
        
    }
}
