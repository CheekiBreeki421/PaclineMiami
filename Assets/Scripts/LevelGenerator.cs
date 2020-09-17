using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    int[,] levelMap = {
        { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 7 },
        { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 4 },
        { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 4 },
        { 2, 6, 4, 0, 0, 4, 5, 4, 0, 0, 0, 4, 5, 4 },
        { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 3 },
        { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 },
        { 2, 5, 3, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 4 },
        { 2, 5, 3, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 3 },
        { 2, 5, 5, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 4 },
        { 1, 2, 2, 2, 2, 1, 5, 4, 3, 4, 4, 3, 0, 4 },
        { 0, 0, 0, 0, 0, 2, 5, 4, 3, 4, 4, 3, 0, 3 },
        { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 3, 4, 4, 0 },
        { 2, 2, 2, 2, 2, 1, 5, 3, 3, 0, 4, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 4, 0, 0, 0 }, };
    public GameObject nothing;
    public GameObject outCorner;
    public GameObject outWall;
    public GameObject inCorner;
    public GameObject inWall;
    public GameObject smallPellet;
    public GameObject bigPellet;
    public GameObject tPose;
    bool toggleCorner = false;
    public bool xPositive;
    public bool yPositive;
    public bool mirrorX;
    public bool mirrorY;


    void SectionSettings()
    {
        switch (xPositive)
        {
            case true:
                switch (yPositive)
                {
                    case true:
                        transform.position = new Vector2(15, 15);
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case false:
                        transform.position = new Vector2(15, 1);
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                }
                break;
            case false:
                switch (yPositive)
                {
                    case true:
                        transform.position = new Vector2(2, 15);
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case false:
                        transform.position = new Vector2(2, 1);
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                }
                break;

        }

    }

    void ConstructSectorNoMirror()
    {
        float initPos = transform.position.x;

        for (int i = 0; i < levelMap.Length; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                switch (levelMap[i, j])
                {
                    case 0:
                        Instantiate(nothing);
                        break;
                    case 1:
                        switch (toggleCorner)
                        {
                            case true:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z);
                                toggleCorner = false;
                                break;
                            case false:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + 90);
                                toggleCorner = true;
                                break;
                        }
                        Instantiate(outCorner, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        break;
                    case 2:
                        Instantiate(outWall, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        break;
                    case 3:

                        switch (toggleCorner)
                        {
                            case true:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z);
                                toggleCorner = false;
                                break;
                            case false:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + 90);
                                toggleCorner = true;
                                break;
                        }
                        Instantiate(inCorner, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        break;
                    case 4:
                        Instantiate(inWall, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        break;
                    case 5:
                        Instantiate(smallPellet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        break;
                    case 6:
                        Instantiate(bigPellet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        break;
                    //case 7:
                       // Instantiate(tPose, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                       // switch (toggleCorner)
                       // {
                         //   case true:
                        //        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z - 90);
                       //         toggleCorner = false;
                        //        break;
                       //     case false:
                       //         transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + 90);
                       //         toggleCorner = true;
                       //         break;
                       // }
                        //break;
                }
                transform.position = new Vector2(transform.position.x - 1, transform.position.y);
            }
            transform.position = new Vector2(initPos, transform.position.y - 1);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            toggleCorner = false;
        }


    }

    void ConstructSectorMirrorX()
    {
        float initPos = transform.position.x;

        for (int i = 0; i < levelMap.Length; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                switch (levelMap[i, 13 - j])
                {
                    case 0:
                        Instantiate(nothing);
                        break;
                    case 1:
                        Instantiate(outCorner, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        switch (toggleCorner)
                        {
                            case true:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z - 90);
                                toggleCorner = false;
                                break;
                            case false:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + 90);
                                toggleCorner = true;
                                break;
                        }
                        break;
                    case 2:
                        Instantiate(outWall, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        break;
                    case 3:
                        Instantiate(inCorner, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        switch (toggleCorner)
                        {
                            case true:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z - 90);
                                toggleCorner = false;
                                break;
                            case false:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + 90);
                                toggleCorner = true;
                                break;
                        }
                        break;
                    case 4:
                        Instantiate(inWall, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        break;
                    case 5:
                        Instantiate(smallPellet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        break;
                    case 6:
                        Instantiate(bigPellet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        break;
                    case 7:
                        Instantiate(tPose, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        switch (toggleCorner)
                        {
                            case true:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z - 90);
                                toggleCorner = false;
                                break;
                            case false:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + 90);
                                toggleCorner = true;
                                break;
                        }
                        break;
                }
                transform.position = new Vector2(transform.position.x - 1, transform.position.y);
            }
            transform.position = new Vector2(initPos, transform.position.y - 1);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            toggleCorner = false;
        }


    }

    void ConstructSectorMirrorY()
    {
        float initPos = transform.position.x;

        for (int i = 0; i < levelMap.Length; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                switch (levelMap[14 - i, j])
                {
                    case 0:
                        Instantiate(nothing);
                        break;
                    case 1:
                        Instantiate(outCorner, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        switch (toggleCorner)
                        {
                            case true:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z - 90);
                                toggleCorner = false;
                                break;
                            case false:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + 90);
                                toggleCorner = true;
                                break;
                        }
                        break;
                    case 2:
                        Instantiate(outWall, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        break;
                    case 3:
                        Instantiate(inCorner, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        switch (toggleCorner)
                        {
                            case true:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z - 90);
                                toggleCorner = false;
                                break;
                            case false:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + 90);
                                toggleCorner = true;
                                break;
                        }
                        break;
                    case 4:
                        Instantiate(inWall, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        break;
                    case 5:
                        Instantiate(smallPellet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        break;
                    case 6:
                        Instantiate(bigPellet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        break;
                    case 7:
                        Instantiate(tPose, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        switch (toggleCorner)
                        {
                            case true:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z - 90);
                                toggleCorner = false;
                                break;
                            case false:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + 90);
                                toggleCorner = true;
                                break;
                        }
                        break;
                }
                transform.position = new Vector2(transform.position.x - 1, transform.position.y);
            }
            transform.position = new Vector2(initPos, transform.position.y - 1);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            toggleCorner = false;
        }


    }

    void ConstructSectorMirrorXY()
    {
        float initPos = transform.position.x;

        for (int i = 0; i < levelMap.Length; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                switch (levelMap[14 - i, 13 - j])
                {
                    case 0:
                        Instantiate(nothing);
                        break;
                    case 1:
                        Instantiate(outCorner, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        switch (toggleCorner)
                        {
                            case true:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z - 90);
                                toggleCorner = false;
                                break;
                            case false:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + 90);
                                toggleCorner = true;
                                break;
                        }
                        break;
                    case 2:
                        Instantiate(outWall, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        break;
                    case 3:
                        Instantiate(inCorner, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        switch (toggleCorner)
                        {
                            case true:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z - 90);
                                toggleCorner = false;
                                break;
                            case false:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + 90);
                                toggleCorner = true;
                                break;
                        }
                        break;
                    case 4:
                        Instantiate(inWall, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        break;
                    case 5:
                        Instantiate(smallPellet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        break;
                    case 6:
                        Instantiate(bigPellet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        break;
                    case 7:
                        Instantiate(tPose, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        switch (toggleCorner)
                        {
                            case true:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z - 90);
                                toggleCorner = false;
                                break;
                            case false:
                                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + 90);
                                toggleCorner = true;
                                break;
                        }
                        break;
                }
                transform.position = new Vector2(transform.position.x - 1, transform.position.y);
            }
            transform.position = new Vector2(initPos, transform.position.y - 1);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            toggleCorner = false;
        }


    }

    void Awake()
    {
        SectionSettings();
        switch (mirrorX)
        {
            case true:
                switch (mirrorY)
                {
                    case true:
                        ConstructSectorMirrorXY();
                        break;
                    case false:
                        ConstructSectorMirrorX();
                        break;
                }
                break;
            case false:
                switch (mirrorY)
                {
                    case true:
                        ConstructSectorMirrorY();
                        break;
                    case false:
                        ConstructSectorNoMirror();
                        break;
                }
                break;
        }
    }
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
}
