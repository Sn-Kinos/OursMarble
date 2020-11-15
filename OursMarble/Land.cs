using System.Collections.Generic;
using System.Windows.Forms;

namespace OursMarble
{
    class Land
    {
        private string name = "";
        private int pass = 0;
        private int home = 0;
        private int building = 0;
        private int hotel = 0;
        private int landmark = 0;

        private bool mergeable = true;

        public Land(string _name)
        {
            name = _name;
        }

        public Land(string[] data)
        {
            //name = data[0];
            //pass = data[0];
            //home = data[0];
            //building = data[0];
            //hotel = data[0];
            //landmark = data[0];
            //mergeable = data[0];
        }
    }
}
