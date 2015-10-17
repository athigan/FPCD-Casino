using UnityEngine;
using System.Collections;

namespace KGDEngin
{
	public class DebugMessage : MonoBehaviour
	{
		private static DebugMessage m_singleton;
		
		private static DebugMessage Getsingleton ()
		{
			if (m_singleton == null) {
				GameObject go = new GameObject ("DebugMessage");
				DontDestroyOnLoad(go);
				m_singleton = go.AddComponent<DebugMessage> ();
			}
			return m_singleton;
		}
		
		public static void Log (object message, Color? color = null, int size = -1, bool isBold = false)
		{
			#if UNITY_EDITOR
			Color c = color ?? Color.white;
			string colorSKDebuger = "";
			if(color != null)
				colorSKDebuger = GetColor(c);
			
			string colorBegin = "<color=" + colorSKDebuger + ">";
			string colorEnd = "</color>";
			
			string sizeBegin = "<size=" + size + ">";
			string sizeEnd = "</size>";
			
			string boldBegin = "<b>";
			string boldEnd = "</b>";
			
			string log = "";
			
			if (isBold)
				log += boldBegin;
			if (color != null)
				log += colorBegin;
			if (size != -1)
				log += sizeBegin;
			
			log += message.ToString();
			
			if (size != -1)
				log += sizeEnd;
			if (color != null)
				log += colorEnd;
			if (isBold)
				log += boldEnd;
			
			Debug.Log (log);
			#endif
		}
		
		private static string GetColor (Color color)
		{
			if (color == Color.blue)
				return "blue";
			if (color == Color.red)
				return "red";
			if (color == Color.black)
				return "black";
			if (color == Color.magenta)
				return "magenta";
			if (color == Color.cyan)
				return "cyan";
			if (color == Color.gray)
				return "gray";
			if (color == Color.green)
				return "green";
			if (color == Color.grey)
				return "grey";
			if (color == Color.yellow)
				return "yellow";
			
			return "white";
		}
	}
}

