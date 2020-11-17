using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;

namespace OursMarble
{
    class Land
    {
        private JsonElement data;

        public Land(JsonElement _data)
        {
            data = _data;
        }
    }
}
