/*
 * Project Name: Unity 2D Platformer. Player Controls a character to jump through platforms
 *   to collect coins and destroy enemies
 * File Name: GameText.cs
 * Author's Name: Zhaoning Cai
 * Last Modified by: Zhaoning Cai
 * Date Last Modified: Oct 26th, 2015
 * Revision History: 6th version (Final version)
 */
using UnityEngine;
using System.Collections;

// This class is responsible for displaying text on the play screen
public class GameText : MonoBehaviour {

    public GUISkin skin;
	
    public void OnGUI()
    {
        GUI.skin = skin;

        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));

        GUILayout.BeginVertical(skin.GetStyle("GameText"));
        
        // Displays the score
        GUILayout.Label(string.Format("Points: {0}", GameController.Instance.points), skin.GetStyle("PointsText"));

        // Displays the life and game over information
        GUILayout.Label(GameController.Instance.life, skin.GetStyle("LifeText"));

        GUILayout.EndVertical();

        GUILayout.EndArea();
    }
}
