﻿using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

namespace Menchestan
{
    namespace GamePlay
    {
        namespace Board
        {
            public class MBoard : MonoBehaviour
            {
                public Vector3 dice2DPosition;
                public Vector3 dice3DPosition;
                public Slider timeBar;
                public Image fillBar;
                public PiecePoint[] fastPieces;
                public List<StartPoint> startPoints = new List<StartPoint>();
                public List<WayPoint> wayPoints = new List<WayPoint>();
                public void Init(bool isFast)
                {
                 if (isFast)
                    {
                        foreach (var point in fastPieces)
                        {

                            point.gameObject.SetActive(true);
                        }
                    }
                    startPoints = gameObject.GetComponentsInChildren<StartPoint>().ToList();
                    wayPoints = gameObject.GetComponentsInChildren<WayPoint>().ToList();
                    foreach (var point in startPoints)
                    {
                        point.Init();
                    }
                    foreach (var point in wayPoints)
                    {
                        point.Init();
                    }
                }
            }
        }
    }
}