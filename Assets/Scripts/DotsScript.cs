using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DotsScript : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    public Image dots;
    
    // Start is called before the first frame update
    void Start()
    {
        dots = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        dots.sprite = sprites[FindObjectOfType<PlayerController>().currentDashCharge];
    }
}
