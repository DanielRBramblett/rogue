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
    class Enemy : Actor, IDamageable, IMovable
    {
        public Transform target = null;
        
        public Enemy():base()
        {
            
        }

        public Enemy(string name, string description, int level, int hp, int armor, int attack)
            :base(name, description, level, hp, armor, attack)
        {
        }

        public override void Start()
        {
            base.Start();
            return;
        }

        /// <summary>
        /// The update method handles the movement of the enemy.
        /// </summary>
        public override void Update()
        {
            base.Update();

            /*If enough time has passed since the enemy has moved, it checks if the enemy can
              see the player. If the enemy can see the player, it moves towards the play. Otherwise,
              it makes a random move.*/
            Aggro search = (Aggro)GetComponent<Aggro>();
            EnemyAI ai = (EnemyAI)GetComponent<EnemyAI>();
            if(search == null)
            {
                Debug.LogError("Enemy didn't have an Aggro component.");
                return;
            }
            if (ai == null)
            {
                Debug.LogError("Enemy didn't have an Enemy AI component.");
                return;
            }

            search.TargetSearch();
            ai.MakeMove();

            return;
        }

        public override void Render()
        {
            return;
        }

        public void ApplyDamage(GameObject source, int damage)
        {
            // We don't want enemies attacking other enemies.
            if (source == null || source.GetComponent<Enemy>() != null) { return; }

            this.hp -= damage;
            // Made it a little easier to add stuff to the log from anywhere in
            // the game.
            HUD.Append("Attacked a " + Name + " for " + damage + " damage.");
            if (hp <= 0)
            {
                // Notify other components on this game object of my death.
                // Why? maybe in the future we will play a sound on death, who knows?
                List<IDamageable> damageables = gameObject.GetComponents<IDamageable>();
                foreach (IDamageable damageable in damageables)
                {
                    damageable.OnDeath(source);
                }
            }
            return;
        }

        public void OnDeath(GameObject source)
        {
            // Killer gains exp n stuff for killing, right?
            
            HUD.Append(source.Name + " killed " + Name);
            
            // We need to remove this enemy for the map too, right?
            Map.CacheInstance().PopObject(transform.position.x, transform.position.y);

            // Transfer inventory items from killed actor
            Inventory killedInventory = (Inventory)gameObject.GetComponent<Inventory>();
            killedInventory.MergeWith((Inventory)source.GetComponent<Inventory>());

            GameObject.Destroy(this.gameObject);

            return;
        }

        public new void Move(int dx, int dy)
        {
            base.Move(dx, dy);
            return;
        }

        protected override int CalculateDamage()
        {
            int damage = 1 * this.attack;
            // TODO: Get our damage, based on level of player,
            // The player's attack power, any equipment bonuses, Etc..
            return damage;
        }

    }
}
