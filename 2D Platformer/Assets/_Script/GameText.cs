using UnityEngine;
using System.Collections;

public class GameText : MonoBehaviour {

    public GUISkin skin;
	
    public void OnGUI()
    {
        GUI.skin = skin;

        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));

        GUILayout.BeginVertical(skin.GetStyle("GameText"));

        GUILayout.Label(string.Format("Points: {0}", GameController.Instance.points), skin.GetStyle("PointsText"));

        GUILayout.Label(string.Format("Life: {0}", GameController.Instance.life), skin.GetStyle("LifeText"));

        GUILayout.EndVertical();

        GUILayout.EndArea();
    }
}
