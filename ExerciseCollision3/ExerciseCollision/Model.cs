using System;
using System.Collections.Generic;
using Zenseless.Geometry;

namespace Example
{
    public class Model
    {
        //create an iterator for the asteroids list
        public List<Asteroid> asteroidsList;
        public Player player;
        public List<Bullet> bullets;

        //status player
        public float invincibleTime = 2f;
        private float invincibleTimer = 0f;

        //status shooting
        public float shootIntervall = 0.1f;
        private float shootIntervallTimer;

        public Model()
        {
            asteroidsList = new List<Asteroid>();
            for(int i = 0; i<= 4; i++)
            {
                asteroidsList.Add(new Asteroid(4));
            }
            player = new Player();
            bullets = new List<Bullet>();

        }

        public void Update(float movementXaxis, float movementYaxis, bool isShooting, float updatePeriod)
        {
            //player logic
            
            //player movement
            player.shape.CenterX += movementXaxis * updatePeriod;
            player.shape.CenterY += movementYaxis * updatePeriod;

            // player Y Axis Boundaries
            if (player.shape.CenterY <= -0.9f)
            {
                player.shape.CenterY = -0.9f;
            }
            if (player.shape.CenterY >= 0.95f)
            {
                player.shape.CenterY = 0.95f;
            }

            // player X Axis Teleport
            if (player.shape.CenterX <= -1f)
            {
                player.shape.CenterX = 0.9f;
            }
            if (player.shape.CenterX >= 1f)
            {
                player.shape.CenterX = -0.9f;
            }

            //check ob invincible zurückgesetzt wetrden muss
            if (invincibleTimer > invincibleTime)
                player.isInvincible = false;

            //immer machen
            invincibleTimer += updatePeriod;

            //player can shoot
            shootIntervallTimer += updatePeriod;
            if (isShooting && shootIntervallTimer >= shootIntervall)
            {
                bullets.Add(new Bullet(player.shape.CenterX, player.shape.CenterY + player.shape.Radius, 0.015f));
                shootIntervallTimer = 0f;
            }


            var newAsteroids = new List<Asteroid>();
            var destroyedAstroids = new List<Asteroid>();

            //bullet logic
            foreach(var bullet in bullets)
            {
                bullet.shape.CenterY += bullet.direction.Y * updatePeriod;
                bullet.shape.CenterX += bullet.direction.X * updatePeriod;
                //bullet collision detection
                foreach(var asteroid in asteroidsList)
                {
                    if (asteroid.shape.Intersects(bullet.shape))
                    {
                        //getroffen = entfernen
                        destroyedAstroids.Add(asteroid);

                        //wenn noch leben, dann split
                        if (asteroid.life > 0)
                            newAsteroids.AddRange(asteroid.BreakAsteroid());
                    }
                }
            }

            //apply astroid changes
            foreach (var ast in newAsteroids)
                asteroidsList.Add(ast);
            foreach (var ast in destroyedAstroids)
                asteroidsList.Remove(ast);




            //Astroids logic
            foreach (var asteroid in asteroidsList)
            {
                //movement
                asteroid.shape.CenterX += asteroid.direction.X * updatePeriod;
                asteroid.shape.CenterY += asteroid.direction.Y * updatePeriod;

                //colliosion detection
                if (asteroid.shape.Intersects(player.shape))
                {
                    if (!player.isInvincible)
                    {
                    player.isInvincible = true;
                    invincibleTimer = 0f;
                    }
                }
                
                //boundary check
                if (asteroid.shape.CenterY + asteroid.shape.Radius < -1)
                {
                    //asteroid has left the screen -> let him reenter from above
                    asteroid.shape.CenterY = 1 + asteroid.shape.Radius;
                }
                if (asteroid.shape.CenterX + asteroid.shape.Radius < -1)
                {
                    //asteroid has left the screen -> let him reenter from right
                    asteroid.shape.CenterX = 1 + asteroid.shape.Radius;
                }
                else if (asteroid.shape.CenterX - asteroid.shape.Radius > 1)
                {
                    //asteroid has left the screen -> let him reenter from left
                    asteroid.shape.CenterX = - 1 - asteroid.shape.Radius;
                }
            }
        }

    }
}
