using System;
using System.Collections.Generic;
using System.Text;

namespace szabadulas_a_szobabol
{
    class Targyak
    {
        public string targynev;
        public bool interakcio;
        public bool hasznalhato;
        public bool hasznalt;
        public bool hasznalt2;


        public Targyak(string _targynev, bool _interakcio, bool _hasznalhato, bool _hasznalt, bool _hasznalt2)
        {
            targynev = _targynev;
            interakcio = _interakcio;
            hasznalhato = _hasznalhato;
            hasznalt = _hasznalt;
            hasznalt2 = _hasznalt2;

        }
    }
}
