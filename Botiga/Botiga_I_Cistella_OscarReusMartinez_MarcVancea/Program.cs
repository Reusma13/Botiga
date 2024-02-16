using System;
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
            diners = 50.50m;

            if (ComprarProducte("Poma", 2))
            {
                Console.WriteLine("Compra exitosa!");
            }
            else
            {
                Console.WriteLine("No tens suficients diners per aquesta compra.");
            }

            OrdenarCistella();

            Console.WriteLine(MostraCistella());
        }
        static bool ComprarProducte(string producte, int quantitat, double preu)
        {
            
            if (!ExisteixProducte(producte))
            {
                Console.WriteLine("El producte no existeix a la botiga.");
                return false;
            }

            
            double preu = ObtenirPreu(producte);

            
            if (nElemCistella + quantitat > productesCistella.Length)
            {
                Console.WriteLine("No hi ha suficient espai a la cistella. Considera ampliar la cistella.");
                return false;
            }

            
            if (diners < preu * quantitat)
            {
                Console.WriteLine("No tens suficients diners per a aquesta compra. Considera ingressar més diners.");
                return false;
            }

            
            for (int i = 0; i < quantitat; i++)
            {
                productesCistella[nElemCistella] = producte;
                nElemCistella++;
            }

            
            diners -= preu * quantitat;

            return true;
        }
        static bool ExisteixProducte(string producte)
        {
            for (int i = 0; i < productesBotiga.Length; i++)
            {
                if (productesBotiga[i] == producte)
                {
                    return true;
                }
            }
            return false;
        }
        static double ObtenirPreu(string producte)
        {
            for (int i = 0; i < productesBotiga.Length; i++)
            {
                if (productesBotiga[i] == producte)
                {
                    return preusBotiga[i];
                }
            }
            return -1;
        }

        static void OrdenarCistella()
        {
            for (int i = 0; i < nElemCistella - 1; i++)
            {
                for (int j = 0; j < nElemCistella - i - 1; j++)
                {
                    if (productesCistella[j].CompareTo(productesCistella[j + 1]) > 0)
                    {
                        
                        string tempProducte = productesCistella[j];
                        productesCistella[j] = productesCistella[j + 1];
                        productesCistella[j + 1] = tempProducte;


                        
                        int tempQuantitat = quantitat[j];
                        quantitat[j] = quantitat[j + 1];
                        quantitat[j + 1] = tempQuantitat;
                    }
                }
            }
        }
        static void MostraCistella(string [] productesCistella,int[] quantitat, int[] nElemCistella, double[] diners )
        {
            Console.WriteLine(CistellaToString(productesCistella, quantitat, nElemCistella, diners));
        }

        static string CistellaToString()
        {
            string tiquet = "Tiquet de compra:\n";
            for (int i = 0; i < nElemCistella; i++)
            {
                double preuUnitari = ObtenirPreu(productesCistella[i]);
                tiquet += "Producte: " + productesCistella[i] + ", Quantitat: " + quantitat[i] + ", Preu unitari: " + preuUnitari + ", Preu total: " + preuUnitari * quantitat[i] + "\n";
            }
            tiquet += "Total a pagar: " + diners;
            return tiquet;
        }

    }
}