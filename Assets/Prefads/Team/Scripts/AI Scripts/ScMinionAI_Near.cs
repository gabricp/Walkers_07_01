using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////
/// ///////////  ARTIFICIAL INTELLIGENCE  MINION Script 
/// Author : 	Miguel Angel Fernandez Graciani
/// Date :	2021-02-07
/// Observations :
///     - THIS IS AN ARTIFICIAL INTELLIGENT SCRIPT
///     - You must call to the "public void moveOn(Vector3 directionForce, float movUnits)" in "ScMinionControl" to move the minion
///     - You must Change it to define the artiicial intelligence of this minion
/// </summary>
public class ScMinionAI_Near : MonoBehaviour {

    public GameObject Game;  // To access to the general object "Game"

    protected DateTime date_lastChamge;  // 
    protected double periodMilisec;

    protected Vector3 movement;  // Direction of the force that will be exerted on the gameobject
    protected float minionsMovUnits;  //  Amount of force that will be exerted on the gameobject

    public List<gameElement> Teammates_list;
    public List<gameElement> opponents_list;


    // Use this for initialization
    /// <summary>
    /// ///////////  ARTIFICIAL INTELLIGENCE  MINION Script 
    /// Author : 	
    /// Date :	
    /// Observations :
    /// </summary>
    void Start()
    {

        // We access to the general object "Game"
        Game = GameObject.FindWithTag("Game");
        date_lastChamge = DateTime.Now; // We initialize the date value
        periodMilisec = 1000f;  // We change each "periodoMiliseg"/1000 seconds

        movement = new Vector3(0.0f, 0.0f, 0.0f); // We initialize the date value
        minionsMovUnits = 1f; // We initialize the date value

        // if we are team near: (if you are not, comment these two lines)
        Teammates_list = Game.GetComponent<ScGameGlobalData>().listTeam_Far;
        opponents_list = Game.GetComponent<ScGameGlobalData>().listTeam_Near;

        // if we are team far: (if you are not, comment these two lines)
//        Teammates_list = Game.GetComponent<ScGameGlobalData>().listTeam_Far;
//        opponents_list = Game.GetComponent<ScGameGlobalData>().listTeam_Near;

    }  // FIn de - void Start()

    // Update is called once per frame
    /// <summary>
    /// ///////////  ARTIFICIAL INTELLIGENCE  MINION Script 
    /// Author : 	
    /// Date :	
    /// Observations :
    /// </summary>
    void Update()
    {

        // You can access to the information of all elements in the game using sentences lake the following
        /*
        foreach (gameElement element_mate in Teammates_list)
        {
            Vector3 posicion = element_mate.giveToMePosition();
            Debug.Log("vector x :" + posicion.x.ToString());
            Debug.Log("In Teammates : " +
                " - element_mate - label : " + element_mate.giveToMeTag() +
                " - element_mate - id : " + element_mate.giveToMeId() +
                " - element_mate - Team : " + element_mate.giveToMeTeam() +
                " - element_mate position x : " + posicion.x +
                " - element_mate position z : " + posicion.z +
                " - element_mate position y : " + posicion.y);
        }  // Fin de - foreach (gameElement element_mate in Teammates_list)

        foreach (gameElement element_opponent in opponents_list)
        {
            Vector3 posicion = element_opponent.giveToMePosition();
            Debug.Log("vector x :" + posicion.x.ToString());
            Debug.Log("In team Far : " +
                " - element_opponent - label : " + element_opponent.giveToMeTag() +
                " - element_opponent - id : " + element_opponent.giveToMeId() +
                " - element_opponent - Team : " + element_opponent.giveToMeTeam() +
                " - element_opponent posicion x : " + posicion.x +
                " - element_opponent posicion z : " + posicion.z +
                " - element_opponent posicion y : " + posicion.y);
        }  // Fin de - foreach (gameElement element_mate in Teammates_list)

        foreach (gameElement elementProfit in Game.GetComponent<ScGameGlobalData>().listProfits)
        {
            Vector3 posicion = elementProfit.giveToMePosition();
            Debug.Log("vector x :" + posicion.x.ToString());
            Debug.Log("In profits : " +
                " - element profit - label : " + elementProfit.giveToMeTag() +
                " - element profit - id : " + elementProfit.giveToMeId() +
                " - element profit - Team : " + elementProfit.giveToMeTeam() +
                " - element profit posicion x : " + posicion.x +
                " - element profit posicion z : " + posicion.z +
                " - element profit posicion y : " + posicion.y);
        }  // Fin de - foreach (gameElement element_mate in Teammates_list)
        */
    }  // FIn de - void Update()

    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////
    /// ///////////  FixedUpdate()
    /// Author : 	Miguel Angel Fernandez Graciani
    /// Date :	2021-02-07
    /// Observations :
    ///     - THIS IS AN ARTIFICIAL INTELLIGENT SCRIPT
    ///     - You must Change it to define the artiicial intelligence of this player
    ///     - This one is only an example to manage the player
    /// </summary>
    void FixedUpdate()
    {
        // Every "timeWhitoutChange_ms" milliseconds we modify the value of "movement" and "minionsMovUnits"
        DateTime dateNow = DateTime.Now; 
        TimeSpan timeWhitoutChange = dateNow - date_lastChamge;
        float move_x = 0.0f; //Definimos a cero el movimiento para evitar que de problemas
        float move_z = 0.0f;

        double timeWhitoutChange_ms = timeWhitoutChange.TotalMilliseconds;
        if (timeWhitoutChange_ms > periodMilisec)
        {
            foreach (gameElement element_oponent in opponents_list)
            {
                if (element_oponent.giveToMeTag() == "Player")
                {
                    Vector3 posicion = element_oponent.giveToMePosition();
                    move_x = posicion.x - transform.position.x;
                    move_z = posicion.z - transform.position.z;
                }
            }
            // We calculate the direction and quantity of movement
            // We obtain "movement" and "minionsMovUnits" randonly
            float move_X = Random.Range(-1.0f, 1f);
            float move_Z = Random.Range(-1f, 1f);
            float minionsMovUnits = Random.Range(0.0f, 1f);

            minionsMovUnits = minionsMovUnits * ScGameGlobalData.maxMinionsMovUnits;
            movement = new Vector3(move_x, 0.0f, move_z);

            date_lastChamge = dateNow;  // We actualizate date_lastChamge
        }

        // CALLING TO THIS FUNCTION YOU CAN MANAGE THE ELEMENT WITH THE ARTIFICIAL INTELLIGENCE THAT YOU MUST DEVELOP
        GetComponent<ScMinionControl>().moveOn(movement, minionsMovUnits);
    }  // Fin de - void FixedUpdate()

}  // Fin de - public class ScMinionAI_Near : MonoBehaviour {
