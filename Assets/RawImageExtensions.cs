using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// RawImageの大きさを変える拡張メソッド
/// </summary>
public static class FixAspectExtensions
{
    /// <summary>
    /// アスペクト比に合わせてRawImageのサイズを修正する
    /// 現在のUIサイズが基準となる
    /// </summary>
    public static void FixAspect(this RawImage image)
    {
        image.FixAspect(image.rectTransform.rect.size);
    }
    /// <summary>
    /// アスペクト比に合わせてRawImageのサイズを修正する
    /// </summary>
    /// <param name="originalSize">基準となるUIサイズ</param>
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
