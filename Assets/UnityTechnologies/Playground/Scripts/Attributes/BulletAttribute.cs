using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Bullet")]
public class BulletAttribute : MonoBehaviour
{
	[HideInInspector]
	public int playerId;

	//This will create a dialog window asking for which dialog to add
	//Collder2D の形を選ばせるダイアログを表示する
	private void Reset()
	{
		Utils.Collider2DDialogWindow(this.gameObject, true);
	}
}
