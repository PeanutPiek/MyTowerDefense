using System;

using UnityEngine;

namespace MyTowerDefense
{
	public class ValueMarker : Entity
	{

		private string _text;


		private float _ttl;


		private GameObject _parent;


		private Color _color;

		public ValueMarker (GameObject parent, string text, float ttl, Color color) : base("Marker", Resources.Load<GameObject> ("Prefab/Marker"))
		{
			_text = text;
			_ttl = ttl;
			_parent = parent;
			_color = color;
		}


		protected override void setupObject (GameObject ob)
		{
			base.setupObject (ob);

			ob.GetComponent<MarkerHandler> ().ttl = _ttl;
			TextMesh mesh = ob.GetComponent<TextMesh> ();
			mesh.text = _text;
			mesh.color = _color;
			ob.GetComponent<MeshRenderer> ().sortingLayerName = "Overlay";
			if (_parent != null) {
				ob.transform.position = _parent.transform.position;
			}
		}

	}
}

