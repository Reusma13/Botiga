using System.Runtime.InteropServices;

namespace Botiga_I_Cistella_OscarReusMartinez_MarcVancea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] productesBotiga = new string[6] { "Poma", "Pera", "Platan", "Arroz", "Verdura", "Llanta" };
            double[] preuProductes = new double[6] { 1.4, 1.5, 3.4, 2.2, 5.3, 16.3 };
            Console.WriteLine("Selecciona una opcio: \n" +
                          "     1. Amo \n" +
                          "     2. Comprador");
            int opcio = Convert.ToInt32(Console.ReadLine());
            switch (opcio)
            {
                case 1:
                    Botiga(productesBotiga, preuProductes);
                    break;
                case 2:
                    Cistella(productesBotiga, preuProductes);
                    break;
                default:
                    Console.WriteLine("Error. Opcio incorrecta");
                    break;
            }
        }
        static void Botiga(string[] productesBotiga, double[] preuProductes)
        {

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
                        TornarMenu();
                        break;
                    case 9:
                        BotigaToString(productesBotiga, preuProductes, nElemBotiga);
                        TornarMenu();
                        break;
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
            for (int k = 0; k < nElem; k++)
                Console.WriteLine($"Producte: {productes[k]} Preu: {preus[k]}");
        }
        static void MostrarBotiga(string[] productes, double[] preus, int nElem)
        {
            Console.WriteLine(BotigaToString(productes, preus, nElem));
        }
        static string BotigaToString(string[] productes, double[] preus, int nElem)
        {
            string mostrar = "";
            for (int i = 0; i < nElem; i++)
            {
                mostrar += $"Producte: {productes[i]}, el seu preu es de: {preus[i]}. Portem {i + 1} productes contats. \nEns falta per omplenar {productes.Length - 1 - i} en tota la taula. " +
                    $"Contant nElements ens faltan {nElem - (i + 1)} \n";
            }
            return mostrar;
        }
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


        static void Cistella(string[] productesBotiga, double[] preuProductes)
        {
            string[] productesCistella = new string[10];
            int[] quantitat = new int[10];
            int nElemCistella = 0;
            double diners = 50.50;

            int opcio = 1;

            while (opcio != 0)
            {
                Console.Clear();
                Console.WriteLine("Quina opcio vols fer? \n" +
                                "1. Afegir Producte (un sol producte) \n" +
                                "2. Afegir Producte (conjunt) \n" +
                                "3. Ordenar Cistella \n" +
                                "4. Mostrar Cistella \n" +
                                "5. CistellaToString \n" +
                                "0. Salir \n");
                opcio = Convert.ToInt32(Console.ReadLine());
                switch (opcio)
                {
                    case 0:
                        break;
                    case 1:
                        Console.Clear();
                        Console.Write("Quin producte vols afegir? ");
                        string producte = Console.ReadLine();
                        Console.Write("Quina es la cantitat que vols afegir? ");
                        int quantitatProducte = Convert.ToInt32(Console.ReadLine());
                        ComprarProducte(producte, quantitatProducte, productesBotiga, preuProductes, ref productesCistella, ref quantitat, ref nElemCistella, ref diners);
                        TornarMenu();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Quants productes vols afegir? ");
                        int numAfegir = Convert.ToInt32(Console.ReadLine());
                        string[] productesAfegir = new string[numAfegir];
                        int[] quantitatAfegir = new int[numAfegir];
                        for (int i = 0; i < productesAfegir.Length; i++)
                        {
                            Console.Write("Posa un valor per afegir: ");
                            productesAfegir[i] = Console.ReadLine();
                            Console.Write("Posa la quantitat que vols afegir: ");
                            quantitatAfegir[i] = Convert.ToInt32(Console.ReadLine());
                        }
                        ComprarVarisProducte(productesBotiga, preuProductes, ref nElemCistella, productesAfegir, ref quantitatAfegir, ref productesCistella, ref quantitat, ref diners);
                        TornarMenu();
                        break;
                    case 3:
                        Console.Clear();
                        OrdenarCistella(nElemCistella, productesCistella, quantitat, diners);
                        TornarMenu();
                        break;
                    case 4:
                        Console.Clear();
                        MostraCistella(productesCistella, quantitat, nElemCistella, diners, preuProductes, productesBotiga);
                        TornarMenu();
                        break;
                    case 5:
                        Console.Clear();
                        CistellaToString(productesCistella, quantitat, nElemCistella, diners, preuProductes, productesBotiga);
                        TornarMenu();
                        break;
                    default:
                        Console.WriteLine("Error. Valor incorrecte");
                        TornarMenu();
                        break;
                }
            }
            
        }
        static void ComprarProducte(string producte, int quantitat, string[] productesBotiga, double[] preuProductes, ref string[] producteCistella, ref int[] quantitatProducte, ref int nElemCistella, ref double diners)
        {
            bool producteAfegit = false;
            bool producteTrobatEnArrayCistella = false;
            bool productoEncontrado = false;
            for (int i = 0; i < productesBotiga.Length && !producteAfegit; i++)
            {
                if (producte == productesBotiga[i])
                {
                    if (nElemCistella >= producteCistella.Length)
                    {
                        Console.WriteLine("La Cistella esta completa. Vols ampliar la botiga (s/n)");
                        string resposta = Console.ReadLine();
                        if (resposta.ToLower() == "s")
                        {
                            Console.Write("Quant la vols ampliar? ");
                            int num = Convert.ToInt32(Console.ReadLine());
                            AmpliarCistella(num, ref producteCistella, ref quantitatProducte);
                        }
                    }
                    int k;
                    for (k = 0; k < producteCistella.Length && producteTrobatEnArrayCistella == false; k++)
                    {
                        if (producte == producteCistella[k])
                        {
                            producteTrobatEnArrayCistella = true;
                            producteAfegit = true;
                            quantitatProducte[k] += quantitat;
                            Console.WriteLine($"Producto: {producte} afegit");
                        }
                    }
                    if (!producteTrobatEnArrayCistella)
                    {
                        if (preuProductes[i] * quantitat > diners)
                        {
                            Console.WriteLine("No tens els diners necessaris per comprar aquest producte. Vols afegir mes diners (s/n)");
                            string respostaDiners = Console.ReadLine();
                            if (respostaDiners.ToLower() == "s")
                            {
                                Console.Write("Quants diners vols afegir? ");
                                double num = Convert.ToDouble(Console.ReadLine());
                                AfegirDiners(ref diners, num);
                            }
                        }
                        else
                        {
                            producteCistella[nElemCistella] = producte;
                            quantitatProducte[nElemCistella] = quantitat;
                            diners -= preuProductes[i] * quantitat;
                            nElemCistella++;
                            producteAfegit = true;
                            Console.WriteLine($"Producto: {producte} afegit");
                        }
                    }
                    
                }
            }
            if (!producteAfegit)
            {
                Console.WriteLine($"El producto: {producte} no se ha encontrado en la tienda.");
            }
        }
        static void ComprarVarisProducte(string[] productesBotiga, double[]preuProductes, ref int nElemCistella, string[] productesAfegir, ref int []quantitatAfegir, ref string[]producteCistella, ref int[]quantitatProducte, ref double diners)
        {
            for (int i = 0; i < productesAfegir.Length; i++)
            {
                bool producteTrobatEnArrayCistella = false;
                bool productoEncontrado = false;
                int j;
                for (j = 0; j < productesBotiga.Length && productoEncontrado == false; j++)
                {
                    if (productesAfegir[i] == productesBotiga[j])
                    {
                        productoEncontrado = true;
                    }
                    if (productoEncontrado == true)
                    {
                        int k;
                        if (nElemCistella >= producteCistella.Length)
                        {
                            Console.WriteLine("La Cistella esta completa. Vols ampliar la botiga (s/n)");
                            string resposta = Console.ReadLine();
                            if (resposta.ToLower() == "s")
                            {
                                Console.Write("Quant la vols ampliar? ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                AmpliarCistella(num, ref producteCistella, ref quantitatProducte);
                            }
                            i--;
                        }
                        for (k = 0; k < producteCistella.Length && producteTrobatEnArrayCistella == false; k++)
                        {
                            if (productesAfegir[i] == producteCistella[k])
                            {
                                producteTrobatEnArrayCistella = true;
                                quantitatProducte[k] += quantitatAfegir[i];
                            }
                        }
                        if (!producteTrobatEnArrayCistella)
                        {
                            if (preuProductes[j] * quantitatAfegir[i] > diners)
                            {
                                Console.WriteLine("No tens els diners necessaris per comprar aquest producte. Vols afegir mes diners (s/n)");
                                string respostaDiners = Console.ReadLine();
                                if (respostaDiners.ToLower() == "s")
                                {
                                    Console.Write("Quants diners vols afegir? ");
                                    double num = Convert.ToDouble(Console.ReadLine());
                                    AfegirDiners(ref diners, num);
                                }
                                i--;
                            }
                            else
                            {
                                producteCistella[nElemCistella] = productesAfegir[i];
                                quantitatProducte[nElemCistella] = quantitatAfegir[i];
                                diners -= preuProductes[j] * quantitatAfegir[i];
                                nElemCistella++;
                                Console.WriteLine($"Producto: {productesAfegir[i]} afegit");
                            }
                        }
                        
                    }
                }
                if (!productoEncontrado)
                {
                    Console.WriteLine($"El producto: {productesAfegir[i]} no se ha encontrado en la tienda.");
                }
            }
        }
        static void OrdenarCistella(int nElemCistella, string[] productesCistella, int[] quantitat, double diners)
        {
            for (int numvolta = 0; numvolta < nElemCistella; numvolta++)
            {
                for (int i = 0; i < nElemCistella - 1; i++)
                {
                    if (productesCistella[i].CompareTo(productesCistella[i + 1]) > 0)
                    {

                        string tempProducte = productesCistella[i];
                        productesCistella[i] = productesCistella[i + 1];
                        productesCistella[i + 1] = tempProducte;

                        int tempQuantitat = quantitat[i];
                        quantitat[i] = quantitat[i + 1];
                        quantitat[i + 1] = tempQuantitat;
                    }
                }
            }
            for (int i = 0; i < nElemCistella; i++)
                Console.WriteLine($"Producte: {productesCistella[i]} Quantitat: {quantitat[i]}");
        }
        static void MostraCistella(string[] productesCistella, int[] quantitat, int nElemCistella, double diners, double[]preuProducte, string[] producteBotiga)
        {
            Console.WriteLine(CistellaToString(productesCistella, quantitat, nElemCistella, diners, preuProducte, producteBotiga));
        }

        static string CistellaToString(string[] productesCistella, int[] quantitat, int nElemCistella,  double diners, double[] preuProducte, string[] producteBotiga)
        {
            string tiquet = "Tiquet de compra:\n";
            double preuTotalProducte = 0;
            double preuTotal = 0, preuUnitari = 0;
            bool trobat = false;
            for (int i = 0; i < nElemCistella; i++)
            {
                trobat = false;
                int j;
                for (j = 0; j < producteBotiga.Length && trobat != true; j++)
                {
                    if (productesCistella[i] == producteBotiga[j])
                    {
                        preuUnitari = preuProducte[j];
                        trobat = true;
                    }
                }
                preuTotalProducte = preuUnitari * quantitat[i];
                tiquet += "Producte: " + productesCistella[i] + ", Quantitat: " + quantitat[i] + ", Preu unitari: " + preuUnitari.ToString("F2") + ", Preu total: " + preuTotalProducte.ToString("F2") + "\n";
                preuTotal += preuTotalProducte;
            }
            tiquet += "Total a pagar: " + preuTotal.ToString("F2");
            return tiquet;
        }
        static void AmpliarCistella(int num, ref string[]producteCistella, ref int[]quantitatProducte)
        {
            string[] producteAux = new string[producteCistella.Length + num];
            int[] preuAux = new int[quantitatProducte.Length + num];
            for (int i = 0; i < producteCistella.Length; i++)
            {
                producteAux[i] = producteCistella[i];
                preuAux[i] = quantitatProducte[i];
            }
            producteCistella = producteAux;
            quantitatProducte = preuAux;
        }
        static void AfegirDiners(ref double diners, double num)
        {
            diners += num;
        }
    }
}