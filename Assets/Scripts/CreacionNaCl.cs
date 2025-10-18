using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreacionNaCl : MonoBehaviour
{
    //NACl Cloruro de sodio
    public GameObject targetNA;
    public GameObject targetCl;  
    private bool detecNa;
    private bool detecCl;
    public GameObject prefab;
    private GameObject molecula;
    private Vector3 distancia;
    public bool creado;
    public int umbral;
    private GameObject texto;   //---------------------------------
    private bool infoAct;       //---------------------------------

    
    // Start is called before the first frame update
    void Start()
    {
        creado =  false;
        detecNa = false;
        detecCl= false;
        infoAct = false;  //---------------------------------
    }

    // Update is called once per frame
    void Update()
    {
        if (detecCl && detecNa){
        distancia = targetNA.transform.position - targetCl.transform.position;

        if(distancia.magnitude < umbral && creado == false){

            crearMolecula();
        }
        }

        if(creado && condicionesDestruccion())
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

        if (distancia.magnitude > umbral) dest = true;
        else if(!detecCl || !detecNa) dest = true;

        return dest;

        
    }

    public void crearMolecula(){
        
        desactivarHijos(targetNA);
            desactivarHijos(targetCl);
            creado = true;
             molecula = Instantiate(prefab, targetNA.transform.position,transform.rotation);
             texto = molecula.transform.GetChild(1).gameObject;   //------------------------------------------------------------
             texto.SetActive(false);                                //---------------------------------
    }
    
    public void destruirMolecula(){
        creado = false;
        Destroy(molecula);
        activarHijos(targetNA);
        activarHijos(targetCl);
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

    public  void noDetectarNa(){
         detecNa = false;
        
    }
    public void noDetectarCl(){
        detecCl = false;
    }
    public  void detectarNa(){
         detecNa = true;
    }
    public void detectarCl(){
        detecCl = true;
    }
    }