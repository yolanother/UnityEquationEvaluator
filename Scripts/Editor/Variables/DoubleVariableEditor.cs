using DoubTech.EquationEvaluator.Variables;
using UnityEditor;
using UnityEngine;

namespace DoubTech.Equationevaluator.Variables
{
    [CustomPropertyDrawer(typeof(DoubleVariable))]
    public class DoubleVariableEditor : PropertyDrawer
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

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var useConstant = property.FindPropertyRelative("useConstant");

            var toggleWidth = 24;

            var togglePos = new Rect(position);
            togglePos.x += position.width - toggleWidth + 8;
            useConstant.boolValue = EditorGUI.Toggle(togglePos, useConstant.boolValue);
            var valueRect = new Rect(position);
            valueRect.width -= toggleWidth - 4;
            if (useConstant.boolValue)
            {
                EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("constant"));
            }
            else
            {
                EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("variable"));
            }
        }
    }
}
