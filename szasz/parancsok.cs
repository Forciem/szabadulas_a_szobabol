using System;
using System.Collections.Generic;
using System.Text;

namespace szabadulas_a_szobabol
{
    class parancsok
    {
        public string parancsnev;
        public bool mukodik;

        public parancsok(string _parancsnev, bool _mukodik)
        {
            parancsnev = _parancsnev;
            mukodik = _mukodik;
        }
    }
}
