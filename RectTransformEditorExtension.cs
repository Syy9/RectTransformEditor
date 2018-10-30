using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RectTransformEditor
{

    public static class RectTransformEditorExtension
    {
        public static void RoundPoint(this RectTransform self)
        {
            self.anchoredPosition3D = RoundPoint(self.anchoredPosition3D);
            self.sizeDelta = RoundPoint(self.sizeDelta);
            self.offsetMax = RoundPoint(self.offsetMax);
            self.offsetMin = RoundPoint(self.offsetMin);

        }

        static Vector2 RoundPoint(Vector2 v)
        {
            var x = Mathf.Round(v.x);
            var y = Mathf.Round(v.y);
            return new Vector2(x, y);
        }
    }


}
