using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Syy.Tool
{
    public static class RectTransformEditorExtension
    {
        public static void RoundPoint(this RectTransform self)
        {
            if (self.IsStretchX())
            {
                self.offsetMin = RoundPointX(self.offsetMin);
                self.offsetMax = RoundPointX(self.offsetMax);
            }
            else
            {
                self.anchoredPosition = RoundPointX(self.anchoredPosition);
                self.sizeDelta = RoundPointX(self.sizeDelta);
            }

            if (self.IsStretchY())
            {
                self.offsetMin = RoundPointY(self.offsetMin);
                self.offsetMax = RoundPointY(self.offsetMax);
            }
            else
            {
                self.anchoredPosition = RoundPointY(self.anchoredPosition);
                self.sizeDelta = RoundPointY(self.sizeDelta);
            }
        }

        public static bool IsStretchX(this RectTransform self)
        {
            if (self == null) return false;

            return Mathf.Abs(self.anchorMin.x - self.anchorMax.x) > 0.0001f;
        }

        public static bool IsStretchY(this RectTransform self)
        {
            if (self == null) return false;

            return Mathf.Abs(self.anchorMin.y - self.anchorMax.y) > 0.0001f;
        }

        static Vector2 RoundPoint(Vector2 v)
        {
            v.x = Mathf.Round(v.x);
            v.y = Mathf.Round(v.y);
            return v;
        }

        static Vector2 RoundPointX(Vector2 v)
        {
            v.x = Mathf.Round(v.x);
            return v;
        }

        static Vector2 RoundPointY(Vector2 v)
        {
            v.y = Mathf.Round(v.y);
            return v;
        }
    }
}
