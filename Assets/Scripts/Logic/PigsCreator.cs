using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Logic
{
    public class PigsCreator : MonoBehaviour
    {
        public GameObject placeForMove;
        public GameObject pigPrefab;
        
        private MeshCollider _planeMeshCol;
        private Renderer _planeRenderer;
        
        [SerializeField] private int rightNumberPigs;

        private void Start()
        {
            _planeMeshCol = placeForMove.GetComponent<MeshCollider>();
            _planeRenderer = placeForMove.GetComponent<Renderer>();

            InstantiatePigsInMap(CalculatePositionsForPigs());
        }

        private List<Vector3> CalculatePositionsForPigs()
        {
            List<Vector3> positionForPigs = new List<Vector3>();

            for (int i = 0; i < rightNumberPigs; i++)
            {
                positionForPigs.Add(_planeRenderer.bounds.center + new Vector3(
                    Random.Range(-_planeMeshCol.bounds.size.x / 2, _planeMeshCol.bounds.size.x / 2), 
                    0,
                    Random.Range(-_planeMeshCol.bounds.size.z / 2, _planeMeshCol.bounds.size.z / 2)
                ));
            }
            return positionForPigs;
        }

        private void InstantiatePigsInMap(List<Vector3> positionsForPigs)
        {
            foreach (var pos in positionsForPigs)
            {
                Instantiate(pigPrefab, pos, Quaternion.identity);   
            }
        }
    }
}

