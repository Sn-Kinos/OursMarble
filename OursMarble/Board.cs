using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OursMarble
{
    class Board
    {
        public JsonElement map;
        public List<Land> lands = new List<Land>();
        public Dictionary<string, Brush> colors = new Dictionary<string, Brush>
        {
            {"a", Brushes.LightGreen},
            {"b", Brushes.MediumSeaGreen},
            {"c", Brushes.Cyan},
            {"d", Brushes.SkyBlue},
            {"e", Brushes.Pink},
            {"f", Brushes.MediumPurple},
            {"g", Brushes.Orange},
            {"h", Brushes.Red},
        };

        public Point[] points =
        {
            new Point(8,8),
            new Point(7,8),
            new Point(6,8),
            new Point(5,8),
            new Point(4,8),
            new Point(3,8),
            new Point(2,8),
            new Point(1,8),
            new Point(0,8),
            new Point(0,7),
            new Point(0,6),
            new Point(0,5),
            new Point(0,4),
            new Point(0,3),
            new Point(0,2),
            new Point(0,1),
            new Point(0,0),
            new Point(1,0),
            new Point(2,0),
            new Point(3,0),
            new Point(4,0),
            new Point(5,0),
            new Point(6,0),
            new Point(7,0),
            new Point(8,0),
            new Point(8,1),
            new Point(8,2),
            new Point(8,3),
            new Point(8,4),
            new Point(8,5),
            new Point(8,6),
            new Point(8,7),
        };

        public Board()
        {
            try
            {
                string mapData = File.ReadAllText(@"..\..\..\mapData.json");
                map = JsonDocument.Parse(mapData).RootElement.GetProperty("map");
                for (int i = 0; i < map.GetArrayLength(); i++)
                {
                    lands.Add(new Land(map[i]));
                }
            }
            catch (FileNotFoundException e)
            {

            }
        }

    }
}
