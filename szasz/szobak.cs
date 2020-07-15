using System;
using System.Collections.Generic;
using System.Text;

namespace szabadulas_a_szobabol
{
    class Szobak
    {
        public string szobanev;
        public bool szobavan;
        public bool megnezett;
        public Szobak(string _szobanev, bool _szobavan, bool _megnezett)
        {
            szobanev = _szobanev;
            szobavan = _szobavan;
            megnezett = _megnezett;
        }


    }
}
