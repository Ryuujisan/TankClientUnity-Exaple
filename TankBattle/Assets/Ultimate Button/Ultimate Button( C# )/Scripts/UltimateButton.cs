/* Written by Kaz Crowe */
/* UltimateButton.cs ver. 1.0.3 */
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
// We are using our own Custom UJImage to avoid overlapping references( Vuforia, ect.. )
using UImage = UnityEngine.UI.Image;

/* 
 * First off, we are using [ExecuteInEditMode] to be able to show changes in real time.
 * This will not affect anything within a build or play mode. This simply makes the script
 * able to be run while in the Editor in Edit Mode.
*/
[ExecuteInEditMode]
public class UltimateButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public UltimateButtonReceiver ultimateButtonReceiver;
	/* Basic Variables */
	public RectTransform sizeFolder;
	public UImage button;
	public UImage buttonBase;
	// Highlight
	public UImage highlightBase;
	public UImage highlightButton;
	// Tension
	public UImage tensionAccent;
	/* Size and Placement */
	public enum Anchor
	{
		Left,
		Right,
	}
	public Anchor anchor;
	public enum TouchSize
	{
		Default,
		Medium,
		Large
	}
	public TouchSize touchSize;
	public float buttonSize = 1.75f;
	public float cs_X = 5.0f;
	public float cs_Y = 20.0f;
	/* Style and Options */
	public bool showHighlight = false;
	public Color highlightColor = new Color( 1, 1, 1, 1 );
	public bool showTension = false;
	public enum TensionOption
	{
		FadeInAndOut,
		FadeInSnapOut,
		SnapInFadeOut,
		SnapInAndOut,
		FadeOutOnTouch
	}
	public TensionOption tensionOption;
	public Color tensionColorNone = new Color( 1, 1, 1, 1 );
	public Color tensionColorFull = new Color( 1, 1, 1, 1 );
	public float fadeInDuration;
	public float fadeOutDuration;
	/* Touch Actions */
	public bool useAnimation;
	public Animator buttonAnimator;
	public bool useFade;
	public float fadeUntouched = 1.0f;
	public float fadeTouched = 0.5f;
	/* Controller Booleans */
	bool continueFadeIn;
	bool continueFadeOut;
	
	
	void Start ()
	{
		// Since Start() is only called in Play Mode, call UpdatePositioning with our current screen dimentions
		UpdatePositioning();
		
		// We need to check our options here, and call the appropriate functions to get them set up
		if( showHighlight == true )
			SetHighlight();
		if( showTension == true )
			SetTensionAccent();
	}
	
	// This means we have touched, so process where we have touched
	public void OnPointerDown ( PointerEventData touchInfo )
	{
		// If we want to show animations on Touch, do that here
		if( useAnimation == true )
			buttonAnimator.SetBool( "Touch", true );
		
		// If we are using our fade on touch do that here as well
		if( useFade == true )
			HandleFade( "Touched" );

		if( showTension == true )
		{
			// If we are showing tension, then we want to stop fading out and check our options
			if( continueFadeOut == true )
				continueFadeOut = false;
			if( tensionOption == TensionOption.FadeInSnapOut || tensionOption == TensionOption.FadeInAndOut )
				StartCoroutine( "TensionAccentFadeIn" );
			if( tensionOption == TensionOption.FadeOutOnTouch )
				StartCoroutine( "TensionAccentFadeOut" );
			if( tensionOption == TensionOption.SnapInFadeOut || tensionOption == TensionOption.SnapInAndOut )
				tensionAccent.color = tensionColorFull;
		}

		// This calls UltimateButtonDown on our receiver script
		if( ultimateButtonReceiver != null )
			ultimateButtonReceiver.UltimateButtonDown();
		else
			Debug.LogWarning( "The Ultimate Button Receiver has not been assigned! Please assign a Receiver." );
	}
	
	// This means we have let go
	public void OnPointerUp ( PointerEventData touchInfo )
	{
		// If we want to show animations on touch up, do that here
		if( useAnimation == true )
			buttonAnimator.SetBool( "Touch", false );
		
		// If we are using our fade on touch up
		if( useFade == true )
			HandleFade( "Untouched" );

		// If we are showing Tension, then we need to either fade out or reset the color
		if( showTension == true )
		{
			// If we are showing tension, then we want to stop fading in and check our options
			if( continueFadeIn == true )
				continueFadeIn = false;
			if( tensionOption == TensionOption.SnapInFadeOut || tensionOption == TensionOption.FadeInAndOut )
				StartCoroutine( "TensionAccentFadeOut" );
			if( tensionOption == TensionOption.SnapInAndOut || tensionOption == TensionOption.FadeInSnapOut )
				tensionAccent.color = tensionColorNone;
		}

		// This will call UltimateButtonUp on our receiver script
		if( ultimateButtonReceiver != null )
			ultimateButtonReceiver.UltimateButtonUp();
		else
			Debug.LogWarning( "The Ultimate Button Receiver has not been assigned! Please assign a Receiver." );
	}

	// This function updates our options. It is public so we can call it from other scripts to update our positioning
	public void UpdatePositioning ()
	{
		// We want our button size to be larger when we have a larger number, so we need to calculate that out
		float textureSize = Screen.height * ( buttonSize / 10 );
		
		// We need to store this object's RectTrans so that we can position it
		RectTransform baseTrans = GetComponent<RectTransform>();
		
		// We need to get a position for our button based on our position variable
		Vector2 buttonTexturePosition = ConfigureTexturePosition( textureSize );

		// Our touch size needs to be fixed to a float value
		float fixedTouchSize;
		if( touchSize == TouchSize.Large )
			fixedTouchSize = 2.0f;
		else if( touchSize == TouchSize.Medium )
			fixedTouchSize = 1.5f;
		else
			fixedTouchSize = 1.0f;
		
		// Make a temporary Vector2
		Vector2 tempVector = new Vector2( textureSize, textureSize );
		
		// Our touch area is standard, so set it up with our tempVector multiplied by our fixedTouchSize
		baseTrans.sizeDelta = tempVector * fixedTouchSize;
		
		// We get our texture position and modify it with our sizeDelta - tempVector ( gives us the difference ) and divide by 2
		baseTrans.position = buttonTexturePosition - ( ( baseTrans.sizeDelta - tempVector ) / 2 );

		// Our sizeFolder needs to be textureSize and texture position
		sizeFolder.sizeDelta = new Vector2( textureSize, textureSize );
		sizeFolder.position = buttonTexturePosition;
	}
	
	// This function will configure a Vector2 for the position of our Button
	Vector2 ConfigureTexturePosition ( float textureSize )
	{
		// We need a few temporary Vector2's to work with
		Vector2 tempPosVector;
		
		// we need to fix our custom spacing variables to be usable
		float fixedCSX = cs_X / 100;
		float fixedCSY = cs_Y / 100;
		
		// We also need two floats for applying our spacers according to our screen size
		float positionSpacerX = Screen.width * fixedCSX - ( textureSize * fixedCSX );
		float positionSpacerY = Screen.height * fixedCSY - ( textureSize * fixedCSY );
		
		// If it's left, we can simply apply our positionxSpacerX
		if( anchor == Anchor.Left )
			tempPosVector.x = positionSpacerX;
		// else it's right, we need to calculate out from our right side and apply our positionSpaceX
		else
			tempPosVector.x = ( Screen.width - textureSize ) - positionSpacerX;
		
		// Here we just apply our positionSpacerY
		tempPosVector.y = positionSpacerY;
		
		// Return our updated Vector2
		return tempPosVector;
	}
	
	// This function is called to set up our Highlight Images
	public void SetHighlight ()
	{
		// Here we need to check if each variable is assigned so we don't get a null reference log error when applying color
		if( highlightBase != null )
			highlightBase.color = highlightColor;
		if( highlightButton != null )
			highlightButton.color = highlightColor;
		
		// If we are using fade, then we want to modify our highlight's color
		if( useFade == true )
			HandleFade( "Untouched" );
	}
	
	/* These next functions are for our Tension Accents */
	public void SetTensionAccent ()
	{
		// We need to check if ANY of our tension accents are unassiggned
		if( tensionAccent == null )
		{
			// Disable showTension to avoid errors, and let the user know with a Debug
			Debug.LogError( "The Tension Image is not assign. Disabling Show Tension to avoid errors. Please assign the Tension Image before modifying color values." );
			showTension = false;
		}
		else
			tensionAccent.color = tensionColorNone;
	}
	
	// This function is called when our button is touched
	IEnumerator TensionAccentFadeIn ()
	{
		// We need our current color so that any transition looks smooth
		Color currentColor = tensionAccent.color;

		// Modify a float to give us a multipier for our fade duration
		float fadeSpeed = 1.0f / fadeInDuration;

		// We are starting our fadeIn
		continueFadeIn = true;

		for( float t = 0.0f; t < 1.0f && continueFadeIn == true; t += Time.deltaTime * fadeSpeed )
		{
			// We want to smoothly transition from our current color to our full tension color
			tensionAccent.color = Color.Lerp( currentColor, tensionColorFull, t );
			yield return null;
		}

		if( continueFadeIn == true )
		{
			// Update continueFadeIn so we can fade in again
			continueFadeIn = false;

			// When we are done fading in, we will finish by making our color tensionColorFull
			tensionAccent.color = tensionColorFull;
		}
	}

	// This function is called when our button is released
	IEnumerator TensionAccentFadeOut ()
	{
		// We need our current color, unless we are using FadeOutOnTouch
		Color currentColor;
		if( tensionOption != TensionOption.FadeOutOnTouch )
			currentColor = tensionAccent.color;
		else
			currentColor = tensionColorFull;

		// Again, modify a float to give us a multipier for our fade duration
		float fadeSpeed = 1.0f / fadeOutDuration;

		// We are starting to fadeOut
		continueFadeOut = true;

		for( float t = 0.0f; t < 1.0f && continueFadeOut == true; t += Time.deltaTime * fadeSpeed )
		{
			// Lerp between our currentColor and tensionColorNone
			tensionAccent.color = Color.Lerp( currentColor, tensionColorNone, t );
			yield return null;
		}

		if( continueFadeOut == true )
		{
			// We are done fading out
			continueFadeOut = false;

			// Since we are done, if we weren't interupted, then apply our tensionColorNone
			tensionAccent.color = tensionColorNone;
		}
	}
	
	public void HandleFade ( string fadeAction )
	{
		// Temporary float to hold our modifier for our color.a
		float alphaMod;
		
		// Based on our fadeAction, we will modify our alphaMod for use
		if( fadeAction == "Touched" )
			alphaMod = fadeTouched;
		else if( fadeAction == "Untouched" )
			alphaMod = fadeUntouched;
		else
			alphaMod = 1.0f;
		
		// We need to check if both these are assigned
		if( buttonBase != null && button != null )
		{
			// And get a temporary color that is the same as our buttonBase, then change the alpha to our alphaMod
			Color buttonColor = buttonBase.color;
			buttonColor.a = alphaMod;
			
			// Now apply the temporary color to our buttonBase and button
			buttonBase.color = buttonColor;
			button.color = buttonColor;
		}
		
		// Check if we are using our highlights
		if( showHighlight == true )
		{
			// We want our fade to scale correctly with our current highlightColor.a
			float hlAlphaMod = highlightColor.a * alphaMod;
			
			// Check our highlightBase Image
			if( highlightBase != null )
			{
				// Temporary Color variable
				Color highlightBaseColor = highlightBase.color;
				
				// If we are using Fade, then we want to change to our alphaMod
				if( useFade == true )
					highlightBaseColor.a = hlAlphaMod;
				// However, if we are not, then we want our HL to be the same as our highlightColor option
				else
					highlightBaseColor.a = highlightColor.a;
				
				// Apply our new color to our highlightBase
				highlightBase.color = highlightBaseColor;
			}
			
			// Repeat the steps we just did for our highlightBase
			if( highlightButton != null )
			{
				Color highlightBtnColor = highlightButton.color;
				if( useFade == true )
					highlightBtnColor.a = hlAlphaMod;
				else
					highlightBtnColor.a = highlightColor.a;
				
				highlightButton.color = highlightBtnColor;
			}
		}
	}
	
	/* 
	 * This function allows us to apply changes in screen size and button options in real time
	 * However anything within this #if section will not be run in a game build, only within Unity
	*/
	#if UNITY_EDITOR
	void Update ()
	{
		// We want to constantly keep our button updated while the game is not being run in Unity
		if( Application.isPlaying == false )
			UpdatePositioning();
	}
	#endif
}