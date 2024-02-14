using System.Runtime.InteropServices;

namespace Botiga_I_Cistella_OscarReusMartinez_MarcVancea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ets amo o comprador?(1/2)");
            int opcio = Convert.ToInt32(Console.ReadLine());
            switch (opcio)
            {
                case 1:
                    Botiga();
                    break;
                /*case 2:
                    cistella();
                    break;*/
                default:
                    Console.WriteLine("Error. Opcio incorrecta");
                    break;
            }
        }
        static void Botiga()
        {
            string[] productesBotiga = new string[5] { "Poma", "Pera", "Platan", "Arroz", "Verdura" };
            double[] preuProductes = new double[5] { 1.4, 1.5, 3.4, 2.2, 5.3};
            int nElemBotiga = 5;
            int opcio = 1;
            while (opcio != 0)
            {
                Console.Clear();
                Console.WriteLine("Quina opcio vols fer? \n" + 
                                "1. Afegir Producte (un sol producte) \n" +
                                "2. Afegir Producte (conjunt) \n" +
                                "3. Ampliar Tenda \n" +
                                "4. Modificar Preu \n" +
                                "5. Modificar Producte \n" +
                                "6. Ordenar Producte \n" +
                                "7. Ordenar Preu \n" +
                                "8. Mostrar \n" +
                                "9. ToString() \n" +
                                "0. Salir \n");
                opcio = Convert.ToInt32(Console.ReadLine());
                switch (opcio)
                {
                    case 0:
                        break;
                    case 1:
                        Console.Clear();
                        Console.Write("Quin producte vols introduir? ");
                        string producteAfegir = Console.ReadLine();
                        Console.Write("Quin es el seu valor? ");
                        double preuProducteAfegir = Convert.ToDouble(Console.ReadLine());
                        AfegirProducte(ref productesBotiga, ref preuProductes, ref nElemBotiga, producteAfegir, preuProducteAfegir);
                        TornarMenu();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Quants productes vols afegir? ");
                        int numAfegir = Convert.ToInt32(Console.ReadLine());
                        string[] productesAfegir = new string[numAfegir];
                        double[] preusAfegir = new double[numAfegir];
                        for (int i = 0; i < productesAfegir.Length; i++)
                        {
                            Console.WriteLine("Posa un valor per afegir: ");
                            productesAfegir[i] = Console.ReadLine();
                            Console.WriteLine("Posa el preu del producte: ");
                            preusAfegir[i] = Convert.ToDouble(Console.ReadLine());
                        }
                        AfegirProducte(ref productesBotiga, ref preuProductes, ref nElemBotiga, productesAfegir, preusAfegir);
                        TornarMenu();
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("A quin valor vols augmentar la tenda? ");
                        int num = Convert.ToInt32(Console.ReadLine());
                        AmpliarTenda(num, ref productesBotiga, ref preuProductes);
                        TornarMenu();
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Quin producte li vols canviar el preu? ");
                        string producte = Console.ReadLine();
                        ModificarPreu(productesBotiga, preuProductes, producte);
                        TornarMenu();
                        break;
                    case 5:
                        Console.Clear();
                        Console.Write("Quin producte desitjas canviar? ");
                        string producteAntic = Console.ReadLine();
                        Console.Write("Per quin el vols canviar? ");
                        string producteNou = Console.ReadLine();
                        ModificarProducte(productesBotiga, producteAntic, producteNou);
                        TornarMenu();
                        break;
                    case 6:
                        Console.Clear();
                        OrdenarProducte(productesBotiga, preuProductes, nElemBotiga);
                        TornarMenu();
                        break;
                    case 7:
                        Console.Clear();
                        OrdenarPreus(productesBotiga, preuProductes, 0, preuProductes.Length - 1, nElemBotiga);
                        TornarMenu();
                        break;
                    case 8:
                        MostrarBotiga(productesBotiga, preuProductes, nElemBotiga);
                        break;
                    /*case 9:
                        BotigaToString(productesBotiga, preuProductes, nElemBotiga);
                        break;*/
                    default:
                        Console.WriteLine("Error. Valor incorrecte");
                        TornarMenu();
                        break;
                }
            }
        }
        static void AfegirProducte(ref string[] productes, ref double[] preus, ref int nElem, string producteAfegir, double preuAfegir)
        {
            if (nElem >= productes.Length)
            {
                Console.WriteLine("La botiga està completa. Vols ampliar la botiga? (s/n)");
                string resposta = Console.ReadLine();
                if (resposta.ToLower() == "s")
                {
                    Console.Write("Quant la vols ampliar? ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    AmpliarTenda(num, ref productes, ref preus);
                }
            }
            productes[nElem] = producteAfegir;
            preus[nElem] = preuAfegir;
            nElem++;
        }
        static void AfegirProducte(ref string[] productes, ref double[] preus, ref int nElem, string[] productesAfegir, double[] preusAfegir)
        {
            
            for (int i = 0; i < productes.Length && i < productesAfegir.Length; i++)
            {
                if (nElem >= productes.Length)
                {
                    Console.WriteLine("La botiga està completa. Vols ampliar la botiga? (s/n)");
                    string resposta = Console.ReadLine();
                    if (resposta.ToLower() == "s")
                    {
                        Console.Write("Quant la vols ampliar? ");
                        int num = Convert.ToInt32(Console.ReadLine());
                        AmpliarTenda(num, ref productes, ref preus);
                    }
                    else
                    {
                        return;
                    }
                }
                productes[nElem] = productesAfegir[i];
                preus[nElem] = preusAfegir[i];
                nElem++;
            }
        }
        static void AmpliarTenda(int num, ref string[] productes, ref double[] preus)
        {
            string[] producteAux = new string[productes.Length + num];
            double[] preuAux = new double[preus.Length + num];
            for (int i = 0; i < productes.Length; i++)
            {
                producteAux[i] = productes[i];
                preuAux[i] = preus[i];
            }
            productes = producteAux;
            preus = preuAux;
        }
        static void ModificarPreu(string[] productes, double[] preus, string ProducteCanviar)
        {
            for (int i = 0;i < productes.Length;i++) 
            { 
                if (productes[i].Contains(ProducteCanviar))
                {
                    Console.WriteLine($"Quin es el preu que li vols posar a: {ProducteCanviar}");
                    double preuNou = Convert.ToDouble(Console.ReadLine());
                    preus[i] = preuNou;
                }
                if (!productes.Contains(ProducteCanviar))
                {
                    Console.WriteLine("Producte no trobat");
                }
            }
        }
        static void ModificarProducte(string[] productes, string producteAntic, string producteNou)
        {
            for (int i = 0; i < productes.Length ;i++)
            {
                if (productes[i].Contains(producteAntic))
                {
                    productes[i] = producteNou;
                }
                if (!productes.Contains(producteAntic) && !productes.Contains(producteNou))
                    Console.WriteLine("Producte no trobat");
            }
        }
        static void OrdenarProducte(string[] productes, double[] preus, int nElem)
        {
            for (int numVolta = 0; numVolta < nElem - 1; numVolta++)
            {
                for (int i = 0; i < nElem - 1; i++)
                { 

                    if (string.Compare(productes[i], productes[i + 1]) > 0)
                    {
                        // intercambio arr[j+1] y arr[j]
                        string temp = productes[i];
                        productes[i] = productes[i + 1];
                        productes[i + 1] = temp;
                        double tempPreu = preus[i];
                        preus[i] = preus[i + 1];
                        preus[i + 1] = tempPreu;
                    }
                }
            }
            for (int i = 0; i < nElem - 1;i++)
                Console.WriteLine($"Producte: {productes[i]} Preu: {preus[i]}");
        }
        static void OrdenarPreus(string[] productes, double[] preus, int li, int ls, int nElem)
        {
            
            int mig = (int)preus[(li + ls) / 2];
            int i = li;
            int j = ls;

            do
            {
                while (preus[i] < mig && i < ls ) i++;
                while (preus[j] > mig && j > li ) j--;
                if (i <= j)
                {
                    Permuta(ref preus[i], ref preus[j], ref productes[i], ref productes[j]);
                    i++;
                    j--;
                }
            } while (i <= j);
            if (j > li) OrdenarPreus(productes, preus, li, j, nElem);
            if (i > ls) OrdenarPreus(productes, preus, i, ls, nElem);
            for (int k = 0; k < nElem - 1; k++)
                Console.WriteLine($"Producte: {productes[k]} Preu: {preus[k]}");
        }
        static void MostrarBotiga(string[] productes, double[] preus, int nElem)
        {
            //Console.WriteLine(BotigaToString(productes, preus, nElem));
        }
        /*static string BotigaToString(string[] productes, double[] preus, int nElem)
        {


        }*/
        static void TornarMenu()
        {
            int i = 5;
            while (i != 0)
            {
                Console.Write("\r");
                Console.Write($"Tornant al menu: {i}'s");
                Thread.Sleep(1000);
                i--;
            }
        }
        static void Permuta(ref double preu1, ref double preu2, ref string producte1, ref string producte2)
        {
            double temp = preu1;
            preu1 = preu2;
            preu2 = temp;
            string tempProducte = producte1;
            producte1 = producte2;
            producte2 = tempProducte;
        }
    }
}