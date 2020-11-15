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

        public Board()
        {
            try
            {
                string mapData = File.ReadAllText(@"..\..\..\mapData.json");
                map = JsonDocument.Parse(mapData).RootElement.GetProperty("map");
            }
            catch (FileNotFoundException e)
            {

            }
        }

    }
}
