using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Wegpunkt : MonoBehaviour
{
    public RectTransform prefab;
    public String bezeichner;
    private RectTransform wegpunkt;
    private Transform player;
    private TextMeshProUGUI bezeichnung;
    private TextMeshProUGUI distanz;
    private Vector3 offset = new Vector3(0, 25, 0);

    // Start is called before the first frame update
    void Start()
    {
        var canvas = GameObject.Find("Wegpunkt Canvas").transform;
        wegpunkt = Instantiate(prefab, canvas);
        player = GameObject.Find("XR Origin").transform;
        bezeichnung = wegpunkt.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        bezeichnung.text = bezeichner;
        distanz = wegpunkt.transform.Find("Distanz").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        wegpunkt.position = transform.position + offset;
        distanz.text = Vector3.Distance(player.position, transform.position).ToString("0") + " m";
    }
}
