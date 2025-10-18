using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreacionCO2 : MonoBehaviour
{
    //NACl Cloruro de sodio
    public GameObject targetC;
    public GameObject targetO;
    public GameObject targetO2;   
    private bool detecC;
    private bool detecO;
    private bool detecO2;
    public GameObject prefab;
    private GameObject molecula;
    private Vector3 distancia;
    private Vector3 distancia2;
    public bool creado;
    public int umbral;
    private GameObject texto;   //---------------------------------
    private bool infoAct;       //---------------------------------

    
    // Start is called before the first frame update
    void Start()
    {
        creado =  false;
        detecC = false;
        detecO= false;
        detecO2= false;
        infoAct = false;  //---------------------------------

    }

    // Update is called once per frame
    void Update()
    {
        if (detecO && detecC && detecO2){
        distancia = targetC.transform.position - targetO.transform.position;
        distancia2 = targetC.transform.position - targetO2.transform.position;

        if(distancia.magnitude < umbral && distancia2.magnitude < umbral && creado == false){

            crearMolecula();
        }
        }

        if(creado == true && condicionesDestruccion())
        {
            destruirMolecula();
        }

        if(Input.GetKeyDown(KeyCode.I)){             //------------------------------------------------
            if (!infoAct) infoAct = true;
            else infoAct = false;
        }
        if(creado){
               if(infoAct) texto.SetActive(true);
               else texto.SetActive(false);
        }                                            //------------------------------------------------

    }

    public bool condicionesDestruccion(){
        bool dest = false;

        if (distancia.magnitude > umbral || distancia2.magnitude > umbral) dest = true;
        else if(!detecO || !detecC || !detecO2) dest = true;

        return dest;

        
    }

    public void crearMolecula(){
        
        desactivarHijos(targetC);
        desactivarHijos(targetO);
        desactivarHijos(targetO2);
            creado = true;
             molecula = Instantiate(prefab, targetC.transform.position,transform.rotation);
              texto = molecula.transform.GetChild(2).gameObject;   //------------------------------------------------------------
             texto.SetActive(false);                                //---------------------------------
    }
    
    public void destruirMolecula(){
        creado = false;
        Destroy(molecula);
        activarHijos(targetC);
        activarHijos(targetO);
        activarHijos(targetO2);
    }

      public void desactivarHijos(GameObject padre)
    {
        foreach (Transform hijo in padre.transform)
        {
            hijo.gameObject.SetActive(false);
        }
    }

     public void activarHijos(GameObject padre)
    {
        foreach (Transform hijo in padre.transform)
        {
            hijo.gameObject.SetActive(true);
        }
    }

    public  void noDetectarC(){
         detecC = false;
        
    }
    public void noDetectarO(){
        detecO = false;
    }
    public void noDetectarO2(){
        detecO2 = false;
    }
    public  void detectarC(){
         detecC = true;
    }
    public void detectarO(){
        detecO = true;
    }
    public void detectarO2(){
        detecO2 = true;
    }

    }

