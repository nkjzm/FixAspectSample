using UnityEngine;
using UnityEngine.UI;

public static class FixAspectExtensions
{
    public static void FixAspect(this RawImage image)
    {
        image.FixAspect(image.rectTransform.rect.size);
    }
    public static void FixAspect(this RawImage image, Vector3 originalSize)
    {
        var textureSize = new Vector2(image.texture.width, image.texture.height);

        var heightScale = originalSize.y / textureSize.y;
        var widthScale = originalSize.x / textureSize.x;
        var rectSize = textureSize * Mathf.Min(heightScale, widthScale);

        var anchorDiff = image.rectTransform.anchorMax - image.rectTransform.anchorMin;
        var parentSize = (image.transform.parent as RectTransform).rect.size;
        var anchorSize = parentSize * anchorDiff;

        image.rectTransform.sizeDelta = rectSize - anchorSize;
    }
}
