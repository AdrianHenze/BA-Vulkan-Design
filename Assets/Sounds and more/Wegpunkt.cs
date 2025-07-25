using TMPro;
using UnityEngine;

public class Wegpunkt : MonoBehaviour
{
    public RectTransform prefab;
    public string bezeichner;
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
        float dist = Vector3.Distance(player.position, transform.position);
        distanz.text = dist.ToString("0") + " m";
        float t = Mathf.InverseLerp(1, 500, dist);
        float scale = Mathf.Lerp(0.2f, 12, t);
        wegpunkt.localScale = Vector3.one * scale;

        if (dist < 20)
            wegpunkt.gameObject.SetActive(false);
    }
}
