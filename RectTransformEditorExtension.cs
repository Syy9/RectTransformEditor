using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Syy.Utility
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
            v.x = Mathf.Round(v.x);
            v.y = Mathf.Round(v.y);
            return v;
        }
    }
}
