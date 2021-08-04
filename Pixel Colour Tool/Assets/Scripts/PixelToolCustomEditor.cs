using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PixelTool))]
public class PixelToolCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PixelTool pixelTool = (PixelTool)target;

        base.OnInspectorGUI();

        EditorGUILayout.Space(10);

        #region Texture Size
        EditorGUILayout.LabelField("Texture Size", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Width: " + pixelTool.GetTextureWidth().ToString());
        EditorGUILayout.LabelField("Height: " + pixelTool.GetTextureHeight().ToString());
        #endregion

        EditorGUILayout.Space(10);

        #region Pixel Buttons
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Previous Pixel", GUILayout.Width(130)))
        {
            pixelTool.PreviousPixel();
        }

        if (GUILayout.Button("Next Pixel", GUILayout.Width(130)))
        {
            pixelTool.NextPixel();
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        #endregion

        EditorGUILayout.Space(10);

        #region Direction Buttons
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Up", GUILayout.Width(80)))
        {
            pixelTool.NextRow();
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();


        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Left", GUILayout.Width(80)))
        {
            pixelTool.PreviousColumn();
        }

        if (GUILayout.Button("Right", GUILayout.Width(80)))
        {
            pixelTool.NextColumn();
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();


        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        if (GUILayout.Button("Down", GUILayout.Width(80)))
        {
            pixelTool.PreviousRow();
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        #endregion
    }
}
