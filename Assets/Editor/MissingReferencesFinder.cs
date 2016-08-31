using System.Collections;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

/// <summary>
/// A helper editor script for finding missing references to objects.
/// 
/// 2016-08-31 Adapted from: https://github.com/liortal53/MissingReferencesUnity/blob/master/Assets/MissingReferencesFinder/Editor/MissingReferencesFinder.cs
/// </summary>
public class MissingReferencesFinder : MonoBehaviour 
{
	const string MENU_ROOT = "Tools/Missing References/";

	/// <summary>
	/// Finds all missing references to objects in the currently loaded scene.
	/// </summary>
	[MenuItem(MENU_ROOT + "Search in scene", false, 50)]
	public static void FindMissingReferencesInCurrentScene()
	{
		var sceneObjects = GetSceneObjects();
		FindMissingReferences(SceneManager.GetActiveScene().name, sceneObjects);
	}

	/// <summary>
	/// Finds all missing references to objects in all enabled scenes in the project.
	/// This works by loading the scenes one by one and checking for missing object references.
	/// </summary>
	[MenuItem(MENU_ROOT + "Search in all scenes", false, 51)]
	public static void MissingSpritesInAllScenes()
	{
		foreach (var scene in EditorBuildSettings.scenes.Where(s => s.enabled))
		{
			EditorSceneManager.OpenScene(scene.path);
			FindMissingReferencesInCurrentScene();
		}
	}

	/// <summary>
	/// Finds all missing references to objects in assets (objects from the project window).
	/// </summary>
	[MenuItem(MENU_ROOT + "Search in assets", false, 52)]
	public static void MissingSpritesInAssets()
	{
		SearchForMissingReferencesInAllAssets();

	}

	public static void SearchForMissingReferencesInAllAssets(Action<string> reportError = null)
	{
		var allAssets = AssetDatabase.GetAllAssetPaths().Where(path => path.StartsWith("Assets/")).ToArray();
		var objs = allAssets.Select(a => AssetDatabase.LoadAssetAtPath(a, typeof(GameObject)) as GameObject).Where(a => a != null).ToArray();
		FindMissingReferences("Project", objs, reportError);
	}

	static void FindMissingReferences(string context, GameObject[] objects, Action<string> reportError = null)
	{
		reportError = reportError ?? Debug.LogError;

		foreach (var go in objects)
		{
			var components = go.GetComponents<Component>();

			foreach (var c in components)
			{
				// Missing components will be null, we can't find their type, etc.
				if (!c)
				{
					reportError("Missing Component in GO: " + GetFullPath(go));
					continue;
				}

				SerializedObject so = new SerializedObject(c);
				var sp = so.GetIterator();

				// Iterate over the components' properties.
				while (sp.NextVisible(true))
				{
					if (sp.propertyType == SerializedPropertyType.ObjectReference)
					{
						if (sp.objectReferenceValue == null
							&& sp.objectReferenceInstanceIDValue != 0)
						{
							ShowError(context, go, c.GetType().Name, ObjectNames.NicifyVariableName(sp.name), reportError);
						}
					}
				}
			}
		}
	}

	static GameObject[] GetSceneObjects()
	{
		// Use this method since GameObject.FindObjectsOfType will not return disabled objects.
		return Resources.FindObjectsOfTypeAll<GameObject>()
			.Where(go => string.IsNullOrEmpty(AssetDatabase.GetAssetPath(go))
				&& go.hideFlags == HideFlags.None).ToArray();
	}

	static void ShowError (string context, GameObject go, string componentName, string propertyName, Action<string> reportError)
	{
		const string ERROR_TEMPLATE = "Missing Ref in: [{3}]{0}. Component: {1}, Property: {2}";
		reportError(string.Format(ERROR_TEMPLATE, GetFullPath(go), componentName, propertyName, context));
	}

	static string GetFullPath(GameObject go)
	{
		return go.transform.parent == null ? go.name : GetFullPath(go.transform.parent.gameObject) + "/" + go.name;
	}
}