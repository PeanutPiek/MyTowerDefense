using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTowerDefense
{
    public class UITextInfo
    {

        private string _text;

        private Vector2 _anchor;

        private Vector2 _target;

        private GameObject _object;
        
        public UITextInfo(string text, Vector2 anchor, Vector2 target)
        {
            _text = text;
            _anchor = anchor;
            _target = target;
        }


        public void Setup(GameObject go)
        {
            TextMesh mesh = go.GetComponent<TextMesh>();
            if (mesh != null)
            {
                mesh.text = _text;
            }
            go.transform.position = _anchor;
            _object = go;
        }


        public void Tick(float time)
        {
            ob = _object;
            Vector2 dir = new Vector2(_target.x - ob.transform.position.x, _target.y - ob.transform.position.y);
            Vector2 dirN = dir.normalized;
            Vector2 position = ob.transform.position;
            Vector2 nPos = new Vector2(position.x + dirN.x * time, position.y + dirN.y * time);
            ob.transform.position = nPos;
        }


        public bool HasReachedTarget()
        {
            Vector2 pos = _object.tranform.position;
            Vector2 dir = new Vector2(_target.x - pos.x, _target.y - pos.y);
            return (dir.magnitude < 0.1);
        }

    }

}
