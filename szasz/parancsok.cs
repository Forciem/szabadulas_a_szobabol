using System;
using System.Collections.Generic;
using System.Text;

namespace szabadulas_a_szobabol
{
    class Parancsok
    {
        public string parancsnev;
        public bool mukodik;

        public Parancsok(string _parancsnev, bool _mukodik)
        {
            parancsnev = _parancsnev;
            mukodik = _mukodik;
        }
    }
}
