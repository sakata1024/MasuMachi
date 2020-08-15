using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamingColor : MonoBehaviour
{
    [SerializeField]
    private Image image = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h, s, v;
        Color.RGBToHSV(image.color, out h, out s, out v);

        h += Time.deltaTime * 2f;
        if (h >= 1) h = 0;

        image.color = Color.HSVToRGB(h, s, v);

        transform.Rotate(Vector3.back, 40f * Time.deltaTime);
    }
}
