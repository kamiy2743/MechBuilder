using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class ItemCollider : MonoBehaviour
    {
        [Header("デバッグ用")]
        [SerializeField] private bool _drawSnapPoint = false;

        public Vector3 Size => _collider.size;

        private BoxCollider _collider;

        private const float _snapUnit = 0.5f;
        private List<Vector3> _localSnapPoints;

        void Awake()
        {
            _collider = GetComponent<BoxCollider>();
            _localSnapPoints = CalcLocalSnapPoints();
        }

        // 毎フレーム呼ぶことが想定されるのでできるだけ高速化したい
        // TODO _snapUnit以下で計算を終了すればもっと早くなる
        public Vector3 CalcNearestSnapPoint(Vector3 target)
        {
            var points = new List<Vector3>(_localSnapPoints.Count);
            var position = transform.position;

            var distance = float.PositiveInfinity;
            var nearest = Vector3.zero;

            foreach (var localPoint in _localSnapPoints)
            {
                var globalPoint = localPoint + position;
                var d2 = Vector3.SqrMagnitude(globalPoint - target);

                if (d2 < distance)
                {
                    distance = d2;
                    nearest = globalPoint;
                }
            }

            return nearest;
        }

        private List<Vector3> CalcLocalSnapPoints()
        {
            var origin = _collider.center - (Size * 0.5f);

            var xPoints = CalcLocalSnapPoints1D(origin.x, Size.x);
            var yPoints = CalcLocalSnapPoints1D(origin.y, Size.y);
            var zPoints = CalcLocalSnapPoints1D(origin.z, Size.z);

            var points = new List<Vector3>();

            foreach (var y in xPoints)
            {
                foreach (var z in yPoints)
                {
                    var x = Size.x / 2;
                    points.Add(new Vector3(x, y, z));
                    points.Add(new Vector3(-x, y, z));
                }
            }
            foreach (var x in xPoints)
            {
                foreach (var z in yPoints)
                {
                    var y = Size.y / 2;
                    points.Add(new Vector3(x, y, z));
                    points.Add(new Vector3(x, -y, z));
                }
            }
            foreach (var x in xPoints)
            {
                foreach (var y in yPoints)
                {
                    var z = Size.z / 2;
                    points.Add(new Vector3(x, y, z));
                    points.Add(new Vector3(x, y, -z));
                }
            }

            return points;
        }

        private List<float> CalcLocalSnapPoints1D(float origin, float size)
        {
            var points = new List<float>();

            for (int i = 0; i < size / _snapUnit; i++)
            {
                points.Add(origin + (_snapUnit / 2) + (i * _snapUnit));
            }

            return points;
        }

        // デバッグ用
        void OnDrawGizmos()
        {
            if (!_drawSnapPoint) return;

            foreach (var point in _localSnapPoints)
            {
                Gizmos.color = new Color(1f, 0, 0, 0.5f);
                Gizmos.DrawSphere(transform.position + point, 0.05f);
            }
        }
    }
}
