using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace KGDEngin
{
	public class AnimateTextRunning : MonoBehaviour
	{
		protected Text m_textUI;
		protected tk2dTextMesh m_textTK2d;
		protected int LastTargatNum;
	
		public void Awake ()
		{
			m_textUI = GetComponent<Text> ();
			m_textTK2d = GetComponent<tk2dTextMesh> ();
		}

		private void SetText (int num)
		{
			if (m_textUI != null)
				m_textUI.text = num.ToString ("N0");
			else
				m_textTK2d.text = num.ToString ("N0");
		}

		private string GetTextWithOutComma ()
		{
			if (m_textUI != null)
				return m_textUI.text.Replace (",", "");
			else
				return m_textTK2d.text.Replace (",", "");
		}
		/// <summary>
		/// Sets the text number.
		/// </summary>
		/// <param name="targetNum">Target number.</param>
		/// <param name="bAnimated">If set to <c>true</c> animated.</param>
		/// <param name="secondToDone">Time to finish animate in seconds.</param>
		public void SetTextNumber (int targetNum, bool bAnimated, float secondToDone = 0.5f)
		{
			if (bAnimated) {
				StopCoroutine ("DoSetTextNumber");
				StartCoroutine (DoSetTextNumber (targetNum, secondToDone));
			} else {
				SetText (targetNum);
			}
		}
	
		protected IEnumerator DoSetTextNumber (int targetNum, float secondToDone)
		{
			int oldNum = System.Int32.Parse (GetTextWithOutComma ());
		
			LastTargatNum = targetNum;
		
			// Check changed?
			if (oldNum == targetNum)
				yield break; // Don't change
		
			BeginAnimateNumber (targetNum, oldNum);
		
			// Animation number
			bool bFinished = false;
			int diff = targetNum - oldNum;
			float multiplier = 1.0f / secondToDone;
			float f_diffAccumulate = 0.0f;
			while (!bFinished) {
				// Animate finish in secondToDone second.
			
				// Calc diff for this frame
				int diffThisFrame = 0;
				float f_diffThisFrame = diff * Time.smoothDeltaTime * multiplier;
			
				/*
				// This code make number change every frame.
				if (f_diffThisFrame < 0)
					diffThisFrame = (int)System.Math.Floor (f_diffThisFrame);
				else if (f_diffThisFrame > 0)
					diffThisFrame = (int)System.Math.Ceiling (f_diffThisFrame);
				/*/
				// This code accumulate diff until pass 1 or -1
				f_diffAccumulate += f_diffThisFrame;
				if (System.Math.Abs (f_diffAccumulate) < 1) { // Not pass 1 or -1
					yield return null; // Wait for next frame
					continue; // Begin while
				}
				diffThisFrame = (int)f_diffAccumulate;
				f_diffAccumulate -= diffThisFrame;
				//*/
			
				// Calc num for this frame
				oldNum = System.Int32.Parse (GetTextWithOutComma ());
				int num = oldNum + diffThisFrame;
				if ((diff < 0) && (num <= targetNum)) { // Cap
					num = targetNum;
					bFinished = true;
				}
				if ((diff > 0) && (num >= targetNum)) { // Cap
					num = targetNum;
					bFinished = true;
				}
			
				// Break Loop if target is not Last Result Number
				if (LastTargatNum != targetNum) {
					num = targetNum;
					bFinished = true;
				}
			
				// Set text
				SetText (num);
				yield return null; // Wait for next frame
			}
		
			EndAnimateNumber ();
			yield break;
		}
	
		protected virtual void BeginAnimateNumber (int targetNum, int oldNum)
		{
			// Open to override by subclass
		}
	
		protected virtual void EndAnimateNumber ()
		{
			// Open to override by subclass
		}
	}
}
