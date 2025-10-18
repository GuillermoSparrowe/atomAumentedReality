using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreacionH2O : MonoBehaviour
{
    //NACl Cloruro de sodio
    public GameObject targetO;
    public GameObject targetH;
    public GameObject targetH2;   
    private bool detecC;
    private bool detecH;
    private bool detecH2;
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
        detecH= false;
        detecH2= false;
        infoAct = false;  //---------------------------------
    }

    // Update is called once per frame
    void Update()
    {
        if (detecH && detecC && detecH2){
        distancia = targetO.transform.position - targetH.transform.position;
        distancia2 = targetO.transform.position - targetH2.transform.position;

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
        else if(!detecH || !detecC || !detecH2) dest = true;

        return dest;

        
    }

    public void crearMolecula(){
        
        desactivarHijos(targetO);
        desactivarHijos(targetH);
        desactivarHijos(targetH2);
            creado = true;
             molecula = Instantiate(prefab, targetO.transform.position,transform.rotation);
              texto = molecula.transform.GetChild(2).gameObject;   //------------------------------------------------------------
             texto.SetActive(false);                                //---------------------------------
    }
    
    public void destruirMolecula(){
        creado = false;
        Destroy(molecula);
        activarHijos(targetO);
        activarHijos(targetH);
        activarHijos(targetH2);
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

    public  void noDetectarO(){
         detecC = false;
        
    }
    public void noDetectarH(){
        detecH = false;
    }
    public void noDetectarH2(){
        detecH2 = false;
    }
    public  void detectarO(){
         detecC = true;
    }
    public void detectarH(){
        detecH = true;
    }
    public void detectarH2(){
        detecH2 = true;
    }

    }

