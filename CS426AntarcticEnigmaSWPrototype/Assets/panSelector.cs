using System.Collections.Generic; using UnityEngine; using Random = System.Random;  public class panSelector : MonoBehaviour {     public Material highlightMat;     public Material normalMat;     public int highlighted;     public GameObject pan1, pan2, pan3;     public ParticleSystem smoke, lightt, burning, lighttt, lightttt, burningg, burninggg;     public GameObject[] MyObjects;     public ParticleSystem[] parT2;     public ParticleSystem[] parT3;     public ParticleSystem[] particalSys;     Dictionary<GameObject, ParticleSystem[]> dict = new Dictionary<GameObject, ParticleSystem[]>();      public SmokeAudio sA;     public OrangeAudio oA;     public OrangeHelperAudio ohA;     public LightFireAudio lfA;      public WinSound wS;     public LoseSound lS;      public int onGreen;      bool secondOn = false;      public SimpleMovement s;      public int counter;     int Stat;     public int totalT;       // Start is called before the first frame update     void Start()     {         MyObjects = new GameObject[4];         MyObjects[1] = pan1;         MyObjects[2] = pan2;         MyObjects[3] = pan3;          GameObject s = MyObjects[2];         s.GetComponentInChildren<Renderer>().material = highlightMat;         highlighted = 2;           particalSys = new ParticleSystem[4];         //particalSys[1] = smoke;         particalSys[2] = lightt;         particalSys[3] = burning;         dict.Add(pan1, particalSys);          parT2 = new ParticleSystem[4];         parT2[2] = lighttt;         parT2[3] = burningg;         dict.Add(pan2, parT2);          parT3 = new ParticleSystem[4];         parT3[2] = lightttt;         parT3[3] = burninggg;         dict.Add(pan3, parT3);          onGreen = 0;          ParticleSystem[] part = dict[MyObjects[2]];         part[2].Play();

        counter = 0;         Stat = 1;         totalT = 0;        }      // Update is called once per frame     void Update()     {         if(s.inK == 1 && Stat == 1)
        {
                     sA.audioSource.loop = true;             lfA.audioSource.loop = true;

            lfA.audioSource.Play();
            sA.audioSource.Play();
            oA.audioSource.Play();             Stat = 0; 
        }          if(s.inK == 0)
        {
            sA.audioSource.loop = false;             lfA.audioSource.loop = false;             sA.audioSource.Stop();             oA.audioSource.Stop();             lfA.audioSource.Stop();             Stat = 1;         }           if (s.counter == 3)
        {
            //wS.audioSource.Play(); 
            s.kDone = true;             //s.counter = 0;             Stat = 1;             totalT = 0;
        }          if(s.chances == 10)
        {
            sA.audioSource.loop = false;             lfA.audioSource.loop = false;             sA.audioSource.Stop();             oA.audioSource.Stop();             lfA.audioSource.Stop();

            ohA.audioSource.loop = false;
            ohA.audioSource.Stop();
        } 
        if (Input.GetKeyDown(KeyCode.D))         {             if((highlighted - 1) == 0)             {                 highlighted = 3;                 GameObject o = MyObjects[1];                 o.GetComponentInChildren<Renderer>().material = normalMat;                  GameObject p = MyObjects[highlighted];                 p.GetComponentInChildren<Renderer>().material = highlightMat;             }             else             {                 GameObject o = MyObjects[highlighted];                 o.GetComponentInChildren<Renderer>().material = normalMat;                  highlighted -= 1;                 GameObject p = MyObjects[highlighted];                 p.GetComponentInChildren<Renderer>().material = highlightMat;              }           }         else if (Input.GetKeyDown(KeyCode.A))         {             if ((highlighted + 1) == 4)             {                 highlighted = 1;                 GameObject o = MyObjects[3];                 o.GetComponentInChildren<Renderer>().material = normalMat;                  GameObject p = MyObjects[highlighted];                 p.GetComponentInChildren<Renderer>().material = highlightMat;             }             else             {                 GameObject o = MyObjects[highlighted];                 o.GetComponentInChildren<Renderer>().material = normalMat;                  highlighted += 1;                 GameObject p = MyObjects[highlighted];                 p.GetComponentInChildren<Renderer>().material = highlightMat;              }          }          ParticleSystem[] checkIfON = dict[MyObjects[highlighted]];         if (s.onGreen == 1 &&  (checkIfON[2].isPlaying || checkIfON[3].isPlaying))
        {
            ParticleSystem[] part = dict[MyObjects[highlighted]];             if(secondOn)
            {
                part[3].Stop();                 secondOn = false;                 ohA.audioSource.loop = false;                 ohA.audioSource.Stop();
            }             else
            {
                part[2].Stop();                  if (s.counter < 4)
                {
                    System.Random random = new Random();
                    int randomNumber = random.Next(1, 4);

                    ParticleSystem[] partT = dict[MyObjects[randomNumber]];

                    partT[2].Play();
                }                  s.counter += 1;
            }
                     s.onGreen = 0;
        }          if(s.chances > 4 && s.chances < 6 && checkIfON[2].isPlaying)
        {            ParticleSystem[] part = dict[MyObjects[highlighted]];            part[3].Play();            secondOn = true;            ohA.audioSource.loop = true;            ohA.audioSource.Play();

        }


        if (Input.GetKeyDown(KeyCode.O) )         {             for (int i = 1; i < 4; i++)             {                 ParticleSystem[] part = dict[MyObjects[i]];                  //part[1].Stop();                 part[2].Stop();                 part[3].Stop();                  sA.audioSource.loop = false;                 lfA.audioSource.loop = false;                 ohA.audioSource.loop = false;                  sA.audioSource.Stop();                 oA.audioSource.Stop();                 lfA.audioSource.Stop();                 ohA.audioSource.Stop();               }          }         else if(Input.GetKeyDown(KeyCode.P))         {             for (int i = 1; i < 4; i++)             {                 ParticleSystem[] part = dict[MyObjects[i]];                  //part[1].Play();                 part[2].Play();                 part[3].Play();

                sA.audioSource.loop = true;                 lfA.audioSource.loop = true;                 ohA.audioSource.loop = true;                  lfA.audioSource.Play();                 sA.audioSource.Play();                 oA.audioSource.Play();                  ohA.audioSource.Play();                 }         }      } } 
