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
