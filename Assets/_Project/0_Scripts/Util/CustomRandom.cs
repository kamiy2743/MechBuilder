using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class CustomRandom
    {
        private Random.State _state;

        public CustomRandom() : this((int)System.DateTime.Now.Ticks) { }

        public CustomRandom(int seed)
        {
            SetSeed(seed);
        }

        public void SetSeed(int seed)
        {
            var prevState = Random.state;

            Random.InitState(seed);

            _state = Random.state;
            Random.state = prevState;
        }

        public int Range(int min, int max)
        {
            var prevState = Random.state; // 使用前の状態 
            Random.state = _state; // 前回の状態にセット 

            var result = Random.Range(min, max);

            _state = Random.state; // 現在の状態を記録 
            Random.state = prevState; // 使用前の状態に 
            return result;
        }

        public float Range(float min, float max)
        {
            var prevState = Random.state; // 使用前の状態 
            Random.state = _state; // 前回の状態にセット 

            var result = Random.Range(min, max);

            _state = Random.state; // 現在の状態を記録 
            Random.state = prevState; // 使用前の状態に 
            return result;
        }

        public float Value()
        {
            var prevState = Random.state; // 使用前の状態 
            Random.state = _state; // 前回の状態にセット 

            var result = Random.value;

            _state = Random.state; // 現在の状態を記録 
            Random.state = prevState; // 使用前の状態に 
            return result;
        }
    }
}
