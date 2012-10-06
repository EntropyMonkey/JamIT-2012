using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI : MonoBehaviour
{
	GameObject[] players;
    public Font GUIFont;

    private List<Color> playerFontColors = new List<Color> { new Color(156 / 256F, 59 / 256F, 0), Color.green, Color.red, Color.blue };
	
	void Start()
	{
		players = GameObject.FindGameObjectsWithTag(PlayerSettings.Tag);
	}

	void OnGUI()
	{
		float x = 10;

        GUIStyle style = new GUIStyle();

        int i = 0;
		foreach (GameObject go in players)
		{
			Player p = go.GetComponent<Player>();
            
            style.fontSize = 22;
            style.fontStyle = FontStyle.Bold;
            style.font = GUIFont;
            style.normal.textColor = playerFontColors[i];
            ++i;
			GUI.Box(new Rect(x, 10, 200, 25), "Player " + (p.id+1),style);
            
            style.normal.textColor = Color.white;
            style.fontSize = 14;
            GUI.Box(new Rect(x + 5, 40, 200, 30), "Jump \t", style);
            GUI.Box(new Rect(x + 5, 70, 200, 30), "Accel", style);
            GUI.Box(new Rect(x + 5, 100, 200, 30), "Deaccel", style);

            style.fontSize = 17;
            GUI.Box(new Rect(x + 90, 38, 200, 30), "" + p.input.JumpKey, style);
            GUI.Box(new Rect(x + 90, 68, 200, 30), "" + p.input.AccelerateKey, style);
            GUI.Box(new Rect(x + 90, 98, 200, 30), "" + p.input.DecelerateKey, style);

            x += Screen.width / 4F;
		}

        // + ": Decelerate: " + p.input.DecelerateKey + "\tJump: " + p.input.JumpKey + "\tAccelerate: " + p.input.AccelerateKey
	}
}