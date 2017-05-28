/* Written by Kaz Crowe */
/* UltimateButtonWindow.cs ver 1.0 */
using UnityEngine;
using UnityEditor;
using System.IO;

public class UltimateButtonWindow : EditorWindow
{
	string scriptName;
	int codingLanguageInt = 0;
	string[] codingLanguageString = new string[] { "C#", "Javascript" };

	// Add menu named "My Window" to the Window menu
	[ MenuItem( "Window/Ultimate Button" ) ]
	static void Init ()
	{
		// Get existing open window or if none, make a new one:
		UltimateButtonWindow window = ( UltimateButtonWindow )EditorWindow.GetWindow( typeof ( UltimateButtonWindow ) );
		window.Show();
	}

	void OnGUI ()
	{
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		EditorGUILayout.LabelField( "Instructions", EditorStyles.largeLabel, GUILayout.Width( 80 ), GUILayout.Height( 20 ) );
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();

		EditorGUILayout.LabelField( "In order to reference the Ultimate Button's Down and Up functions, you will need to make your custom script inherit from our UltimateButtonReceiver class. If you have a script made already, and just want to modify it to receive input from the Ultimate Button, then just make it inherit from our UltimateButtonReceiver class, and call the Override functions.", EditorStyles.wordWrappedLabel );
		EditorGUILayout.Space();

		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		codingLanguageInt = GUILayout.Toolbar( codingLanguageInt, codingLanguageString );
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();

		EditorGUILayout.Space();
		if( codingLanguageInt == 0 )
		{
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			EditorGUILayout.LabelField( "C# Coding Reference", EditorStyles.boldLabel, GUILayout.Width( 139 ), GUILayout.Height( 25 ) );
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			EditorGUILayout.LabelField( "Class Inheritance", EditorStyles.boldLabel );
			EditorGUILayout.TextArea( "public class #YOURSCRIPTNAME# : UltimateButtonReceiver" );
			EditorGUILayout.Space();
			EditorGUILayout.LabelField( "Button Down", EditorStyles.boldLabel, GUILayout.Width( 140 ), GUILayout.Height( 20 ) );
			EditorGUILayout.TextArea( "// This is called when the button has been pressed\n" +
			                         "public override void UltimateButtonDown ()\n" +
			                         "{\n" +
			                         "\t// Call your custom scripts here\n" +
			                         "}" );
			EditorGUILayout.Space();
			EditorGUILayout.LabelField( "Button Up", EditorStyles.boldLabel, GUILayout.Width( 140 ), GUILayout.Height( 20 ) );
			EditorGUILayout.TextArea( "// This is called when the button has been released\n" +
			                         "public override void UltimateButtonUp ()\n" +
			                         "{\n" +
			                         "\t// Call your custom scripts here\n" +
			                         "}" );
		}
		else
		{
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			EditorGUILayout.LabelField( "JavaScript Coding Reference", EditorStyles.boldLabel, GUILayout.Width( 189 ), GUILayout.Height( 25 ) );
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			EditorGUILayout.LabelField( "Class Inheritance", EditorStyles.boldLabel );
			EditorGUILayout.TextArea( "public class #YOURSCRIPTNAME# extends UltimateButtonReceiverJAVA" );
			EditorGUILayout.Space();
			EditorGUILayout.LabelField( "Button Down", EditorStyles.boldLabel, GUILayout.Width( 140 ), GUILayout.Height( 20 ) );
			EditorGUILayout.TextArea( "// This is called when the button has been pressed\n" +
			                         "public function UltimateButtonDown ()\n" +
			                         "{\n" +
			                         "\t// Call your custom scripts here\n" +
			                         "}" );
			EditorGUILayout.Space();
			EditorGUILayout.LabelField( "Button Up", EditorStyles.boldLabel, GUILayout.Width( 140 ), GUILayout.Height( 20 ) );
			EditorGUILayout.TextArea( "// This is called when the button has been released\n" +
			                         "public function UltimateButtonUp ()\n" +
			                         "{\n" +
			                         "\t// Call your custom scripts here\n" +
			                         "}" );
		}

		EditorGUILayout.Space();
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		EditorGUILayout.LabelField( "Alternatively", EditorStyles.largeLabel, GUILayout.Width( 90 ), GUILayout.Height( 20 ) );
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		EditorGUILayout.LabelField( "You can also use this tool to generate a custom reciever script. Please make sure to select your programming language above, name your script, and then hit 'Generate'.", EditorStyles.wordWrappedLabel );
		EditorGUILayout.Space();
		// Begin Horizontal
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.Label( "Script Name:" );
		scriptName = EditorGUILayout.TextField( scriptName );
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		// Begin our button horizontal
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		if( GUILayout.Button( "Generate", GUILayout.Width( 70 ), GUILayout.Height( 20 ) ) )
		{
			if( !string.IsNullOrEmpty( scriptName ) )
			{
				if( codingLanguageInt == 0 )
					GenerateNewButtonReceiverCSharp();
				else
					GenerateNewButtonReceiverJAVA();
			}
		}
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
	}

	void GenerateNewButtonReceiverCSharp ()
	{
		TextAsset templateTextFile = Resources.Load( "UltimateButtonReceiverTemplate", typeof( TextAsset ) ) as TextAsset;
		
		// If we have our TextAsset
		if( templateTextFile != null )
		{
			// start replacing the place holder data
			string scriptContents = "";
			scriptContents = templateTextFile.text;
			scriptContents = scriptContents.Replace("SCRIPTNAME", scriptName.Replace(" ", ""));
			
			// Let's create a new Script named "scriptName.cs"
			using( StreamWriter sw = new StreamWriter( string.Format( Application.dataPath + "/{0}.cs", new object[]{ scriptName.Replace(" ", "") } ) ) )
			{
				sw.Write( scriptContents );
			}
			
			// Refresh the Asset Database
			AssetDatabase.Refresh();
		}
		else
			Debug.LogError( "Can't find the UltimateButtonReceiverTemplate.txt file!" );
		
		TextAsset newlyCreatedScript = AssetDatabase.LoadAssetAtPath( "Assets/" + scriptName + ".cs", typeof( TextAsset ) ) as TextAsset;
		Selection.activeObject = newlyCreatedScript;
	}

	void GenerateNewButtonReceiverJAVA ()
	{
		TextAsset templateTextFile = Resources.Load( "UltimateButtonReceiverTemplateJAVA", typeof( TextAsset ) ) as TextAsset;
		
		// If we have our TextAsset
		if( templateTextFile != null )
		{
			// start replacing the place holder data
			string scriptContents = "";
			scriptContents = templateTextFile.text;
			scriptContents = scriptContents.Replace("SCRIPTNAME", scriptName.Replace(" ", ""));
			
			// Let's create a new Script named "scriptName.cs"
			using( StreamWriter sw = new StreamWriter( string.Format( Application.dataPath + "/{0}.js", new object[]{ scriptName.Replace(" ", "") } ) ) )
			{
				sw.Write( scriptContents );
			}
			
			// Refresh the Asset Database
			AssetDatabase.Refresh();
		}
		else
			Debug.LogError( "Can't find the UltimateButtonReceiverTemplate.txt file!" );
		
		TextAsset newlyCreatedScript = AssetDatabase.LoadAssetAtPath( "Assets/" + scriptName + ".js", typeof( TextAsset ) ) as TextAsset;
		Selection.activeObject = newlyCreatedScript;
	}
}