using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Sample))]
public class SampleInspector : Editor
{
    private Dictionary<string, ReorderableList> lists = new Dictionary<string, ReorderableList>();

    public override void OnInspectorGUI()
    {
        //基本的な使い方
        Draws("texts1", "textures", "hoges", "fugas");

        //ドラッグできない
        Draw(false, true, true, true, "texts2");
        //ヘッダーなし 今動かないっぽい
        //Draw(true, false, true, true, "texts3");
        // Addボタンなし
        Draw(true, true, false, true, "texts4");
        // Removeボタンなし
        Draw(true, true, true, false, "texts5");
    }

    private void Draw(bool draggable, bool displayHeader,
        bool displayAddButton, bool displayRemoveButton, string propertyName)
    {

        if (!lists.ContainsKey(propertyName))
        {
            var list = new ReorderableList(serializedObject, serializedObject.FindProperty(propertyName), draggable, displayHeader, displayAddButton, displayRemoveButton);
            lists.Add(propertyName, list);
        }
        else
        {
            lists[propertyName].DoList();
        }
    }

    void Draws(params string[] propertyNames)
    {
        foreach (var propertyName in propertyNames)
        {
            Draw(true, true, true, true, propertyName);
        }
    }
}