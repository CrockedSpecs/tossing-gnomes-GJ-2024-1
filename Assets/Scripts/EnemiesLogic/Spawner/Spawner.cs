using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Variables
    [Header("Fields")]
    [SerializeField] GameObject spawnPointPrefab;

    [SerializeField]
    int existingFields;

    [SerializeField]
    int spawnPointNumber;

    [HideInInspector]
    [SerializeField]
    int assumption = 1;

    
    [SerializeField]
    float distance = 5;

    [SerializeField] List<GameObject> spawnPoints = new List<GameObject>();

    [HideInInspector]
    [SerializeField]
    List<Vector3> positionsList = new List<Vector3>();

    [HideInInspector]
    [SerializeField]
    List<Quaternion> anglesList = new List<Quaternion>();
    #endregion

    #region Encapsulate
    public int ExistingFields { get => existingFields; set => existingFields = value; }
    public int Assumption { get => assumption; set => assumption = value; }
    public float Distance { get => distance; set => distance = value; }
    public List<GameObject> SpawnPoints { get => spawnPoints; set => spawnPoints = value; }
    public List<Vector3> PositionsList { get => positionsList; set => positionsList = value; }
    public List<Quaternion> AnglesList { get => anglesList; set => anglesList = value; }
    public GameObject SpawnPointPrefab { get => spawnPointPrefab; set => spawnPointPrefab = value; }
    public int SpawnPointNumber { get => spawnPointNumber; set => spawnPointNumber = value; }

    #endregion

    #region Add spawn points
    public void AddTeamFields(int spawnPointNumber, GameObject teamFieldPrefab)
    {
        //spawnPointNumber = 1;
        ExistingFields += spawnPointNumber;

        Quaternion rotation;
        Vector3 direction;
        Vector3 position;
        Quaternion rotationCorrection;


        if (Assumption <= ExistingFields)
        {
            //assumption = 1;
            //positionsList.Clear();
            //anglesList.Clear();
            Assumption = ExistingFields * 2;
            float angleOfTheSections = 360 / Assumption;
            for (int j = 0; j < Assumption; j++)
            {
                rotation = Quaternion.AngleAxis
                    (
                        angleOfTheSections * j
                        , Vector3.forward
                    ) 
                    * transform.rotation;

                direction = rotation * Vector3.forward;
                position = transform.position 
                    + direction * Distance;

                if (!PositionsList.Contains(position))
                {
                    PositionsList.Add(position);
                }


                rotationCorrection = Quaternion.AngleAxis(180 + angleOfTheSections * j, Vector3.up) * transform.rotation;
                if (!AnglesList.Contains(rotationCorrection))
                {
                    AnglesList.Add(rotationCorrection);
                }
            }
        }

        for (int i = 0; i < ExistingFields; i++)
        {
            if (i >= SpawnPoints.Count)
            {

                SpawnPoints.Add(Instantiate(teamFieldPrefab, PositionsList[i], AnglesList[i], transform));
            }
        }
    }

    public void AddAllSpawnPointsAtOnce(int spawnPointNumber, GameObject teamFieldPrefab)
    {

        Quaternion rotation;
        Vector3 direction;
        Vector3 position;

    
        float angleOfTheSections = 360 / spawnPointNumber;
        for (int j = 0; j < spawnPointNumber; j++)
        {
            rotation = Quaternion.AngleAxis
                (
                    angleOfTheSections * j
                    , Vector3.forward
                )
                * transform.rotation;

            direction = rotation * Vector3.forward;
            position = transform.position
                + direction * Distance;
            Debug.Log(spawnPointNumber);
            SpawnPoints.Add
            (
                Instantiate
                    (
                        teamFieldPrefab
                        , position
                        , rotation
                        , transform
                    )
            );
        }
    }

    #endregion

    #region Removers
    public void RemoveLastSpawnPoint()
    {
        if (SpawnPoints.Count > 0)
        {
            if (true)
            {

            }
            DestroyImmediate(SpawnPoints[SpawnPoints.Count - 1]);
            SpawnPoints.RemoveAt(SpawnPoints.Count - 1);
            existingFields--;
        }
    }

    public void ClearSpawnPoints()
    {
        assumption = 1;
        if (SpawnPoints.Count >= 0)
        {
            foreach (var item in SpawnPoints)
            {
                DestroyImmediate(item);
            }
            positionsList.Clear();
            anglesList.Clear();
            SpawnPoints.Clear();
            existingFields = 0;
        }
    }
    #endregion

    private void OnDrawGizmos()
    {
        foreach (var item in SpawnPoints)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(this.transform.position, item.transform.position);
        }
    }
}
