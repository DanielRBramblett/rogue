﻿//Copyright(c) 2018 Daniel Bramblett, Daniel Dupriest, Brandon Goldbeck

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecs;
using Game.Interfaces;
using IO;

namespace Game.Components
{
    class GameManager : Component
    {
        private const float hudWidth = .333f;
        public int gameWidth;
        public int gameHeight;

        public GameManager(int width, int height)
        {
            this.gameWidth = width;
            this.gameHeight = height;

        }

        public override void Start()
        {
            GameObject mapObject = GameObject.Instantiate("Map");
            Map map = new Map((int)(gameWidth * (1 - hudWidth)), gameHeight);
            mapObject.AddComponent(map);
            mapObject.transform.position.y = gameHeight - 1;

            GameObject player = GameObject.Instantiate("Player");
            player.AddComponent(new Player());
            player.AddComponent(new PlayerController());
            player.AddComponent(new Model());
            player.AddComponent(new Collider());
            player.transform.position.x = map.startingX;
            player.transform.position.y = map.startingY;

            Model playerModel = (Model)player.GetComponent(typeof(Model));
            playerModel.model.Add("$");
            playerModel.colorModel.Add(new List<String>());
            playerModel.colorModel[0].Add("\u001b[31m");

            // Setup HUD for stats and info
            GameObject hud = GameObject.Instantiate("HUD");
            hud.AddComponent(new HUD((int)(gameWidth * hudWidth), gameHeight));
            hud.AddComponent(new Model());
            hud.transform.position.x = gameWidth - (int)(gameWidth * hudWidth);
            hud.transform.position.y = gameHeight - 1;

            Debug.Log("GameManager added all components on start.");
            return;
        }

        public override void Update()
        {
            return;
        }

        public override void LateUpdate()
        {
            return;
        }

        public override void Render()
        {
            return;
        }
    }
}
