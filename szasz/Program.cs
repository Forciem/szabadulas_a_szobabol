using System;

namespace szabadulas_a_szobabol
{


    class program
    {
        static void Main(string[] args)
        {
            targyak kulcs = new targyak("kulcs", false, false, false);
            targyak szekreny = new targyak("szekrény", false, false, false);
            targyak doboz = new targyak("doboz", false, false, false);
            targyak feszitovas = new targyak("feszítővas", false, false, false);
            targyak ajto = new targyak("ajtó", false, false, false);
            targyak kad = new targyak("kád", false, false, false);
            targyak ablak = new targyak("ablak", false, false, false);

            parancsok nezd = new parancsok("nézd", true);
            parancsok menj = new parancsok("menj", false);
            parancsok vedd_fel = new parancsok("menj", false);
            parancsok huzd = new parancsok("húzd", false);
            parancsok nyisd = new parancsok("nyisd", false);
            parancsok tord = new parancsok("törd", false);

            iranyok eszak = new iranyok("észak", false);
            iranyok kelet = new iranyok("kelet", false);
            iranyok del = new iranyok("dél", false);
            iranyok nyugat = new iranyok("nyugat", false);

            szobak nappali = new szobak("nappali", true, false);
            szobak furdo = new szobak("fürdőszoba", false, false);
            szobak gyoztes = new szobak("győztes", false, false);


            Console.WriteLine("Szabadulás a szobából");
            Console.WriteLine("\nEgy hideg padlón fekszel, és borzasztó fejfájásod van.\n" +
                "Nem tudod, hogyan kerültél ide, az utolsó emléked, hogy a város utcáin sétáltál,\n" +
                "amikor hirtelen hátulról megragadtak és kloroformos kendővel elkábítottak.\n" +
                "Felállsz majd a sötétben tapogatozva megtalálsz egy villanykapcsolót.\n" +
                "felkapcsolod, és utána látod, hogy egy régi, elhagyatott szobában találod magad.\n" +
                "(a következő parancsokat használhatod: menj, nézd, vedd fel, nyisd, húzd, törd)");


            while (!gyoztes.szobavan)
            {

                //nappali

                Console.WriteLine("Ebben a szobában vagy: " + nappali.szobanev);
                while (nappali.szobavan == true)
                {
                    //néz

                    if (!nappali.megnezett && nezd.parancsnev == Console.ReadLine())
                    {
                        Console.WriteLine("Az elhagyatott szoba egy nappalinak néz ki.\n" +
                                "A fal mellett látsz egy rozoga szekrényt. Mögötte mintha a szél fújna.\n" +
                                "Tőled nyugatra egy ajtót pillantasz meg.");
                        nappali.megnezett = true;
                    }

                    if (nappali.megnezett)
                    {
                        if (nezd.parancsnev == Console.ReadLine() && !ablak.interakcio)
                        {
                            Console.WriteLine("Az elhagyatott szoba egy nappalinak néz ki.\n" +
                                    "A fal mellett látsz egy rozoga szekrényt. Mögötte mintha a szél fújna.\n" +
                                    "Tőled nyugatra egy ajtót pillantasz meg.");
                        }
                        else
                        {
                            Console.WriteLine("Az elhagyatott szoba egy nappalinak néz ki.\n" +
                                    "A fal mellett látsz egy rozoga szekrényt. Mögötte mintha a szél fújna.\n" +
                                    "Tőled nyugatra egy ajtót pillantasz meg.\n" +
                                    "Északra egy betört ablak található");
                        }


                    }
                }
            }
        }
    }
}