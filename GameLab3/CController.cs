using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GameLab3
{
    public class CController
    {
        private List<CCollectable> objects;
        private double spawnRate;
        private double time;
        private Random rng;
        private double minLifetime;
        private double maxLifetime;
        private double minSpriteSize;
        private double maxSpriteSize;
        private Size sceneSize;
        private double points;

        public CController(double spawnRate, ulong startTime, Size sceneSize)
        {
            rng = new Random();
            objects = new List<CCollectable>();
            this.spawnRate = spawnRate;
            time = startTime;
            this.sceneSize = sceneSize;
            points = 0;
            minLifetime = 1;
            maxLifetime = 5;
            minSpriteSize = 10;
            maxSpriteSize = 20;
        }

        public double Points => points;
        public List<CCollectable> Objects => objects;

        public CCollectable spawnObject()
        {
            double randSize = rng.NextDouble() * (maxSpriteSize - minSpriteSize) + minSpriteSize;
            double randLifetime = rng.NextDouble() * (maxLifetime - minLifetime) + minLifetime;

            double randX = rng.NextDouble() * (sceneSize.Width - randSize);
            double randY = rng.NextDouble() * (sceneSize.Height - randSize);

            Point randPos = new Point(randX, randY);

            CCollectable newObj ;

            if (rng.Next(0, 100) < 50) 
            {
                newObj = new CPointGiver(randPos, randSize, randLifetime);
            }
            else if  (rng.Next(0, 100) < 60)
            {
                newObj = new CClickSpeedUp(randPos, randSize, randLifetime);
            }
            else
            {
                newObj = new CLifetimeUp(randPos, randSize, randLifetime);
            }
            
            objects.Add(newObj);
            return newObj;
        }

        public void pointsIncrease(double value)
        {
            this.points += value;
        }

        public void lifetimeIncrease(double value)
        {
            this.minLifetime *= value;
        }
    }
}
