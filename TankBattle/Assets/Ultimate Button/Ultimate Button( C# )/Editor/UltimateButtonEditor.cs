/* Written by Kaz Crowe */
/* UltimateButtonEditor.cs ver 1.0.3 */
using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;
// We are using our own Custom UImage to avoid overlapping references( Vuforia, ect.. )
using UImage = UnityEngine.UI.Image;

[ CustomEditor( typeof( UltimateButton ) ) ]
public class UltimateButtonEditor : Editor
{
	CanvasScaler canvasRect;
	
	
	/*
	For more information on the OnInspectorGUI and adding your own variables
	in the UltimateButton.cs script and displaying them in this script,
	see the EditorGUILayout section in the Unity Documentation to help out.
	*/
	public override void OnInspectorGUI ()
	{
		// Store the button that we are selecting
		UltimateButton button = ( UltimateButton )target;
		
		EditorGUILayout.Space();
		EditorGUILayout.Space();
		EditorGUILayout.BeginVertical( "Button" );
		GUILayout.Space( 5 );
		button.ultimateButtonReceiver = ( UltimateButtonReceiver )EditorGUILayout.ObjectField( "Button Reciever", button.ultimateButtonReceiver, typeof( UltimateButtonReceiver ), true );
		if( button.ultimateButtonReceiver == null )
			EditorGUILayout.HelpBox( "Ultimate Button Reciever needs to be assigned!", MessageType.Error );
		GUILayout.Space( 5 );
		EditorGUILayout.EndVertical();
		
		/* VARIABLES */
		EditorGUILayout.Space();
		EditorGUILayout.BeginVertical( "Toolbar" );
		GUILayout.BeginHorizontal();
		EditorGUILayout.LabelField( "Assigned Variables", EditorStyles.boldLabel );
		string v_option = "Show";
		if( EditorPrefs.GetBool( "UUI_Variables" ) == true )
			v_option = "Hide";
		if( GUILayout.Button( v_option, EditorStyles.miniButton, GUILayout.Width( 50 ), GUILayout.Height( 14f ) ) )
		{
			if( EditorPrefs.GetBool( "UUI_Variables" ) == true )
				EditorPrefs.SetBool( "UUI_Variables", false );
			else
				EditorPrefs.SetBool( "UUI_Variables", true );
		}
		GUILayout.EndHorizontal();
		EditorGUILayout.EndVertical();
		
		if( EditorPrefs.GetBool( "UUI_Variables" ) == true )
		{
			EditorGUILayout.Space();
			button.sizeFolder = ( RectTransform )EditorGUILayout.ObjectField( "Size Folder", button.sizeFolder, typeof( RectTransform ), true );
			
			// If we want to use Highlight on our button, we want to show the needed assignable variables
			if( button.showHighlight == true )
			{
				EditorGUILayout.Space();
				EditorGUILayout.LabelField( "Highlight Variables", EditorStyles.boldLabel );
				EditorGUI.indentLevel = 1;
				button.highlightBase = ( UImage )EditorGUILayout.ObjectField( "Base Highlight", button.highlightBase, typeof( UImage ), true );
				button.highlightButton = ( UImage )EditorGUILayout.ObjectField( "Button Highlight", button.highlightButton, typeof( UImage ), true );
				EditorGUI.indentLevel = 0;
			}
			// Same with our Tension
			if( button.showTension == true )
			{
				EditorGUILayout.Space();
				EditorGUILayout.LabelField( "Tension Variables", EditorStyles.boldLabel );
				EditorGUI.indentLevel = 1;
				button.tensionAccent = ( UImage )EditorGUILayout.ObjectField( "Tension", button.tensionAccent, typeof( UImage ), true );
				EditorGUI.indentLevel = 0;
			}
			// and our touch actions
			if( button.useAnimation == true || button.useFade == true )
			{
				EditorGUILayout.Space();
				EditorGUILayout.LabelField( "Touch Action Variables", EditorStyles.boldLabel );
				EditorGUI.indentLevel = 1;
				if( button.useAnimation == true )
					button.buttonAnimator = ( Animator )EditorGUILayout.ObjectField( "Animator", button.buttonAnimator, typeof( Animator ), true );
				if( button.useFade == true )
				{
					button.button = ( UImage )EditorGUILayout.ObjectField( "Button", button.button, typeof( UImage ), true );
					button.buttonBase = ( UImage )EditorGUILayout.ObjectField( "Button Base", button.buttonBase, typeof( UImage ), true );
				}
				EditorGUI.indentLevel = 0;
			}
		}
		EditorGUILayout.Space();
		
		/* SIZE AND PLACEMENT */
		EditorGUILayout.BeginVertical( "Toolbar" );
		GUILayout.BeginHorizontal();
		EditorGUILayout.LabelField( "Size and Placement", EditorStyles.boldLabel );
		string sap_option = "Show";
		if( EditorPrefs.GetBool( "UUI_SizeAndPlacement" ) == true )
			sap_option = "Hide";
		if( GUILayout.Button( sap_option, EditorStyles.miniButton, GUILayout.Width( 50 ), GUILayout.Height( 14f ) ) )//
		{
			if( EditorPrefs.GetBool( "UUI_SizeAndPlacement" ) == true )
				EditorPrefs.SetBool( "UUI_SizeAndPlacement", false );
			else
				EditorPrefs.SetBool( "UUI_SizeAndPlacement", true );
		}
		GUILayout.EndHorizontal();
		EditorGUILayout.EndVertical();
		
		if( EditorPrefs.GetBool( "UUI_SizeAndPlacement" ) == true )
		{
			// Arrange our button variables to be shown the way we want
			button.anchor = ( UltimateButton.Anchor )EditorGUILayout.EnumPopup( "Button Position", button.anchor );
			button.touchSize = ( UltimateButton.TouchSize )EditorGUILayout.EnumPopup( "Touch Area Size", button.touchSize );
			button.buttonSize = EditorGUILayout.Slider( "Button Size", button.buttonSize, 1.0f, 4.0f );
			EditorGUILayout.BeginVertical( "Box" );
			GUILayout.BeginHorizontal();
			EditorGUILayout.LabelField( "Button Positioning" );
			string cs_option = "+";
			if( EditorPrefs.GetBool( "UUI_CustomSpacing" ) == true )
				cs_option = "-";
			if( GUILayout.Button( cs_option, GUILayout.Width( 35 ), GUILayout.Height( 14f ) ) )
			{
				if( EditorPrefs.GetBool( "UUI_CustomSpacing" ) == true )
					EditorPrefs.SetBool( "UUI_CustomSpacing", false );
				else
					EditorPrefs.SetBool( "UUI_CustomSpacing", true );
			}
			GUILayout.EndHorizontal();
			if( EditorPrefs.GetBool( "UUI_CustomSpacing" ) == true )
			{
				EditorGUI.indentLevel = 1;
				EditorGUILayout.Space();
				button.cs_X = EditorGUILayout.Slider( "X Position:", button.cs_X, 0.0f, 50.0f );
				button.cs_Y = EditorGUILayout.Slider( "Y Position:", button.cs_Y, 0.0f, 100.0f );
				EditorGUILayout.Space();
				EditorGUI.indentLevel = 0;
			}
			EditorGUILayout.EndVertical();
		}
		EditorGUILayout.Space();
		
		/* STYLE AND OPTIONS */
		EditorGUILayout.BeginVertical( "Toolbar" );
		GUILayout.BeginHorizontal();
		EditorGUILayout.LabelField( "Style and Options", EditorStyles.boldLabel );
		string sao_option = "Show";
		if( EditorPrefs.GetBool( "UUI_StyleAndOptions" ) == true )
			sao_option = "Hide";
		if( GUILayout.Button( sao_option, EditorStyles.miniButton, GUILayout.Width( 50 ), GUILayout.Height( 14f ) ) )//
		{
			if( EditorPrefs.GetBool( "UUI_StyleAndOptions" ) == true )
				EditorPrefs.SetBool( "UUI_StyleAndOptions", false );
			else
				EditorPrefs.SetBool( "UUI_StyleAndOptions", true );
		}
		GUILayout.EndHorizontal();
		EditorGUILayout.EndVertical();
		
		if( EditorPrefs.GetBool( "UUI_StyleAndOptions" ) == true )
		{
			// Show Highlight
			button.showHighlight = EditorGUILayout.ToggleLeft( "Show Highlight", button.showHighlight );
			if( button.showHighlight == true )
			{
				// Highlight Options
				EditorGUI.BeginChangeCheck();
				button.highlightColor = EditorGUILayout.ColorField( "Highlight Color", button.highlightColor );
				if( EditorGUI.EndChangeCheck() )
					button.SetHighlight();
				
				// Enable images if they are off
				if( button.highlightBase != null && button.highlightBase.gameObject.activeInHierarchy == false )
					button.highlightBase.gameObject.SetActive( true );
				if( button.highlightButton != null && button.highlightButton.gameObject.activeInHierarchy == false )
					button.highlightButton.gameObject.SetActive( true );
				
				// If any of the variables are unassigned, we want to tell them
				if( button.highlightBase == null )
					EditorGUILayout.HelpBox( "Base Highlight is not assigned in 'Variables'. Base Highlight will not be displayed.", MessageType.Warning );
				if( button.highlightButton == null )
					EditorGUILayout.HelpBox( "Button Highlight is not assigned in 'Variables'. Button Highlight will not be displayed", MessageType.Warning );
				
				EditorGUILayout.Space();
			}
			else
			{
				// Here we want to check if we have any highlights, and if so, SetActive( false )
				if( button.highlightBase != null && button.highlightBase.gameObject.activeInHierarchy == true )
					button.highlightBase.gameObject.SetActive( false );
				if( button.highlightButton != null && button.highlightButton.gameObject.activeInHierarchy == true )
					button.highlightButton.gameObject.SetActive( false );
			}
			
			// Show Tension
			button.showTension = EditorGUILayout.ToggleLeft( "Show Tension", button.showTension );
			if( button.showTension == true )
			{
				// Tension Options
				button.tensionOption = ( UltimateButton.TensionOption )EditorGUILayout.EnumPopup( "Display Tension", button.tensionOption );
				EditorGUI.BeginChangeCheck();
				button.tensionColorNone = EditorGUILayout.ColorField( "Tension None", button.tensionColorNone );
				if( EditorGUI.EndChangeCheck() )
					button.SetTensionAccent();
				
				button.tensionColorFull = EditorGUILayout.ColorField( "Tension Full", button.tensionColorFull );
				
				// Here we are checking which options we have enabled so that we can provide only the options needed
				if( button.tensionOption == UltimateButton.TensionOption.FadeInAndOut || button.tensionOption == UltimateButton.TensionOption.FadeInSnapOut )
				{
					button.fadeInDuration = EditorGUILayout.Slider( "Fade In", button.fadeInDuration, 0.05f, 1.0f );
				}
				if( button.tensionOption == UltimateButton.TensionOption.FadeInAndOut || button.tensionOption == UltimateButton.TensionOption.SnapInFadeOut || button.tensionOption == UltimateButton.TensionOption.FadeOutOnTouch )
				{
					button.fadeOutDuration = EditorGUILayout.Slider( "Fade Out", button.fadeOutDuration, 0.05f, 1.0f );
				}
				
				// Check our images and make sure they are active
				if( button.tensionAccent != null && button.tensionAccent.gameObject.activeInHierarchy == false )
					button.tensionAccent.gameObject.SetActive( true );
			}
			else
			{
				// Here we want to check if we have any tension accents, and if so, SetActive( false )
				if( button.tensionAccent != null && button.tensionAccent.gameObject.activeInHierarchy == true )
					button.tensionAccent.gameObject.SetActive( false );
			}
		}
		EditorGUILayout.Space();
		
		/* Touch Actions */
		EditorGUILayout.BeginVertical( "Toolbar" );
		GUILayout.BeginHorizontal();
		EditorGUILayout.LabelField( "Touch Actions", EditorStyles.boldLabel );
		string ta_option = "Show";
		if( EditorPrefs.GetBool( "UUI_TouchActions" ) == true )
			ta_option = "Hide";
		if( GUILayout.Button( ta_option, EditorStyles.miniButton, GUILayout.Width( 50 ), GUILayout.Height( 14f ) ) )//
		{
			if( EditorPrefs.GetBool( "UUI_TouchActions" ) == true )
				EditorPrefs.SetBool( "UUI_TouchActions", false );
			else
				EditorPrefs.SetBool( "UUI_TouchActions", true );
		}
		GUILayout.EndHorizontal();
		EditorGUILayout.EndVertical();
		
		if( EditorPrefs.GetBool( "UUI_TouchActions" ) == true )
		{
			// This is for implementing our touch actions with animations
			button.useAnimation = EditorGUILayout.ToggleLeft( "Use Animation", button.useAnimation );
			if( button.useAnimation == true )
			{
				if( button.buttonAnimator == null )
				{
					EditorGUILayout.HelpBox( "Button Animator needs to be assigned.", MessageType.Error );
					EditorPrefs.SetBool( "UUI_Variables", true );
				}
				
				if( button.buttonAnimator != null )
					if( button.buttonAnimator.enabled == false )
						button.buttonAnimator.enabled = true;
			}
			else
			{
				if( button.buttonAnimator != null )
					if( button.buttonAnimator.enabled == true )
						button.buttonAnimator.enabled = false;
			}
			
			// This is for implementing color fading with touch
			EditorGUI.BeginChangeCheck();
			button.useFade = EditorGUILayout.ToggleLeft( "Use Fade", button.useFade );
			if( button.useFade == true )
			{
				button.fadeUntouched = EditorGUILayout.Slider( "Fade Untouched", button.fadeUntouched, 0.0f, 1.0f );
				button.fadeTouched = EditorGUILayout.Slider( "Fade Touched", button.fadeTouched, 0.0f, 1.0f );
				if( button.showTension == true )
					EditorGUILayout.HelpBox( "The alpha of Tension Color will not fade. If you want to change the alpha of the Tension Color, modify it with the Tension Color property directly.", MessageType.Warning );
			}
			if( EditorGUI.EndChangeCheck() )
			{
				// If we are using our fade we should set it up in here
				if( button.useFade == true )
					button.HandleFade( "Untouched" );
				else
					button.HandleFade( "Reset" );
			}
		}
		EditorGUILayout.Space();
		
		/* Resets */
		EditorGUILayout.BeginVertical( "Toolbar" );
		GUILayout.BeginHorizontal();
		EditorGUILayout.LabelField( "Restore To Delfault", EditorStyles.boldLabel );
		string rtd_option = "Show";
		if( EditorPrefs.GetBool( "UUI_RestoreToDefault" ) == true )
			rtd_option = "Hide";
		if( GUILayout.Button( rtd_option, EditorStyles.miniButton, GUILayout.Width( 50 ), GUILayout.Height( 14f ) ) )//
		{
			if( EditorPrefs.GetBool( "UUI_RestoreToDefault" ) == true )
				EditorPrefs.SetBool( "UUI_RestoreToDefault", false );
			else
				EditorPrefs.SetBool( "UUI_RestoreToDefault", true );
		}
		GUILayout.EndHorizontal();
		EditorGUILayout.EndVertical();
		
		if( EditorPrefs.GetBool( "UUI_RestoreToDefault" ) == true )
		{
			// In this section, we just are setting up hard coded values to be able to reset our options to
			EditorGUILayout.Space();
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			if( GUILayout.Button( "Size and Placement", EditorStyles.miniButton, GUILayout.Width( 150 ), GUILayout.Height( 20 ) ) )
				ResetSizeAndPlacement( button );
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			EditorGUILayout.Space();
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			if( GUILayout.Button( "Style and Options", EditorStyles.miniButton, GUILayout.Width( 150 ), GUILayout.Height( 20 ) ) )
				ResetStyleAndOptions( button );
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			EditorGUILayout.Space();
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			if( GUILayout.Button( "Touch Actions", EditorStyles.miniButton, GUILayout.Width( 150 ), GUILayout.Height( 20 ) ) )
				ResetTouchActions( button );
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
		}
		EditorGUILayout.Space();
		
		/* Scripting Help */
		EditorGUILayout.BeginVertical( "Toolbar" );
		GUILayout.BeginHorizontal();
		EditorGUILayout.LabelField( "Scripting Help", EditorStyles.boldLabel );
		string sh_option = "Show";
		if( EditorPrefs.GetBool( "UUI_ScriptingHelp" ) == true )
			sh_option = "Hide";
		if( GUILayout.Button( sh_option, EditorStyles.miniButton, GUILayout.Width( 50 ), GUILayout.Height( 14f ) ) )//
		{
			if( EditorPrefs.GetBool( "UUI_ScriptingHelp" ) == true )
				EditorPrefs.SetBool( "UUI_ScriptingHelp", false );
			else
				EditorPrefs.SetBool( "UUI_ScriptingHelp", true );
		}
		GUILayout.EndHorizontal();
		EditorGUILayout.EndVertical();
		
		if( EditorPrefs.GetBool( "UUI_ScriptingHelp" ) == true )
		{
			// Begin Horizontal
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			if( GUILayout.Button( "Open Script Help", EditorStyles.miniButton, GUILayout.Width( 100 ), GUILayout.Height( 20 ) ) )
			{
				UltimateButtonWindow window = ( UltimateButtonWindow )EditorWindow.GetWindow( typeof ( UltimateButtonWindow ) );
				window.Show();
			}
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
		}
		EditorGUILayout.Space();
		
		// This is for showing helpful tips to help them avoid errors
		if( button.button == null )
			EditorGUILayout.HelpBox( "Button needs to be assigned in 'Assigned Variables'!", MessageType.Error );
		if( button.sizeFolder == null )
			EditorGUILayout.HelpBox( "Size Folder needs to be assigned in 'Assigned Variables'!", MessageType.Error );
		
		// This will apply these variables to the selected script
		if( GUI.changed )
			EditorUtility.SetDirty( target );
		
		if( canvasRect == null )
		{
			if( button.transform.root.GetComponent<CanvasScaler>() )
				canvasRect = button.transform.root.GetComponent<CanvasScaler>();
			else
				canvasRect = GetParentCanvas( button );
		}
		if( canvasRect.uiScaleMode != CanvasScaler.ScaleMode.ConstantPixelSize )
		{
			EditorGUILayout.BeginVertical( "Button" );
			EditorGUILayout.HelpBox( "The Ultimate Button cannot be used correctly because the root canvas is using " + canvasRect.uiScaleMode.ToString() + ". Please place the Ultimate Button into a different Canvas with the ConstantPixelSize option.", MessageType.Error );
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			if( GUILayout.Button( "Adjust Canvas", GUILayout.Width( 100 ), GUILayout.Height( 20 ) ) )
			{
				Debug.Log( "CanvasScaler / ScaleMode option has been adjusted." );
				canvasRect.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
			}
			GUILayout.FlexibleSpace();
			if( GUILayout.Button( "Adjust Button", GUILayout.Width( 100 ), GUILayout.Height( 20 ) ) )// 75
			{
				bool canvasExists = false;
				Transform targetCanvas = button.transform;
				CanvasScaler[] allCanvas = GameObject.FindObjectsOfType<CanvasScaler>();
				foreach( CanvasScaler currCanvas in allCanvas )
				{
					if( canvasExists == false )
					{
						if( currCanvas.uiScaleMode == CanvasScaler.ScaleMode.ConstantPixelSize )
						{
							canvasExists = true;
							targetCanvas = currCanvas.transform;
						}
					}
				}
				// If we didn't find a Canvas with the right options, then we need to make one
				if( canvasExists == false )
				{
					// For full comments, please refer to CreateButtonEditor.cs
					Debug.Log( "Ultimate UI Canvas has been created." );
					GameObject root = new GameObject( "Ultimate UI Canvas" );
					root.layer = LayerMask.NameToLayer( "UI" );
					Canvas canvas = root.AddComponent<Canvas>();
					canvas.renderMode = RenderMode.ScreenSpaceOverlay;
					root.AddComponent<CanvasScaler>();
					root.AddComponent<GraphicRaycaster>();
					Undo.RegisterCreatedObjectUndo( root, "Create " + root.name );
					targetCanvas = root.transform;
				}
				
				// Here we set the button to be a child of the canvas
				button.transform.SetParent( targetCanvas.transform, false );
				
				// Focus on the moved Ultimate Button gameObject
				Selection.activeGameObject = button.gameObject;
				
				// Tell the user that we relocated, yo!
				Debug.Log( "Ultimate Button has been relocated to Ultimate UI Canvas." );
				
				canvasRect = null;
			}
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			EditorGUILayout.EndVertical();
		}
	}
	
	void ResetSizeAndPlacement ( UltimateButton button )
	{
		button.touchSize = UltimateButton.TouchSize.Default;
		button.buttonSize = 2.5f;
		button.cs_X = 5.0f;
		button.cs_Y = 20.0f;
	}
	
	void ResetStyleAndOptions ( UltimateButton button )
	{
		button.showHighlight = true;
		button.highlightColor = new Color( 0.0f, 0.047f, 0.996f, 1.0f );
		button.highlightButton.gameObject.SetActive( true );
		button.highlightBase.gameObject.SetActive( true );
		button.SetHighlight();
		button.showTension = true;
		button.tensionColorNone = new Color( 0.0f, 0.047f, 0.996f, 0.0f );
		button.tensionColorFull = new Color( 0.0f, 0.047f, 0.996f, 1.0f );
		button.tensionAccent.gameObject.SetActive( true );
		button.SetTensionAccent();
	}
	
	void ResetTouchActions ( UltimateButton button )
	{
		button.useAnimation = false;
		button.useFade = false;
		button.fadeUntouched = 1.0f;
		button.fadeTouched = 0.5f;
		button.HandleFade( "Reset" );
	}
	
	CanvasScaler GetParentCanvas ( UltimateButton button )
	{
		Transform parent = button.transform.parent;
		while( parent != null )
		{ 
			if( parent.transform.GetComponent<CanvasScaler>() )
				return parent.transform.GetComponent<CanvasScaler>();
			
			parent = parent.transform.parent;
		}
		return null;
	}
}