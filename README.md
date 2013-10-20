unity-ReorderableList
=====================

![](http://gyazo.com/9e65eda84242ee5d6e3ecf7d77d163d4.png)


```
using UnityEngine;

public class Sample : MonoBehaviour
{
    public string[] texts = new string[2];
}
```

```
using UnityEngine;
using UnityEditor;
 
[CustomEditor(typeof(Sample))]
public class SampleInspector : Editor
{
    private ReorderableList list = null;
    public override void OnInspectorGUI()
    {
        if (list == null)
        {
            list = new ReorderableList(serializedObject, serializedObject.FindProperty("texts"));
        }
        else
        {
            list.DoList();
        }
    }
}
```

## API

### Constructor

Name|Description
:---|:---
ReorderableList|

```
public ReorderableList(SerializedObject serializedObject, SerializedProperty serializedProperty, bool draggable = true, bool displayHeader = true, bool displayAddButton = true, bool displayRemoveButton = true)
```

Type|Name|Description
:---|:---|:---
SerializedObject|serializedObject|
SerializedProperty|serializedProperty|
bool|draggable| Can elements drag?
bool|displayHeader| Draw header , if true. The default is true.
bool|displayAddButton| Draw AddButton , if true. The default is true.
bool|displayRemoveButton| Draw RemoveButton , if true. The default is true.


### Variables

Type|Name|Description
:---|:---|:---
SerializedObject|serializedObject|
SerializedProperty|serializedProperty|
float|elementHeight| The default is 21.
DrawElementCallback|drawElementCallback|
DrawHeaderCallback|drawHeaderCallback|
AddCallbackDelegate|onAddDelegateCallback|
RemoveCallbackDelegate|onRemoveDelegateCallback|
SelectCallbackDelegate|onSelectCallback|

### Functions

Name|Description
:---|:---
DoList| Draw ReorderableList

### Delegates

Name|Description
:---|:---
DrawElementCallback|
DrawHeaderCallback|
SelectCallbackDelegate|
AddCallbackDelegate|
RemoveCallbackDelegate|


```
public delegate void DrawElementCallback(Rect rect, int index, bool selected, bool focused);

public delegate void DrawHeaderCallback(Rect rect);

public delegate void SelectCallbackDelegate(int index);

public delegate void AddCallbackDelegate();

public delegate void RemoveCallbackDelegate();
```
