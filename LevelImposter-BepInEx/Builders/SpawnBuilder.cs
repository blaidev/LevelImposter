﻿using HarmonyLib;
using LevelImposter.DB;
using LevelImposter.Map;
using LevelImposter.Models;
using PowerTools;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace LevelImposter.Builders
{
    class SpawnBuilder : Builder
    {
        private PolusHandler polus;

        public SpawnBuilder(PolusHandler polus)
        {
            this.polus = polus;
        }

        public bool Build(MapAsset asset)
        {
            Vector2 pos = new Vector2(asset.x, -asset.y);
            if (asset.type == "util-spawn1")
            {
                polus.shipStatus.InitialSpawnCenter = pos;
            }
            else if (asset.type == "util-spawn2")
            {
                polus.shipStatus.MeetingSpawnCenter = pos;
                polus.shipStatus.MeetingSpawnCenter2 = pos;
            }
            else
            {
                LILogger.LogError("Unknown Spawn Type '" + asset.type + "'");
                return false;
            }

            return true;
        }
    }
}
