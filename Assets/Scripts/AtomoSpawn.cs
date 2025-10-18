using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomoSpawn : MonoBehaviour
{
    public GameObject electronPref;
    public GameObject esferaNucleoPrefab;
    public int numeroEsferasPorNivel = 8;
    public float distanciaEntreNiveles = 1.0f;
    public int numelectrones = 3;
    public float velElectron = 30f;
    public int numeroEsferasNucleo;
    public int numProtones;
    // Definimos nuestros datos privados
    public float radio = 0.05f;
    private float pi = Mathf.PI;
    public int K, M, L;


    // Start is called before the first frame update
    void Start()
    {
        //Obtenemos position del para tener padre generador
        Transform padreCl = gameObject.transform;

        //Creo esferas
        for (int i = 0; i < numeroEsferasNucleo; i++)
        {
            // Creo esfera en posi del gameobject
            GameObject esferaNucleo = Instantiate(esferaNucleoPrefab, padreCl.position, Quaternion.identity);

            // Establecer el padre 
            esferaNucleo.transform.parent = padreCl;
        }
            for (int x = 0; x < padreCl.childCount; x++)
            {
                //Formula del profe para obtener random spawns
                float n1 = Random.Range(0, pi);
                float n2 = Random.Range(0, 2 * pi);
                //Determinar color
                if (x <= numProtones)
                {
                    padreCl.GetChild(x).transform.GetComponent<Renderer>().material.color = Color.red;
                }
                else if (x > numProtones)
                {
                    padreCl.GetChild(x).transform.GetComponent<Renderer>().material.color = Color.yellow;
                }

                //Determinar vector spawn
                padreCl.GetChild(x).transform.position = new Vector3(transform.position.x + radio * Mathf.Sin(n1) * Mathf.Cos(n2), transform.position.y + radio * Mathf.Sin(n1) * Mathf.Sin(n2), transform.position.z + radio * Mathf.Cos(n1) * Mathf.Cos(n2));
            }


            //electrones

            for (int i = 0; i < numelectrones; i++) // Generar en 3 niveles diferentes
            {
                float nivelY = (i +2) * distanciaEntreNiveles;
            if (i == 0)
            {
                for (int j = 0; j < K; j++)
                {
                    float angulo = j * (2 * pi / K);
                    Vector3 smallSpherePosition = new Vector3(transform.position.x + nivelY * Mathf.Cos(angulo),
                                                              transform.position.y,
                                                              transform.position.z + nivelY * Mathf.Sin(angulo));
                    // Crear esfera pequeña como hijo del padre
                    GameObject electron = Instantiate(electronPref, smallSpherePosition, Quaternion.identity);
                    electron.transform.parent = transform; // Establecer el padre como el objeto Cloro

                }

            }else if (i == 1)
            {
                for (int j = 0; j < L; j++)
                {
                    float angulo = j * (2 * pi / L); ;
                    Vector3 smallSpherePosition = new Vector3(transform.position.x + nivelY * Mathf.Cos(angulo),
                                                              transform.position.y,
                                                              transform.position.z + nivelY * Mathf.Sin(angulo));
                    // Crear esfera pequeña como hijo del padre
                    GameObject electron = Instantiate(electronPref, smallSpherePosition, Quaternion.identity);
                    electron.transform.parent = transform; // Establecer el padre como el objeto Cloro

                }
            }else if (i == 2)
            {
                for (int j = 0; j < M; j++)
                {
                    float angulo = j * (2 * pi / M) ;
                    Vector3 smallSpherePosition = new Vector3(transform.position.x + nivelY * Mathf.Cos(angulo),
                                                              transform.position.y,
                                                              transform.position.z + nivelY * Mathf.Sin(angulo));
                    // Crear esfera pequeña como hijo del padre
                    GameObject electron = Instantiate(electronPref, smallSpherePosition, Quaternion.identity);
                    electron.transform.parent = transform; // Establecer el padre como el objeto Cloro

                }
            }
        }
        }

        // Update is called once per frame
        void Update()
        {
        foreach (Transform electronT in transform)
        {
            if (electronT.CompareTag("Electron"))
            {
                electronT.RotateAround(transform.position, Vector3.up, velElectron * Time.deltaTime);
            }
        }
        }
    }