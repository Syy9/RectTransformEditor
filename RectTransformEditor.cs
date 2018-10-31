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

        RectTransform[] _targets;
        protected override void OnEnable()
        {
            base.OnEnable();
            _targets = targets.Cast<RectTransform>().ToArray();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            using (new EditorGUILayout.HorizontalScope("box", GUILayout.ExpandWidth(true)))
            {
                EditorGUILayout.LabelField("Pos & Size", GUILayout.Width(70));
                if (GUILayout.Button("Round Point", GUILayout.Width(80)))
                {
                    Undo.RegisterCompleteObjectUndo(_targets, "Round Point");
                    foreach (var r in _targets)
                    {
                        r.RoundPoint();
                    }
                    AssetDatabase.SaveAssets();
                }

                if (GUILayout.Button("Round Point (with children)", GUILayout.Width(160)))
                {
                    foreach (var r in _targets)
                    {
                        var components = r.GetComponentsInChildren<RectTransform>();
                        Undo.RegisterCompleteObjectUndo(components, "Round Point");
                        foreach (var c in components)
                        {
                            c.RoundPoint();
                        }
                    }
                    AssetDatabase.SaveAssets();
                }
            }
        }
    }


}
