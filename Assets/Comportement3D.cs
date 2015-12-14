using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]

    public class Comportement3D : MonoBehaviour
    {


        public NavMeshAgent agent { get; private set; }
        public ThirdPersonCharacter character { get; private set; }
        public SkinnedMeshRenderer body { get; private set; }
        private double remainingDist;
        //public string testcouleur;
        //public string testactionperso;
        private Game game;
        public Personnalite personnalite;
        Transform emplacementbar;
        Transform emplacementmirror;
        Transform emplacementpiste;
        Transform emplacementtable;
        GameObject[] tables;

        // Use this for initialization
        void Start()
        {
            

            agent = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();                                  
            body = GetComponentInChildren<SkinnedMeshRenderer>();

            GameObject bar = GameObject.Find("Bar");
            emplacementbar = bar.transform;

            GameObject mirror = GameObject.Find("Mirror1");
            emplacementmirror = mirror.transform;

            GameObject dancefloor = GameObject.Find("Dancefloor");
            emplacementpiste = dancefloor.transform;

            
            tables = new GameObject[8];
            
            GameObject table1 = GameObject.Find("Sofa1");
            GameObject table2 = GameObject.Find("Sofa2");
            GameObject table3 = GameObject.Find("Sofa3");
            GameObject table4 = GameObject.Find("Sofa4");
            GameObject table5 = GameObject.Find("Sofa5");
            GameObject table6 = GameObject.Find("Sofa6");
            GameObject table7 = GameObject.Find("Sofa7");
            GameObject table8 = GameObject.Find("Sofa8");

            tables[0] = table1;
            tables[1] = table2;
            tables[2] = table3;
            tables[3] = table4;
            tables[4] = table5;
            tables[5] = table6;
            tables[6] = table7;
            tables[7] = table8;


            //emplacementtable = table.transform;

            

        }


        // Update is called once per frame	

        private void Update()
        {
            
            switch (personnalite.personnaliteDominante)
            {
                    
                case "buveur":
                    body.material.color = Color.blue;                    
                    break;
                case "danseur":
                    body.material.color = Color.green;
                    break;
                case "dragueur":
                    body.material.color = Color.red;
                    break;
                case "neutre":
                    body.material.color = Color.yellow;
                    break;

            }

            
            switch (personnalite.etatCourant)
            {
                case "boire":
                    Move(emplacementbar);
                    break;
                case "danser":
                    Move(emplacementpiste);
                    break;
                case "parler":
                    System.Random rd = new System.Random();
                    int choix = rd.Next(tables.Length);
                    emplacementtable = tables[choix].transform;
                    Move(emplacementtable);
                    break;
                case "goTable":
                    Move(emplacementtable);
                    break;
                case "goToilette":
                    Move(emplacementmirror);
                    break;

            }
        }

        private void Move(Transform target)
        {
            
            remainingDist = agent.remainingDistance;
            if ((remainingDist >= 0.2) && (remainingDist <= 0.3))
            {
                //if distance de la target < seuil stop
                agent.stoppingDistance = (float)remainingDist;
                character.Move(Vector3.zero, false, false);
                //agent.Stop();
            }
            else if (target != null)
            {
                agent.SetDestination(target.position);

                // use the values to move the character
                character.Move(agent.desiredVelocity, false, false);

            }
            else
            {
                // We still need to call the character's move function, but we send zeroed input as the move param.
                character.Move(Vector3.zero, false, false);
            }

        }
    }
}


