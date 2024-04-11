using UnityEngine;

namespace BehaviorTree {
    public class YvanAI : MonoBehaviour {

        public float moveSpeed;
        
        private Node _rootNode;
        
        public bool IsAlive => true;

        public GameObject NearestBed
        {
            get
            {
                GameObject[] beds = GameObject.FindGameObjectsWithTag("Bed");
                float minimalDistance = float.MaxValue;
                GameObject nearestBed = null;
                foreach (GameObject bed in beds)
                {
                    float distance = Vector3.Distance(bed.transform.position, transform.position);
                    if (distance < minimalDistance) {
                        minimalDistance = distance;
                        nearestBed = bed;
                    }
                }
                return nearestBed;
            }
        }
    
        // Start is called before the first frame update
        private void Start()
        {
            _rootNode = new Selector();
            Node sleep = new Sequence();
            _rootNode.Children.Add(sleep);
            Node isAlive = new IsAlive();
            sleep.Children.Add(isAlive);
            Node nearestBedExist = new NearestBedExist();
            sleep.Children.Add(nearestBedExist);
            Node moveToNearestBed = new MoveToNearestBed();
            sleep.Children.Add(moveToNearestBed);
            
        }

        // Update is called once per frame
        private void Update()
        {
            _rootNode.Execute(this);
        }
    }
}