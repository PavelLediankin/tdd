﻿using System;
using System.Collections.Generic;
using System.Drawing;
using TagsCloudVisualization.Extensions;

namespace TagsCloudVisualization
{
    public class Cloud : IRectanglesCloud
    {
        private readonly List<RectangleF> rectangles;
        public IReadOnlyList<RectangleF> Rectangles => rectangles;
        public PointF Center { get; }

        public Cloud(PointF center)
        {
            Center = center;
            rectangles = new List<RectangleF>();
        }

        public void AddRectangle(RectangleF rectangle) 
            => rectangles.Add(rectangle);

        public RectangleF GetCloudBoundingRectangle()
        {
            var xMin = 0f;
            var xMax = 0f;
            var yMin = 0f;
            var yMax = 0f;
            foreach (var rect in Rectangles)
            {
                xMin = Math.Min(xMin, rect.X);
                yMin = Math.Min(yMin, rect.Y);
                xMax = Math.Max(xMax, rect.X + rect.Width);
                yMax = Math.Max(yMax, rect.Y + rect.Height);
            }
            var size = new SizeF(xMax - xMin, yMax - yMin);
            
            return RectangleFExtensions.GetRectangleByCenter(size, Center);
        }
    }
}
