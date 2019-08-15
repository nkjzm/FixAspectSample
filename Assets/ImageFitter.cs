using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ImageFitter : MonoBehaviour
{
    void Start()
    {
        GetComponent<RawImage>().FixAspect();
    }
}