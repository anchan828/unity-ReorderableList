using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Sample))]
public class SampleInspector : Editor
{
    private Dictionary<string, ReorderableList> lists = new Dictionary<string, ReorderableList>();

    public override void OnInspectorGUI()
    {
        //��{�I�Ȏg����
        Draws("texts1", "textures", "hoges", "fugas");

        //�h���b�O�ł��Ȃ�
        Draw(false, true, true, true, "texts2");
        //�w�b�_�[�Ȃ� �������Ȃ����ۂ�
        //Draw(true, false, true, true, "texts3");
        // Add�{�^���Ȃ�
        Draw(true, true, false, true, "texts4");
        // Remove�{�^���Ȃ�
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