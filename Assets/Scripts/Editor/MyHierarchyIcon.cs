using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using Game;

[InitializeOnLoad]
internal static class HierarchyIcons
{
    // add your components and the associated icons here
    private static readonly Dictionary<Type, GUIContent> typeIcons = new()
    {
        { typeof(BaseState), EditorGUIUtility.IconContent("_Popup@2x") },
        { typeof(GameManager), EditorGUIUtility.IconContent("animationdopesheetkeyframe") },
        { typeof(Player), EditorGUIUtility.IconContent("BuildSettings.Lumin@2x") },
        // { typeof(Locator), EditorGUIUtility.IconContent("d_Transform Icon") },
        // ...
    };

    // cached game object information
    private static Dictionary<int, GUIContent> labeledObjects = new();
    private static HashSet<int> unlabeledObjects = new();
    private static GameObject[] previousSelection = null; // used to update state on deselect

    // set up all callbacks needed
    static HierarchyIcons()
    {
        EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;

        // callbacks for when we want to update the object GUI state:
        ObjectFactory.componentWasAdded += c => UpdateObject(c.gameObject.GetInstanceID());
        // there's no componentWasRemoved callback, but we can use selection as a proxy:
        Selection.selectionChanged += OnSelectionChanged;
    }

    private static void OnHierarchyGUI(int id, Rect rect)
    {
        if (unlabeledObjects.Contains(id))
            return; // don't draw things with no component of interest

        if (ShouldDrawObject(id, out GUIContent icon))
        {
            // GUI code here
            rect.xMin = rect.xMax - 20; // right-align the icon
            GUI.Label(rect, icon);
        }
    }

    private static bool ShouldDrawObject(int id, out GUIContent icon)
    {
        if (labeledObjects.TryGetValue(id, out icon))
            return true;
        // object is unsorted, add it and get icon, if applicable
        return SortObject(id, out icon);
    }

    private static bool SortObject(int id, out GUIContent icon)
    {
        GameObject go = EditorUtility.InstanceIDToObject(id) as GameObject;
        if (go != null)
        {
            foreach ((Type type, GUIContent typeIcon) in typeIcons)
            {
                if (go.GetComponent(type))
                {
                    labeledObjects.Add(id, icon = typeIcon);
                    return true;
                }
            }
        }

        unlabeledObjects.Add(id);
        icon = default;
        return false;
    }

    private static void UpdateObject(int id)
    {
        unlabeledObjects.Remove(id);
        labeledObjects.Remove(id);
        SortObject(id, out _);
    }

    private const int
        MAX_SELECTION_UPDATE_COUNT = 3; // how many objects we want to allow to get updated on select/deselect

    private static void OnSelectionChanged()
    {
        TryUpdateObjects(previousSelection); // update on deselect
        TryUpdateObjects(previousSelection = Selection.gameObjects); // update on select
    }

    private static void TryUpdateObjects(GameObject[] objects)
    {
        if (objects != null && objects.Length > 0 && objects.Length <= MAX_SELECTION_UPDATE_COUNT)
        {
            // max of three to prevent performance hitches when selecting many objects
            foreach (GameObject go in objects)
            {
                UpdateObject(go.GetInstanceID());
            }
        }
    }
}