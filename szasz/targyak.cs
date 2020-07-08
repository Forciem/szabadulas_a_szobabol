using System;
using System.Collections.Generic;
using System.Text;

namespace szabadulas_a_szobabol
{
    class targyak
    {
        public string targynev;
        public bool interakcio;
        public bool hasznalhato;
        public bool hasznalt;

        public targyak(string _targynev, bool _interakcio, bool _hasznalhato, bool _hasznalt)
        {
            targynev = _targynev;
            interakcio = _interakcio;
            hasznalhato = _hasznalhato;
            hasznalt = _hasznalt;
        }
    }
}
