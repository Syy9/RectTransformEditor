using System.Linq;
using System.Collections;
using System.Collections.Generic;
using CustomEditorUtil;
using UnityEngine;
using UnityEditor;

namespace RectTransformEditor
{
    [CustomEditor(typeof(RectTransform))]
    [CanEditMultipleObjects]
    public class RectTransformEditor : UnityProvideEditor
    {
        protected override UnityProvideEditorType EditorType { get { return UnityProvideEditorType.RectTransformEditor; } }

        RectTransform[] Targets;
        protected override void OnEnable()
        {
            base.OnEnable();
            Targets = targets.Cast<RectTransform>().ToArray();
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Round Point", GUILayout.Width(100)))
                {
                    Undo.RegisterCompleteObjectUndo(Targets, "Round Point");
                    foreach (var r in Targets)
                    {
                        r.RoundPoint();
                    }
                    AssetDatabase.SaveAssets();
                }

                if (GUILayout.Button("Round Point (with children)", GUILayout.Width(170)))
                {
                    foreach (var r in Targets)
                    {
                        var components = r.GetComponentsInChildren<RectTransform>();
                        Undo.RegisterCompleteObjectUndo(components, "Round Point");
                        foreach (var c in components)
                        {
                            Debug.Log("c : " + c.name);
                            c.RoundPoint();
                        }
                    }
                    AssetDatabase.SaveAssets();
                }
            }
        }
    }


}
