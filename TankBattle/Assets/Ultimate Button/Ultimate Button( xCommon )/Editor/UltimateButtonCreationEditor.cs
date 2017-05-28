/* Written by Kaz Crowe */
/* UltimateButtonCreationEditor.cs ver. 1.0 */
using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UltimateButtonCreationEditor
{
	// This creates our menu within the UI section
	[ MenuItem( "GameObject/UI/Ultimate Button" ) ]
	private static void CreateUltimateButton ()
	{
		// Find our buttonPrefab
		GameObject buttonPrefab = Resources.Load( "UltimateButton", typeof( GameObject ) ) as GameObject;
		
		// If we found the prefab, create a button with the prefab we just got
		if( buttonPrefab != null )
			CreateButton( buttonPrefab );
		// else we have no prefab, or it's in the wrong folder, we need to put an error in the console
		else
			Debug.LogError( "Could not find 'UltimateButton.prefab' in any Resources folders." );
	}
	
	private static void CreateButton ( Object buttonPrefab )
	{
		// create our prefab in our scene
		GameObject instBtn = ( GameObject )Object.Instantiate( buttonPrefab, Vector3.zero, Quaternion.identity );
		
		// Our instBtn.name currently has (Clone) at the end, so rename it to our original
		instBtn.name = buttonPrefab.name;
		
		// Focus on the new GameObject
		Selection.activeGameObject = instBtn;
		
		// Check if we need anything else created( Canvas, EventSystem )
		CheckNeededObjects( instBtn );
	}
	
	private static void CheckNeededObjects ( GameObject button )
	{
		// Find if we have a canvas in the scene
		Canvas currCanvas = ( Canvas )GameObject.FindObjectOfType( typeof( Canvas ) );
		
		// If we do, then set the button's parent to the canvas
		if( currCanvas != null )
			button.transform.SetParent( currCanvas.transform, false );
		// Else we need to create a new Canvas
		else
			CreateNewUI( button );
	}
	
	static public void CreateNewUI ( GameObject button )// This used to be a gameObject to return
	{
		// Root for the UI
		GameObject root = new GameObject( "Canvas" );
		root.layer = LayerMask.NameToLayer( "UI" );
		Canvas canvas = root.AddComponent<Canvas>();
		canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		root.AddComponent<CanvasScaler>();
		root.AddComponent<GraphicRaycaster>();
		Undo.RegisterCreatedObjectUndo( root, "Create " + root.name );
		
		// Here we set the button to be a child of the canvas
		button.transform.SetParent( root.transform, false );
		
		// if there is no event system add one...
		CreateEventSystem( root.gameObject );
	}
	
	private static void CreateEventSystem ( GameObject parent )
	{
		// Find an EventSystem if it is active
		Object esys = Object.FindObjectOfType<EventSystem>();
		if( esys == null )
		{
			GameObject eventSystem = new GameObject( "EventSystem" );
			GameObjectUtility.SetParentAndAlign( eventSystem, parent );
			esys = eventSystem.AddComponent<EventSystem>();
			eventSystem.AddComponent<StandaloneInputModule>();
			eventSystem.AddComponent<TouchInputModule>();
			
			Undo.RegisterCreatedObjectUndo( eventSystem, "Create " + eventSystem.name );
		}
	}
}