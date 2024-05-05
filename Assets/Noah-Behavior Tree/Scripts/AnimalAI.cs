using System.Collections.Generic;
using Noah_Behavior_Tree.Scripts.BehaviorTree;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Jobs;
using Sequence = Noah_Behavior_Tree.Scripts.BehaviorTree.Sequence;
public enum AICategory
{
    Chicken,
    Dog,
}

namespace Noah_Behavior_Tree.Scripts
{
    public class AnimalAI : MonoBehaviour
    {
        public AICategory aiCategory;

        public bool IsAlive => true;

        [Header("Sleeping Behavior")] public bool IsSleepy;
        public bool IsSleeping = false;
        public float SleepTime = 5f;
        public GameObject SleepingArea;

        [Header("Feeding Behavior")] public bool IsHungry;
        public GameObject[] FeedingAreas;

        [Header("Drinking Behavior")] public bool IsThirsty;
        public GameObject[] DrinkingAreas;

        [Header("Coupling Behavior")] public bool IsInLove;
        public GameObject[] CouplingAreas;
        public GameObject BabyChickenPrefab;
        public GameObject BabyDogPrefab;
        
        [HideInInspector] public NavMeshAgent NavMeshAgent;
        [HideInInspector] public Animator anim;


        public GameObject NearestFeedingArea
        {
            get
            {
                FeedingAreas = GameObject.FindGameObjectsWithTag("Food " + aiCategory);

                float minDistance = float.MaxValue;
                GameObject nearestArea = null;

                foreach (GameObject feedingArea in FeedingAreas)
                {
                    float distance = Vector3.Distance(transform.position, feedingArea.transform.position);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestArea = feedingArea;
                    }
                }

                return nearestArea;
            }
            set { }
        }

        public GameObject NearestDrinkingArea
        {
            get
            {
                DrinkingAreas = GameObject.FindGameObjectsWithTag("Water");

                float minDistance = float.MaxValue;
                GameObject nearestArea = null;

                foreach (GameObject drinkingArea in DrinkingAreas)
                {
                    float distance = Vector3.Distance(transform.position, drinkingArea.transform.position);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestArea = drinkingArea;
                    }
                }

                return nearestArea;
            }
            set { }
        }

        public GameObject NearestCouplingArea
        {
            get
            {
                CouplingAreas = GameObject.FindGameObjectsWithTag("Female " + aiCategory);

                float minDistance = float.MaxValue;
                GameObject nearestArea = null;

                foreach (GameObject couplingArea in CouplingAreas)
                {
                    float distance = Vector3.Distance(transform.position, couplingArea.transform.position);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestArea = couplingArea;
                    }
                }

                return nearestArea;
            }
            set { }
        }


        private Node _rootNode;

        private void Awake()
        {
            NavMeshAgent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            _rootNode.Execute(this);
        }

        private void Start()
        {
            UpdateDrinkingAreas(DrinkingAreas, aiCategory);
            UpdateFeedingAreas(FeedingAreas, aiCategory);
            UpdateCouplingAreas(CouplingAreas, aiCategory);
            
            _rootNode = new Selector();
            
            // Initialize Sleeping Behavior
            Node sleepingSequence = new Sequence();
            _rootNode.Children.Add(sleepingSequence);

            Node isSleepy = new IsSleepy();
            sleepingSequence.Children.Add(isSleepy);

            Node sleepingAreaExist = new SleepingAreaExist();
            sleepingSequence.Children.Add(sleepingAreaExist);

            Node moveToSleepingArea = new MoveToSleepingArea();
            sleepingSequence.Children.Add(moveToSleepingArea);

            Node sleep = new Sleep();
            sleepingSequence.Children.Add(sleep);
            
            // Initialize Coupling Behavior
            Node couplingSequence = new Sequence();
            _rootNode.Children.Add(couplingSequence);

            Node isInLove = new IsInLove();
            couplingSequence.Children.Add(isInLove);

            Node couplingAreaExist = new CouplingAreaExist();
            couplingSequence.Children.Add(couplingAreaExist);

            Node moveToCouplingArea = new MoveToCouplingArea();
            couplingSequence.Children.Add(moveToCouplingArea);

            Node copulate = new Copulate();
            couplingSequence.Children.Add(copulate);
            
            // Initialize Drinking Behavior
            Node drinkingSequence = new Sequence();
            _rootNode.Children.Add(drinkingSequence);

            Node isThirsty = new IsThirsty();
            drinkingSequence.Children.Add(isThirsty);

            Node drinkingAreaExist = new DrinkingAreaExist();
            drinkingSequence.Children.Add(drinkingAreaExist);

            Node moveToDrinkingArea = new MoveToDrinkingArea();
            drinkingSequence.Children.Add(moveToDrinkingArea);

            Node drink = new Drink();
            drinkingSequence.Children.Add(drink);
            
            // Initialize Feeding Behavior
            Node feedingSequence = new Sequence();
            _rootNode.Children.Add(feedingSequence);

            Node isHungry = new IsHungry();
            feedingSequence.Children.Add(isHungry);

            Node feedingAreaExist = new FeedingAreaExist();
            feedingSequence.Children.Add(feedingAreaExist);

            Node moveToFeedingArea = new MoveToFeedingArea();
            feedingSequence.Children.Add(moveToFeedingArea);

            Node feed = new Feed();
            feedingSequence.Children.Add(feed);

            Node wander = new Wander();
            _rootNode.Children.Add(wander);
        }

        public static void UpdateDrinkingAreas(GameObject[] availableDrinkingAreas, AICategory category)
        {
            foreach (AnimalAI ai in FindObjectsOfType<AnimalAI>())
            {
                ai.DrinkingAreas = availableDrinkingAreas;
            }
        }

        public static void UpdateFeedingAreas(GameObject[] availableFeedingAreas, AICategory category)
        {
            foreach (AnimalAI ai in FindObjectsOfType<AnimalAI>())
            {
                if (ai.aiCategory == category)
                {
                    ai.FeedingAreas = availableFeedingAreas;
                }
            }
        }


        public static void UpdateCouplingAreas(GameObject[] availableCouplingAreas, AICategory category)
        {
            foreach (AnimalAI ai in FindObjectsOfType<AnimalAI>())
            {
                if (ai.aiCategory == category)
                {
                    ai.CouplingAreas = availableCouplingAreas;
                }
            }
        }

        public void CustomDestroy(GameObject thingToDestroy)
        {
            if (thingToDestroy != null)
            {
                Destroy(thingToDestroy);
            }
        }

        public void MakeBabies(AICategory category)
        {
            foreach (AnimalAI ai in FindObjectsOfType<AnimalAI>())
            {
                if (ai.aiCategory == category)
                {
                    switch (category)
                    {
                        case AICategory.Chicken:
                            Instantiate(BabyChickenPrefab, transform.position, Quaternion.identity);
                            break;
                        case AICategory.Dog:
                            Instantiate(BabyDogPrefab, transform.position, Quaternion.identity);
                            break;
                    }
                }
            }
        }
    }
}
