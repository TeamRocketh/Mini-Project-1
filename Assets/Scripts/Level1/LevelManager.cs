using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> TBI;
    public List<GameObject> TBAA;
    public GameObject Black;

    List<GameObject> TBA;

    public Material Ill;

    public static bool ill = false;

    private void Start()
    {
        TBA = new List<GameObject>();

        /*for (int i = 0; i < Black.transform.childCount; i++)
        {
            TBA.Add(Black.transform.GetChild(i).gameObject);
            Black.transform.GetChild(i).gameObject.SetActive(false);
        }*/
    }

    void Update()
    {
        if (ill)
        {
            for (int i = 0; i < TBI.Count; i++)
            {
                TBI[i].GetComponent<Renderer>().material = Ill;
            }
            /*for (int i = 0; i < TBA.Count; i++)
            {
                TBA[i].SetActive(true);
            }
            for (int i = 0; i < TBAA.Count; i++)
            {
                TBAA[i].SetActive(true);
            }*/
        }
    }
}
