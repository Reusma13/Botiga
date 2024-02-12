namespace Botiga_I_Cistella_OscarReusMartinez_MarcVancea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ets comprador o amo?(1/2)");
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
            string[] productesBotiga = new string[5];
            double[] preuProductes = new double[5];
            int nElemBotiga = 3;
            int opcio = 1;
            while (opcio != 0)
            {
                Console.WriteLine("Quina opcio vols fer?" +
                                "1. Afegir Producte (mira si entra)" +
                                "2. Afegir Producte (conjunt)" +
                                "3. Ampliar Tenda" +
                                "4. Modificar Preu" +
                                "5. Modificar Producte" +
                                "6. Ordenar Producte" +
                                "7. Ordenar Preu" +
                                "8. Mostrar" +
                                "9. ToString()" +
                                "0. Salir");
                opcio = Convert.ToInt32(Console.ReadLine());
                switch (opcio)
                {
                    case 1:
                        Console.Write("Quin producte vols introduir? ");
                        string producteAfegir = Console.ReadLine();
                        Console.Write("Quin es el seu valor? ");
                        double preuProducteAfegir = Convert.ToDouble(Console.ReadLine());
                        AfegirProducte(productesBotiga, preuProductes, ref nElemBotiga, producteAfegir, preuProducteAfegir);
                        break;
                    case 2:
                        AfegirProducte(productesBotiga, preuProductes, ref nElemBotiga);
                        break;
                    case 3:
                        Console.Write("A quin valor vols augmentar la tenda? ");
                        int num = Convert.ToInt32(Console.ReadLine());
                        AmpliarTenda(num, productesBotiga, preuProductes);
                        break;
                    case 4:
                        Console.Write("Quin producte li vols canviar el preu? ");
                        string producte = Console.ReadLine();
                        ModificarPreu(productesBotiga, preuProductes, producte);
                        break;
                    case 5:
                        Console.Write("Quin producte desitjas canviar? ");
                        string producteAntic = Console.ReadLine();
                        Console.Write("Per quin el vols canviar? ");
                        string producteNou = Console.ReadLine();
                        ModificarProducte(productesBotiga, producteAntic, producteNou);
                        break;
                    case 6:
                        OrdenarProducte(productesBotiga, preuProductes, nElemBotiga);
                        break;
                    case 7:
                        OrdenarPreus(productesBotiga, preuProductes, nElemBotiga);
                        break;
                    case 8:
                        MostrarBotiga(productesBotiga, preuProductes, nElemBotiga);
                        break;
                    case 9:
                        BotigaToString(productesBotiga, preuProductes, nElemBotiga);
                        break;
                    default:
                        Console.WriteLine("Error. Valor incorrecte");
                        break;
                }
            }
        }
        static void AfegirProducte(string[] productes, double[] preus, ref int nElem, string producteAfegir, double preuAfegir)
        {
            if (nElem >= productes.Length)
            {
                Console.WriteLine("La botiga està completa. Vols ampliar la botiga? (s/n)");
                string resposta = Console.ReadLine();
                if (resposta.ToLower() == "s")
                {
                    Console.Write("Quant la vols ampliar? ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    AmpliarTenda(num, productes, preus);
                }
            }
            productes[nElem] = producteAfegir;
            preus[nElem] = preuAfegir;
            nElem++;
        }
        static void AfegirProducte(string[] productes, double[] preus, ref int nElem)
        {

        }
        static void AmpliarTenda(int num, string[] productes, double[] preus)
        {
            string[] producteAux = new string[productes.Length + num];
            double[] preuAux = new double[productes.Length + num];
            for (int i = 0; i < producteAux.Length; i++) 
            {
                producteAux[i] = productes[i];
                preuAux[i] = preus[i];
            }
            productes = producteAux;
            preus = preuAux;
        }
        static void ModificarPreu(string[] productes, double[] preus, string ProducteCanviar)
        {

        }
        static void ModificarProducte(string[] productes, string producteAntic, string producteNou)
        {

        }
        static void OrdenarProducte(string[] productes, double[] preus, int nElem)
        {

        }
        static void OrdenarPreus(string[] productes, double[]preus, int nElem)
        {
           
        }
        static void MostrarBotiga(string[] productes, double[]preus, int nElem )
        {
            Console.WriteLine(BotigaToString(productes, preus, nElem));
        }
        static string BotigaToString(string[] productes, double[]preus, int nElem)
        {

            
        }
    }
}