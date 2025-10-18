using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class info : MonoBehaviour
{
    public GameObject textoN;
    public GameObject textoH1;
    public GameObject textoH2;
    public GameObject textoH3; 
    public GameObject textoH4; 
    public GameObject textoC; 
    public GameObject textoCl;
    public GameObject textoNA;
    public GameObject textoO;  
    public GameObject textoO2; 
    private bool infoAct;

    //Scripts moleculas
    private CreacionNaCl NaCl;
    private  CreacionCO2 co2; 
    private CreacionCO co ;
    private  CreacionH2O h2o ;
    private  CreacionCH4 CH4;
    private CreacionNH3 NH3 ;



    
    // Start is called before the first frame update
    void Start()
    {
             textoN.SetActive(false);
           textoH1.SetActive(false);
            textoH2.SetActive(false);
            textoH3.SetActive(false); 
             textoH4.SetActive(false); 
            textoC.SetActive(false); 
            textoCl.SetActive(false);
            textoNA.SetActive(false);
            textoO.SetActive(false);  
             textoO2.SetActive(false); 
             infoAct = false;

            //Scripts moleculas
             co2 = GetComponent<CreacionCO2>();
             co = GetComponent<CreacionCO>();
             h2o = GetComponent<CreacionH2O>();
             NaCl = GetComponent<CreacionNaCl>();
             CH4 = GetComponent<CreacionCH4>();
             NH3 = GetComponent<CreacionNH3>();
     
    }

    // Update is called once per frame
    void Update()
    {

     if (Input.GetKeyDown(KeyCode.I))
        {
             if (!infoAct) activarTextos();
            else desactivarTextos();

        }

        if(infoAct) comprobarMoleculas();
    }
    public void activarTextos(){
       textoN.SetActive(true);
           textoH1.SetActive(true);
            textoH2.SetActive(true);
            textoH3.SetActive(true); 
             textoH4.SetActive(true); 
            textoC.SetActive(true); 
            textoCl.SetActive(true);
            textoNA.SetActive(true);
            textoO.SetActive(true);  
             textoO2.SetActive(true); 
        
        infoAct = true;
    }
    public void desactivarTextos(){
          textoN.SetActive(false);
           textoH1.SetActive(false);
            textoH2.SetActive(false);
            textoH3.SetActive(false); 
             textoH4.SetActive(false); 
            textoC.SetActive(false); 
            textoCl.SetActive(false);
            textoNA.SetActive(false);
            textoO.SetActive(false);  
             textoO2.SetActive(false); 

         
            infoAct = false;
    }

    public void comprobarMoleculas(){         //---------------------------
       // Comprobar NaCl
        if(NaCl.creado){
            textoNA.SetActive(false);
            textoCl.SetActive(false);
        }
        else{
            textoNA.SetActive(true);
            textoCl.SetActive(true);    
        }

         // Comprobar H2O
         if(h2o.creado){
            textoO.SetActive(false);
            textoH1.SetActive(false);
            textoH2.SetActive(false);
        }
        else if(){
            
            textoO.SetActive(true);
            textoH1.SetActive(true);
            textoH2.SetActive(true);    
        }
         //Comprobar CO
        if(co.creado){
            textoC.SetActive(false);
            textoO.SetActive(false);
        }
        else{
            textoC.SetActive(true);
            textoO.SetActive(true);    
        }

         //Comprobar CO2
         if(co2.creado){
            textoC.SetActive(false);
            textoO2.SetActive(false);
            textoO.SetActive(false);
        }
        else{
            textoC.SetActive(true);
            textoO2.SetActive(true);
            textoO.SetActive(true);    
        }

         //Comprobar NH3
         if(NH3.creado){
            textoH1.SetActive(false);
            textoH2.SetActive(false);
            textoH3.SetActive(false);           
            textoN.SetActive(false);
        }
        else{
            textoH1.SetActive(true);
            textoH2.SetActive(true);
            textoH3.SetActive(true);
            textoN.SetActive(true);    
        }
         //Comprobar CH4
         if(CH4.creado){
            textoH1.SetActive(false);
            textoH2.SetActive(false);
            textoH3.SetActive(false); 
            textoH4.SetActive(false);           
            textoC.SetActive(false);
        }
        else{
            textoH1.SetActive(true);
            textoH2.SetActive(true);
            textoH3.SetActive(true);
            textoH4.SetActive(true);           
            textoC.SetActive(true);    
        }
    }
}