using Internal;

namespace Botiga_I_Cistella_OscarReusMartinez_MarcVancea
{
    internal class Program
    {
        static string[] productesCistella;
        static int[] quantitat;
        static int nElemCistella;
        static double diners;

        static void Main(string[] args)
        {
            productesCistella = new string[10];
            quantitat = new int[10];
            nElemCistella = 0;
            diners = 100.0m;

            OrdenarCistella();

            Console.WriteLine(Mostra());
        }
        static bool ComprarProducte(string producte, int quantitat, double preu)
        {
            if (nElemCistella < productesCistella.Length && diners >= preu * quantitat)
            {
                productesCistella[nElemCistella] = producte;
                Program.quantitat[nElemCistella] = quantitat;
                diners -= preu * quantitat;
                nElemCistella++;
                return true;
            }
            else
            {
                return false;
            }
        }
        static void OrdenarCistella()
        {
            for (int i = 0; i < nElemCistella - 1; i++)
            {
                for (int j = 0; j < nElemCistella - i - 1; j++)
                {
                    if (productesCistella[j].CompareTo(productesCistella[j + 1]) > 0)
                    {
                        // Intercanviar productes
                        string tempProducte = productesCistella[j];
                        productesCistella[j] = productesCistella[j + 1];
                        productesCistella[j + 1] = tempProducte;

                        // Intercanviar quantitats
                        int tempQuantitat = quantitat[j];
                        quantitat[j] = quantitat[j + 1];
                        quantitat[j + 1] = tempQuantitat;
                    }
                }
            }
        }
        static string Mostra()
        {
            string tiquet = "";
            for (int i = 0; i < nElemCistella; i++)
            {
                tiquet += "Producte: " + productesCistella[i] + ", Quantitat: " + quantitat[i] + "\n";
            }
            tiquet += "Total a pagar: " + diners;
            return tiquet;
        }
    }
}