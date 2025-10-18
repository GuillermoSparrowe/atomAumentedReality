using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreacionCO : MonoBehaviour
{
    //NACl Cloruro de sodio
    public GameObject targetC;
    public GameObject targetO;  
    private bool detecC;
    private bool detecO;
    public GameObject prefab;
    private GameObject molecula;
    private Vector3 distancia;
    public bool creado;
    public int umbral;
    CreacionCO2 co2;
    private GameObject texto;   //---------------------------------
    private bool infoAct;       //---------------------------------

    
    // Start is called before the first frame update
    void Start()
    {
        co2 = GetComponent<CreacionCO2>();
        creado =  false;
        detecC = false;
        detecO= false;
        infoAct = false;  //---------------------------------

    }

    // Update is called once per frame
    void Update()
    {
        if (detecO && detecC){
        distancia = targetC.transform.position - targetO.transform.position;

        if(distancia.magnitude < umbral && creado == false){

            crearMolecula();
        }
        }

        if(creado == true && condicionesDestruccion())
        {
            destruirMolecula();
        }
        //para controlar que no haya dos moleculas a la vez co y co2
        if(creado==true && co2.creado){
                creado = false;
                Destroy(molecula);
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

        if (distancia.magnitude > umbral) dest = true;
        else if(!detecO || !detecC) dest = true;
        
        return dest;

        
    }

    public void crearMolecula(){
        
        desactivarHijos(targetC);
            desactivarHijos(targetO);
            creado = true;
             molecula = Instantiate(prefab, targetC.transform.position,transform.rotation);
             texto = molecula.transform.GetChild(1).gameObject;   //------------------------------------------------------------
             texto.SetActive(false);                                //---------------------------------
    }
    
    public void destruirMolecula(){
        creado = false;
        Destroy(molecula);
        activarHijos(targetC);
        activarHijos(targetO);
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
            if(infoAct) hijo.gameObject.SetActive(true);
            else{
                if(hijo.name != "texto") hijo.gameObject.SetActive(true);
            }
        }
    }

    public  void noDetectarC(){
         detecC = false;
        
    }
    public void noDetectarO(){
        detecO = false;
    }
    public  void detectarC(){
         detecC = true;
    }
    public void detectarO(){
        detecO = true;
    }

    }

