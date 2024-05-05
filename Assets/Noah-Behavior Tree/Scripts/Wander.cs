using System;
using UnityEngine;
using UnityEngine.AI;
using Noah_Behavior_Tree.Scripts.BehaviorTree;

namespace Noah_Behavior_Tree.Scripts
{
    [Serializable]
    public class Wander : Leaf
    {
        private Vector3 _randomDestination;
        private bool _isWandering = false;
        private bool _isPaused = false;
        private float _pauseDuration = 0f;
        private float _pauseTimer = 0f;
        private float _maxDistance = 2.5f; 

        public override bool Execute(AnimalAI animalAI)
        {
            if (!animalAI.IsHungry && !animalAI.IsThirsty && !animalAI.IsSleepy && !animalAI.IsInLove)
            {
                if (!_isWandering && !_isPaused)
                {
                    _randomDestination = GetRandomPointInField(animalAI.transform.position, _maxDistance);
                    _isWandering = true;
                }

                if (_isWandering && Vector3.Distance(animalAI.transform.position, _randomDestination) <= 1.0f)
                {
                    _isWandering = false;
                    _isPaused = true;
                    _pauseDuration = UnityEngine.Random.Range(2f, 10f); 
                    _pauseTimer = 0f;
                }

                if (_isPaused)
                {
                    _pauseTimer += Time.deltaTime;
                    if (_pauseTimer >= _pauseDuration)
                    {
                        _isPaused = false;
                    }
                }

                if (!_isWandering && !_isPaused)
                {
                    _randomDestination = GetRandomPointInField(animalAI.transform.position, _maxDistance);
                    _isWandering = true;
                }

                if (_isWandering)
                {
                    animalAI.anim.SetInteger("Walk", 1);
                    animalAI.NavMeshAgent.SetDestination(_randomDestination);
                }
                else
                {
                    animalAI.anim.SetInteger("Walk", 0);
                }
            }
            else
            {
                _isWandering = false;
                animalAI.anim.SetInteger("Walk", 0);
            }

            return false;
        }

        private Vector3 GetRandomPointInField(Vector3 origin, float radius)
        {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;
            randomDirection += origin;
            randomDirection.y = 0f;
            return randomDirection;
        }
    }
}
