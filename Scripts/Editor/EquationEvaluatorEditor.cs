
using UnityEditor;
using UnityEngine;

namespace DoubTech.EquationEvaluator
{
    [CustomEditor(typeof(EquationEvaluator))]
    public class EquationEvaluatorEditor : Editor
    {
        class Content
        {
            #region GUIContent
            #endregion

            #region Styles
            #endregion

            static Content()
            {
            // Style initialization

            }
        }

        private double lastEvaluated;

        public override void OnInspectorGUI()
        {
            var evaluator = (EquationEvaluator) target;
            EditorGUILayout.PropertyField(serializedObject.FindProperty("equation"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("variableReferences"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("behaviourVariableReferences"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("functionReferences"));

            serializedObject.ApplyModifiedProperties();

            GUILayout.Space(16);

            if (GUILayout.Button("Evaluate"))
            {
                lastEvaluated = evaluator.Evaluate();
            }
            GUILayout.Label("Evaluated: " + lastEvaluated);
        }
    }
}
