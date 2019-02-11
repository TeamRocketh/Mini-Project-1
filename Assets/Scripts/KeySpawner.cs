using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeySpawner : MonoBehaviour
{
    public List<string> alldials;

    public GameObject frontGround;

    public GameObject key;
    public GameObject dialogues;

    bool trig = false;
    Vector3 pos = Vector3.zero;

    int dial = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fire")
        {
            dialogues.SetActive(true);
            frontGround.SetActive(false);
            dialogues.transform.GetChild(0).gameObject.SetActive(true);
            dialogues.transform.GetChild(3).gameObject.SetActive(true);
            trig = true;
            pos = other.transform.position;
        }
    }

    private void Update()
    {
        if (trig)
            Time.timeScale = 0;
        else Time.timeScale = 1;

        if (trig && Input.GetKeyDown(KeyCode.Space) && dial > 4)
        {
            trig = false;
            Instantiate(key, pos + new Vector3(0, 2, 0), Quaternion.identity);
            Time.timeScale = 1;
            dialogues.SetActive(false);
            dialogues.transform.GetChild(0).gameObject.SetActive(false);
            dialogues.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && dial <= 4)
        {
            dialogues.transform.GetChild(3).transform.GetChild(0).gameObject.GetComponent<Text>().text = alldials[dial];
            if (dial % 2 == 0)
                dialogues.transform.GetChild(3).transform.GetChild(0).gameObject.GetComponent<Text>().color = Color.white;
            else
                dialogues.transform.GetChild(3).transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1, 0.9f, 0.35f);
            dial++;
        }
    }
}
