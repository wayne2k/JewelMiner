using UnityEngine;
using System.Collections;

namespace RollRoti.JewelMiner
{
	public class Claw : MonoBehaviour 
	{
		public Transform origin;
		public float speed = 4f;
		public Gun gun;

		Vector3 _target;
		int _jewelValue = 100;
		GameObject _childObject;
		LineRenderer _lineRenderer;
		bool _hitJewel;
		bool _retracting;

		void Awake ()
		{
			_lineRenderer = GetComponent <LineRenderer> ();
		}

		void Update ()
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, _target, step);

			_lineRenderer.SetPosition (0, origin.position);
			_lineRenderer.SetPosition (1, transform.position);

			if (transform.position == origin.position && _retracting)
			{
				gun.CollectedObject ();
				if (_hitJewel)
				{
					_hitJewel = false;
				}
				Destroy (_childObject);
				gameObject.SetActive (false);
			}
		}

		void OnTriggerEnter (Collider other)
		{
			_retracting = true;
			_target = origin.position;

			if (other.gameObject.CompareTag ("Jewel")) 
			{
				_hitJewel = true;
				_childObject = other.gameObject;
				other.transform.SetParent (this.transform);
			}
			else if (other.gameObject.CompareTag ("Rock"))
			{
				_childObject = other.gameObject;
				other.transform.SetParent (this.transform);
			}
		}

		public void ClawTarget (Vector3 pos)
		{
			_target = pos;
		}
	}
}