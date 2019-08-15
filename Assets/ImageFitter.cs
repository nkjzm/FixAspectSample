using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ImageFitter : MonoBehaviour
{
    [SerializeField] RawImage rawImage = null;

    void Start()
    {
        FixAspect();
    }

    void Reset()
    {
        FixAspect();
    }

    [ContextMenu("FixAspect")]
    void FixAspect()
    {
        (rawImage ?? (rawImage = GetComponent<RawImage>())).FixAspect();
    }
}