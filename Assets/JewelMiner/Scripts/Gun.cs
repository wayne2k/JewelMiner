using UnityEngine;
using System.Collections;

namespace RollRoti.JewelMiner
{
	public class Gun : MonoBehaviour 
	{
		public GameObject claw;
		public bool isShooting;
		public Animator _minerAnim;
		public Claw clawScript;

		void Update () 
		{
			if (Input.GetButtonDown ("Fire1") && isShooting == false) 
			{
				LaunchClaw ();			
			}
		}

		void LaunchClaw ()
		{
			isShooting = true;
			_minerAnim.speed = 0f;
			RaycastHit hit;
			Vector3 down = transform.TransformDirection (Vector3.down);

			if (Physics.Raycast (transform.position, down, out hit, 100f))
			{
				claw.SetActive (true);
				clawScript.ClawTarget (hit.point);
			}
		}

		public void CollectedObject ()
		{
			isShooting = false;
			_minerAnim.speed = 1f;
		}
	}
}