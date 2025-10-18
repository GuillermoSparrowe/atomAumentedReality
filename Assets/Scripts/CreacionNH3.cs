using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreacionNH3 : MonoBehaviour
{
    public GameObject targetN;
    public GameObject targetH;
    public GameObject targetH2;
    public GameObject targetH3;   
    private bool detecN;
    private bool detecH;
    private bool detecH2;
    private bool detecH3;
    public GameObject prefab;
    private GameObject molecula;
    private Vector3 distancia;
    private Vector3 distancia2;
    private Vector3 distancia3;
    public bool creado;
    public int umbral;
     private GameObject texto;   //---------------------------------
    private bool infoAct;       //---------------------------------

    
    // Start is called before the first frame update
    void Start()
    {
        creado =  false;
        detecN = false;
        detecH= false;
        detecH2= false;
        detecH3= false;
        infoAct = false;  //---------------------------------
    }

    // Update is called once per frame
    void Update()
    {
        if (detecH && detecN && detecH2 && detecH3){
            
        distancia = targetN.transform.position - targetH.transform.position;
        distancia2 = targetN.transform.position - targetH2.transform.position;
        distancia3 = targetN.transform.position - targetH3.transform.position;

        if(distancia.magnitude < umbral && distancia2.magnitude < umbral && distancia3.magnitude < umbral && creado == false){

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

        if (distancia.magnitude > umbral || distancia2.magnitude > umbral || distancia3.magnitude > umbral ) dest = true;
        else if(!detecH || !detecN || !detecH2 ||!detecH3) dest = true;

        return dest;
        
    }

    public void crearMolecula(){
        
        desactivarHijos(targetN);
        desactivarHijos(targetH);
        desactivarHijos(targetH2);
        desactivarHijos(targetH3);
            creado = true;
             molecula = Instantiate(prefab, targetN.transform.position,transform.rotation);
              texto = molecula.transform.GetChild(3).gameObject;   //------------------------------------------------------------
             texto.SetActive(false);                                //---------------------------------
    }
    
    public void destruirMolecula(){
        creado = false;
        Destroy(molecula);
        activarHijos(targetN);
        activarHijos(targetH);
        activarHijos(targetH2);
        activarHijos(targetH3);
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

    public  void noDetectarN(){
         detecN = false;
        
    }
    public void noDetectarH(){
        detecH = false;
    }
    public void noDetectarH2(){
        detecH2 = false;
    }
     public void noDetectarH3(){
        detecH3 = false;
    }
    public  void detectarN(){
         detecN = true;
    }
    public void detectarH(){
        detecH = true;
    }
    public void detectarH2(){
        detecH2 = true;
    }
    public void detectarH3(){
        detecH3 = true;
    }

    }

