﻿using UnityEngine;
using System.Collections;

public class collision : MonoBehaviour
{
    private GameObject gamescript = null;

    public GameObject pts_show;
    public Transform positionPts;
    public float vitesse = 1f;
    public float duration = 1f;
    public float taille = 1;

    private int pts = 0;

    void Start()
    {
        gamescript = GameObject.Find("game");
        pts = 0;
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("coucou");
        if (gamescript != null)
        {
            if (other.gameObject.name == "voiture")
            {
                gamescript.SendMessage("AddPoint", 100);
                pts = 100;
            }
        }
    }

    //filtre des points de collsion
    void OnParticleCollision(GameObject other)
    {
        if (gamescript != null)
        {
            switch (other.name)
            {

                case "mur1":
                    gamescript.SendMessage("AddPoint", 50);
                    pts = -50;
                    break;

                case "mur2":
                    gamescript.SendMessage("AddPoint", 50);
                    pts = -50;
                    break;

                case "mur":
                    gamescript.SendMessage("AddPoint", 50);
                    pts = -50;
                    break;

                case "papier":
                    gamescript.SendMessage("AddPoint", 50);
                    pts = +30;
                    break;

                case "lavabo":
                    gamescript.SendMessage("AddPoint", 50);
                    pts = 50;
                    break;

                case "poster":
                    gamescript.SendMessage("AddPoint", 50);
                    pts = +30;
                    break;

                case "savon":
                    gamescript.SendMessage("AddPoint", 50);
                    pts = +40;
                    break;

                case "electricBox":
                    gamescript.SendMessage("AddPoint", 50);
                    pts = -150;
                    break;

                case "sol":
                    gamescript.SendMessage("AddPoint", 50);
                    pts = -50;
                    break;


                case "TROU":
                    gamescript.SendMessage("AddPoint", 50);
                    pts = 50;
                    break;

                case "PLAT":
                    gamescript.SendMessage("AddPoint", -5);
                    pts = -5;
                    break;

                case "ARMATURE":
                    gamescript.SendMessage("AddPoint", 10);
                    pts = 1;
                    break;

                case "CUVE":
                    gamescript.SendMessage("AddPoint", 25);
                    break;

                case "CUVE1":
                    gamescript.SendMessage("AddPoint", 20);
                    pts = 20;
                    break;

                case "CUVETTE":
                    gamescript.SendMessage("AddPoint", 10);
                    pts = 10;
                    break;

                case "CUVE_EAU":
                    gamescript.SendMessage("AddPoint", 5);
                    pts = 5;
                    break;

                case "BONUS":
                    gamescript.SendMessage("AddPoint", 25);
                    pts = 25;
                    break;

                case "CIBLE":
                    gamescript.SendMessage("AddPoint", 25);
                    pts = 25;
                    break;

                case "AUTRE":
                    gamescript.SendMessage("AddPoint", -1);
                    pts = -1;
                    break;

                case "MALUS":
                    gamescript.SendMessage("AddPoint", -10);
                    pts = -10;
                    break;

                case "Route":
                    gamescript.SendMessage("AddPoint", -1);
                    pts = 1;
                    break;

                case "trottoir":
                    gamescript.SendMessage("AddPoint", 1);
                    pts = 1;
                    break;

                case "voiture":
                    Debug.Log("voiture");
                    gamescript.SendMessage("AddPoint", 40);
                    pts = 40;
                    break;


                case "Personnage":
                    gamescript.SendMessage("AddPoint", 50);
                    pts = 50;
                    break;

                default:
                    gamescript.SendMessage("AddPoint", 20);
                    pts = 20;
                    break;

            }

            Transform pos;
            if (positionPts != null)
                pos = positionPts;
            else
                pos = other.GetComponent<Collider>().transform;

            GameObject obj = Instantiate(pts_show,pos.position, other.GetComponent<Collider>().transform.rotation) as GameObject;

            if (obj != null)
            {
                string[] param = new string[4];
                param[0] = pts.ToString();
                param[1] = vitesse.ToString();
                param[2] = duration.ToString();
                param[3] = taille.ToString();

                obj.SendMessage("setup", param);
            }
        }
    }
}
